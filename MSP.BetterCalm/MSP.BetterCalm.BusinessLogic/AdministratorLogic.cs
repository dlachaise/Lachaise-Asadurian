using System;
using System.Collections.Generic;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.DataAccess.Interface;
using System.Linq;
using MSP.BetterCalm.BusinessLogic.Interface;

namespace MSP.BetterCalm.BusinessLogic
{
    public class AdministratorLogic : IAdministratorLogic
    {

        private IRepository<Administrator> admDA;

        public AdministratorLogic(IRepository<Administrator> AdmDA)
        {
            this.admDA = AdmDA;
        }

        public Administrator Create(Administrator admin)
        {
            if (!ExistAdministrator(admin))
            {
                admDA.Create(admin);
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
                admDA.Delete(admin);
                admDA.Save();
            }
            else
            {
                throw new Exception("Administrator does not exist");
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
            if (admin != null)
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
            return this.admDA.GetAll().Where(y => y.IsActive == true);
        }
    }
}