using System;
using System.Collections.Generic;
using System.Linq;
using MSP.BetterCalm.BusinessLogic.Interface;
using MSP.BetterCalm.DataAccess.Interface;
using MSP.BetterCalm.Domain;

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
            if (!ExistAdministrator(admin) && CorrectData(admin))
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

        private bool CorrectData(Administrator administrator)
        {
            bool correctMail = mailValidation(administrator.Email);
            bool correctPass = passValidation(administrator.Password);
            if (correctMail && correctPass)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public bool passValidation(string pass)
        {
            if (pass == "")
            {
                throw new Exception("You can enter empty password");
            }
            if (pass.Length > 6)
            {
                return true;
            }
            else
            {
                throw new Exception("Invalid password");
            }
        }

        public bool mailValidation(string mailCorrecto)
        {
            if (mailCorrecto == "")
            {
                throw new Exception("You can enter empty email");
            }

            bool esValido = true;

            if (!mailCorrecto.Contains("@"))
            {
                esValido = false;
            }
            else
            {
                string[] mailArray = mailCorrecto.Split('@');
                if (mailArray.Length != 2)
                {
                    esValido = false;
                }
                else
                {
                    string[] servidor = mailArray[1].Split('.');
                    if (servidor.Length < 2 || servidor.Length > 3)
                    {
                        esValido = false;
                    }
                }
            }

            if (!esValido)
            {
                throw new Exception("Invalid email format");
            }
            else
            {
                return esValido;
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