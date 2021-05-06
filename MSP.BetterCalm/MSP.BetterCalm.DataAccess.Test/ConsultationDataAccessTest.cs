using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess.Test
{
    [TestClass]
    public class ConsultationDataAccessTest
    {
        private DataContext context;
        private Consultation consult;
        private Repository<Consultation> consultationRepo;
        private Psychologist psycho;

        [TestInitialize]
        public void InitTest()
        {
            List<Pathology> patList1 = new List<Pathology>{
                new Pathology{
                    Id = Guid.NewGuid(),
                    Name = "Estres"
                },
                    new Pathology{
                    Id = Guid.NewGuid(),
                    Name = "Ansiedad"
                },
            };
            psycho = new Psychologist()
            {
                Id = Guid.NewGuid(),
                Name = "Joaquin Perez",
                // MeetingType = "presencial",
                MeetingType = 1,
                Address = "Julio cesar 1569",
                IsActive = true,
                Pathologies = patList1,
                StartDate = DateTime.Now.AddDays(-3),
                MeetingList = new SortedList<DateTime, int>()
            };

            Guid id = new Guid();
            consult = new Consultation()
            {
                Id = id,
                //MeetingType = 1,
                // MeetingLink = "www.esporahi.com",
                Date = DateTime.Now,
                UserCompleteName = "Juan manuel",
                UserBirthDate = "11/11/1994",
                UserCel = "099894147",
                UserEmail = "diego@gmail.com",
                Psychologist = psycho
            };

        }

        private void CreateDataBase(string name)
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: name)
            .Options;

            context = new DataContext(options);

            context.Set<Consultation>().Add(consult);
            context.SaveChanges();

            consultationRepo = new Repository<Consultation>(context);
        }

        [TestMethod]
        public void GetAllConsultations()
        {
            CreateDataBase("GetConsultationDB");
            int size = consultationRepo.GetAll().ToList().Count;
            Assert.AreEqual(1, size);
        }

        [TestMethod]
        public void GetConsultationById()
        {
            CreateDataBase("GetConsultationDB");
            var getConsultation = consultationRepo.Get(consult.Id);
            Assert.AreEqual(getConsultation.Id, consult.Id);
        }



        [TestMethod]
        public void InsertConsultation()
        {
            Guid id = new Guid();
            var consult2 = new Consultation()
            {
                Id = id,
                // MeetingType = 2,
                //MeetingLink = "www.googleMeet.com",
                Date = DateTime.Now,
                UserCompleteName = "Mario Lopez",
                UserBirthDate = "11/11/1980",
                UserCel = "099622538",
                UserEmail = "marioLo@gmail.com",
                Psychologist = psycho
            };

            CreateDataBase("InsertConsultationTestDB");
            consultationRepo.Create(consult2);
            consultationRepo.Save();
            int size = consultationRepo.GetAll().ToList().Count;
            Assert.AreEqual(2, size);
        }

        /*  [TestMethod]
          public void DeleteConsultation()
          {
              CreateDataBase("DeleteConsultationTestDB");
              consultationRepo.Delete(consult);
              consultationRepo.Save();
              int size = consultationRepo.GetAll().ToList().Count;
              Assert.AreEqual(0, size);
          }

          [TestMethod]
          public void UpdateConsultation()
          { 
              CreateDataBase("UpdateConsultationTestDB");
              var getAdmin = adminRepo.Get(admin.Id);
              Assert.AreEqual(getAdmin.Name,admin.Name);

              getAdmin.Email = "masadurian@gmail.com";
              adminRepo.Update(getAdmin);
              adminRepo.Save();

              var getAdminVerifi = adminRepo.Get(getAdmin.Id);
              Assert.AreEqual(getAdminVerifi.Id,getAdmin.Id);
              Assert.AreEqual(getAdmin.Email,"masadurian@gmail.com");

              int size = adminRepo.GetAll().ToList().Count;
              adminRepo.Save();
              Assert.AreEqual(1, size);

          }*/
    }

}
