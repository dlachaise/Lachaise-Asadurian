
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
        Mock<IAdministratorRepository<Administrator>> daMock;
        AdministradorLogic administratorLogic;

        [TestInitialize]
        public void Setup()
        {
            this.daMock = new Mock<IAdministratotRepository<Administrator>>(MockBehavior.Strict);
            this.administratorLogic = new AdministratorLogic(daMock.Object, Mock.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.context.Database.EnsureDeleted();
        }


        [TestMethod]
        public void GetAllTest()
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
            daMock.Setup(x => x.GetAll()).Returns(list);

            IEnumerable<TouristSpot> ret = administratorLogic.GetAll();
            daMock.VerifyAll();
            Assert.IsTrue(ret.SequenceEqual(touristSpotList));
        }

    }
}
