using System;
using System.Collections.Generic;
using Domain;
using DataAccess;
using BusinessLogicInterface;
namespace BusinessLogic
{
    public class AdministratorLogic //: IAdministratorLogic
    {

        private IAdministratorRepository AdmDA;
        public AdministratorLogic(IAdministratorRepository admDA)
        {
            this.AdmDA = admDA;
        }
        private AdministratorRepository adminRepository;

        public AdministratorLogic(AdministratorRepository adm)
        {
            this.adminRepository = adm;
        }

        public Administrator Create(Administrator admin)
        {
            //     adminRepository.Add(admin);
            //   adminRepository.Save();
            return new Administrator();
        }

        public void Delete(Guid id)
        {
            Administrator admin = adminRepository.Get(id);

            if (admin == null)
            {
                //error: el admin no existe
            }
            admin.IsActive = false;

            //adminRepository.Remove(admin);
            adminRepository.Save();
        }

        public void Update(Guid id, Administrator updatedAdmin)
        {

            Administrator admin = adminRepository.Get(id);

            if (admin == null)
            {
                //error: el administrador no existe
            }

            admin.IsActive = updatedAdmin.IsActive;
            admin.Name = updatedAdmin.Name;
            admin.Password = updatedAdmin.Password;
            admin.Email = updatedAdmin.Email;

            adminRepository.Update(admin);
            adminRepository.Save();
        }

        public Administrator Get(Guid id)
        {
            Administrator admin = adminRepository.Get(id);
            if (admin == null)
            {
                //error el administrador no existe
            }
            return admin;
        }

        public IEnumerable<Administrator> GetAll()
        {
            return this.AdmDA.GetAll();
        }
    }
}