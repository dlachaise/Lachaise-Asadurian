using System;
using System.Collections.Generic;
using Domain;
using DataAccess;
using BusinessLogicInterface;
using System.Linq;

namespace BusinessLogic
{
    public class PsychologistLogic : IPsychologistLogic
    {
        private PsychologistRepository psychoRepoistory;

        public PsychologistLogic()
        {
            DataContext context = ContextFactory.GetNewContext();
            psychoRepoistory = new PsychologistRepository(context);
        }

        public IEnumerable<Psychologist> GetByPathology(Guid pathology)
        {
            return psychoRepoistory.GetAll().Where(psyc=> psyc.Pathologies.Any(pat=> pat.Id == pathology));

        }

        public IEnumerable<Psychologist> GetAvailable(){
           DateTime today = DateTime.Now;
            var pedo = 
        }


        public void Create(Psychologist admin)
        {
            psychoRepoistory.Add(admin);
            psychoRepoistory.Save();
        }

        public void Delete(Guid id)
        {
            Psychologist admin = psychoRepoistory.Get(id);

            if (admin == null)
            {
                //error: el admin no existe
            }
            admin.IsActive = false;

            //psychoRepoistory.Remove(admin);
            psychoRepoistory.Save();
        }

        public void Update(Guid id, Psychologist updatedAdmin)
        {

            Psychologist admin = psychoRepoistory.Get(id);

            if (admin == null)
            {
                //error: el administrador no existe
            }

            admin.IsActive = updatedAdmin.IsActive;
            admin.Name = updatedAdmin.Name;
            admin.Password = updatedAdmin.Password;
            admin.Email = updatedAdmin.Email;

            psychoRepoistory.Update(admin);
            psychoRepoistory.Save();
        }

        public Psychologist Get(Guid id)
        {
            Psychologist admin = psychoRepoistory.Get(id);
            if (admin == null)
            {
                //error el administrador no existe
            }
            return admin;
        }

        public IEnumerable<Psychologist> GetAll()
        {
            return psychoRepoistory.GetAll();
        }
    }
}