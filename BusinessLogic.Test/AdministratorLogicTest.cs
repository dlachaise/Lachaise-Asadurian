  
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Moq;
using Domain;
using BusinessLogic;
using DataAccess;
using System.Linq;

namespace BusinessLogic.Test
{
    [TestClass]
    public class AdministratorLoginTest
    {

        private DbContext context;
        private DbContextOptions options;

        [TestInitialize]
        public void Setup()
        {
        this.options = new DbContextOptionsBuilder<BetterCalmContext>().UseInMemoryDatabase(databaseName: "BetterCalmDBtest").Options;
        this.context = new VidlyContext(this.options);
        }
        
        [TestCleanup]
        public void TestCleanup()
        {
        this.context.Database.EnsureDeleted();
        }

        
        [TestMethod]
        public void GetAll()
        {
            Guid id = Guid.NewGuid();
            Administrator admin = new Administrator()
            {
                Id = id,
                Name = "Nicolas",
                Email = "nico@nico.com",
                Password = "hola123"
            };
            List<Administrator> list = new List<Administrator>();
            list.Add(admin);
            var mock = new Mock<IAdministratorRepository>(MockBehavior.Strict);

            mock.Setup(m => m.GetAll()).Returns(list);

            var admLogic = new AdministratorLogic(mock.Object);
            List<Administrator> result = admLogic.GetAll().ToList<Administrator>();

            mock.VerifyAll();
            Assert.IsTrue(result.Any(p => p.Id == id));
        }

}
}
