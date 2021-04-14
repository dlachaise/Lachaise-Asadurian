using System;
using System.Collections.Generic;
using Domain;
using DataAccess;
using BusinessLogicInterface;
namespace BusinessLogic
{
    public class AdministratorLogic : IAdministratorLogic //IAdministratorRepository
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
            //     adminRepository.Add(admin);
            //   adminRepository.Save();
            return new Administrator();
        }

        public void Delete(Guid id)
        {
            Administrator admin = admDA.Get(id);

            if (admin == null)
            {
                //error: el admin no existe
            }
            admin.IsActive = false;

            //adminRepository.Remove(admin);
            admDA.Save();
        }

        public void Add(Administrator admin){
            if(admin!=null){
               //adminRepository.Add(admin);
                admDA.Add(admin);
                admDA.Save();
            }
        }

        public void Update(/*Guid id,*/ Administrator updatedAdmin)
        {

            Administrator admin = admDA.Get(updatedAdmin.Id);

            if (admin == null)
            {
                //error: el administrador no existe
            }

            admin.IsActive = updatedAdmin.IsActive;
            admin.Name = updatedAdmin.Name;
            admin.Password = updatedAdmin.Password;
            admin.Email = updatedAdmin.Email;

            admDA.Update(admin);
            admDA.Save();
        }

        public Administrator Get(Guid id)
        {
            Administrator admin = admDA.Get(id);
            if (admin != null && admin.IsActive == true)
            {
                return admin;
            }
            else{
                throw new Exception("Administrator does not exist");
            }
        }

        public IEnumerable<Administrator> GetAll()
        {
            return this.admDA.GetAll();
        }
    }
}