using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

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
        public void GetAdministrator()
        {
            CreateDataBase("GetAdministratorDB");
            int size = adminRepo.GetAll().ToList().Count;
            Assert.AreEqual(1, size);
        }

/*
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
        { //ACA NO DEBERIA ACTUALIZAR ALGUN DATO DEL ADMIN??? 
            CreateDataBase("UpdateAdministratorTestDB");
            int size = adminRepo.GetAll().ToList().Count;
            adminRepo.Save();
            Assert.AreEqual(1, size);
        }
   */ }

}
