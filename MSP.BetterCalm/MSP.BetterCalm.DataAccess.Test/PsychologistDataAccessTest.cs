using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess.Test
{
    [TestClass]
    public class PsychologistDataAccessTest
    {
        private DataContext context;
        private Psychologist psychologist;
        private Repository<Psychologist> psychologistRepo;

        [TestInitialize]
        public void InitTest()
        {

            SortedList<DateTime, int> meetings = new SortedList<DateTime, int>();
            meetings.Add(DateTime.Now, 2);

            Guid id = new Guid();
            List<Pathology> patList1 = new List<Pathology>{
                new Pathology{
                    Id = Guid.NewGuid(),
                    Name = "Estres"
                }
            };

            psychologist = new Psychologist()
            {
                Id = id,
                Name = "Joaquin Perez",
                MeetingType = 2,
                Address = "Julio cesar 1569",
                IsActive = true,
                Pathologies = patList1,
                MeetingList = meetings,
                StartDate = DateTime.Now.AddDays(-3)

            };

        }

        private void CreateDataBase(string name)
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: name)
            .Options;

            context = new DataContext(options);

            context.Set<Psychologist>().Add(psychologist);
            context.SaveChanges();

            psychologistRepo = new Repository<Psychologist>(context);
        }

        [TestMethod]
        public void GetAllPsychologist()
        {
            CreateDataBase("GetPsychologistTestDB");
            int size = psychologistRepo.GetAll().ToList().Count;
            Assert.AreEqual(1, size);
        }


        [TestMethod]
        public void GetPsychologistById()
        {
            CreateDataBase("GetPsychologistDB");
            var getPsychologist = psychologistRepo.Get(psychologist.Id);
            Assert.AreEqual(getPsychologist.Id, psychologist.Id);
        }


        [TestMethod]
        public void InsertPsychologist()
        {
            SortedList<DateTime, int> meetings = new SortedList<DateTime, int>();
            meetings.Add(DateTime.Now, 2);

            Guid id1 = new Guid();
            Guid id2 = new Guid();
            List<Pathology> patList2 = new List<Pathology>{
                new Pathology{
                    Id = id1,
                    Name = "Ansiedad"
                }
            };

            var psychologist2 = new Psychologist()
            {
                Id = id2,
                Name = "Maria Ines",
                MeetingType = 1,
                Address = "Av River 5544",
                IsActive = true,
                Pathologies = patList2,
                MeetingList = meetings,
                StartDate = DateTime.Now.AddDays(-3)
            };

            CreateDataBase("InsertPsychologistTestDB");
            psychologistRepo.Create(psychologist2);
            psychologistRepo.Save();
            int size = psychologistRepo.GetAll().ToList().Count;
            Assert.AreEqual(2, size);
        }

        [TestMethod]
        public void DeletePsychologist()
        {
            CreateDataBase("DeletePsychologistTestDB");
            psychologistRepo.Delete(psychologist);
            psychologistRepo.Save();
            int size = psychologistRepo.GetAll().ToList().Count;
            Assert.AreEqual(0, size);
        }

        [TestMethod]
        public void UpdatePsychologist()
        {
            CreateDataBase("UpdatePsychologoTestDB");
            var getPsycho = psychologistRepo.Get(psychologist.Id);
            Assert.AreEqual(getPsycho.Name, psychologist.Name);

            getPsycho.Address = "Feliciano Rodriguez 1225";
            psychologistRepo.Update(getPsycho);
            psychologistRepo.Save();

            var getAdminVerifi = psychologistRepo.Get(getPsycho.Id);
            Assert.AreEqual(getAdminVerifi.Id, getPsycho.Id);
            Assert.AreEqual(getPsycho.Address, "Feliciano Rodriguez 1225");

            int size = psychologistRepo.GetAll().ToList().Count;
            psychologistRepo.Save();
            Assert.AreEqual(1, size);
        }
    }

}
