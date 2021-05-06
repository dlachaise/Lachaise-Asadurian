using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess.Test
{
    [TestClass]
    public class AdministratorDataAccessTest
    {
        private DataContext context;
        private Administrator admin;
        private Repository<Administrator> adminRepo;

        [TestInitialize]
        public void InitTest()
        {
            Guid id = new Guid();
            admin = new Administrator()
            {
                Id = id,
                Name = "Martin",
                Email = "martinasa@gmail.com",
                Password = "admin1234",
                IsActive = true
            };

        }

        private void CreateDataBase(string name)
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: name)
            .Options;

            context = new DataContext(options);

            context.Set<Administrator>().Add(admin);
            context.SaveChanges();

            adminRepo = new Repository<Administrator>(context);
        }

        [TestMethod]
        public void GetAllAdministrator()
        {
            CreateDataBase("GetAdministratorDB");
            int size = adminRepo.GetAll().ToList().Count;
            Assert.AreEqual(2, size);
        }

        [TestMethod]
        public void GetAdministratorById()
        {
            CreateDataBase("GetAdministratorDB");
            var getAdmin = adminRepo.Get(admin.Id);
            Assert.AreEqual(getAdmin.Id, admin.Id);
        }



        [TestMethod]
        public void InsertAdministrator()
        {
            Guid id = new Guid();
            Administrator admin = new Administrator()
            {
                Id = id,
                Name = "Diego",
                Email = "diego@gmail.com",
                Password = "admin1234",
                IsActive = true
            };

            CreateDataBase("InsertAdministratorTestDB");
            adminRepo.Create(admin);
            adminRepo.Save();
            int size = adminRepo.GetAll().ToList().Count;
            Assert.AreEqual(2, size);
        }

        [TestMethod]
        public void DeleteAdministrator()
        {
            CreateDataBase("DeleteAdministratorTestDB");
            adminRepo.Delete(admin);
            adminRepo.Save();
            int size = adminRepo.GetAll().ToList().Count;
            Assert.AreEqual(0, size);
        }

        [TestMethod]
        public void UpdateAdministrator()
        {
            CreateDataBase("UpdateAdministratorTestDB");
            var getAdmin = adminRepo.Get(admin.Id);
            Assert.AreEqual(getAdmin.Name, admin.Name);

            getAdmin.Email = "masadurian@gmail.com";
            adminRepo.Update(getAdmin);
            adminRepo.Save();

            var getAdminVerifi = adminRepo.Get(getAdmin.Id);
            Assert.AreEqual(getAdminVerifi.Id, getAdmin.Id);
            Assert.AreEqual(getAdmin.Email, "masadurian@gmail.com");

            int size = adminRepo.GetAll().ToList().Count;
            adminRepo.Save();
            Assert.AreEqual(1, size);

        }
    }

}
