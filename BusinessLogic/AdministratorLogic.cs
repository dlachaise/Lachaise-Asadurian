using System;
using System.Collections.Generic;
using Domain;
using DataAccess;
using BusinessLogicInterface;
using System.Linq;
namespace BusinessLogic
{
    public class AdministratorLogic : IAdministratorLogic
    {

        private IAdministratorRepository admDA;
        private AdministratorLogic adminLogic;
        private IAdministratorLogic iAdminLogic;

        public AdministratorLogic(IAdministratorRepository AdmDA)
        {
            this.admDA = AdmDA;
        }

        public AdministratorLogic(AdministratorLogic adm)
        {
            this.adminLogic = adm;
        }
        public AdministratorLogic(IAdministratorLogic adm)
        {
            this.iAdminLogic = adm;
        }
        public AdministratorLogic(IAdministratorRepository repository, IAdministratorLogic adminsLogic)
        {
            this.admDA = repository;
            this.iAdminLogic = adminsLogic;
        }

        public Administrator Create(Administrator admin)
        {
            if (!ExistAdministrator(admin))
            {
                admDA.Add(admin);
                admDA.Save();
                return admin;
            }
            else
            {
                throw new Exception("The administrator already exists");
            }

        }

        private bool ExistAdministrator(Administrator administrator)
        {
            return admDA.GetAll().Any(x => x.Email == administrator.Email);
        }
        public void Delete(Guid id)
        {
            Administrator admin = admDA.Get(id);

            if (admin != null)
            {
                admin.IsActive = false;
                admDA.Remove(admin);
                admDA.Save();
            }
            else
            {
                throw new Exception("Administrator does not exist");
            }

        }

        public void Add(Administrator admin)
        {
            if (admin != null)
            {
                //adminRepository.Add(admin);
                admDA.Add(admin);
                admDA.Save();
            }
        }

        public void Update(Guid id, Administrator updatedAdmin)
        {

            Administrator admin = admDA.Get(id);

            if (admin != null)
            {
                admin.Update(updatedAdmin);
                admDA.Update(admin);
                admDA.Save();
            }
            else
            {
                throw new Exception("The administrator doesn't exists");
            }
        }

        public Administrator Get(Guid id)
        {
            Administrator admin = admDA.Get(id);
            if (admin != null && admin.IsActive == true)
            {
                return admin;
            }
            else
            {
                throw new Exception("Administrator does not exist");
            }
        }

        public IEnumerable<Administrator> GetAll()
        {
            return this.admDA.GetAll();
        }
    }
}