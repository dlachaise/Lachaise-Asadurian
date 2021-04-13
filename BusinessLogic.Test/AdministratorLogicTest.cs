
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Moq;
using Domain;
using BusinessLogic;
using BusinessLogicInterface;
using DataAccess;
using System.Linq;
namespace BusinessLogic.Test
{
    [TestClass]
    public class AdministratorLoginTest
    {
       private Mock<IAdministratorLogic> Mock;
        private Mock<IAdministratorRepository> daMock;
    
        AdministratorLogic administratorLogic;

        [TestInitialize]
        public void Setup()
        {
            daMock = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            Mock = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            this.administratorLogic = new AdministratorLogic(daMock.Object, Mock.Object);
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
                Password = "hola123",
                IsActive = true
            };
            List<Administrator> list = new List<Administrator>();
            list.Add(admin);
            daMock.Setup(x => x.GetAll()).Returns(list);

            IEnumerable<Administrator> ret = administratorLogic.GetAll();
            daMock.VerifyAll();
            Assert.IsTrue(ret.SequenceEqual(list));
        }

    [TestMethod]
        public void GetAdministratorById()
        {
            Guid id = Guid.NewGuid();
            var admin = new Administrator()
            {
                Id = id,
                Name = "Diego",
                Email = "diego@gmail.com",
                Password = "admin1234",
                IsActive = true
            };

            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(admin);
            
            var ret = administratorLogic.Get(id);
            daMock.VerifyAll();
            Assert.IsTrue(ret.Equals(admin));

        }

        [TestMethod]
        public void AdministratorUpdateOk()
        {            
            Guid id = Guid.NewGuid();
            var admin = new Administrator()
            {
                 Id = id,
                Name = "Dominique",
                Email = "domi@gmail.com",
                Password = "admin1234",
                IsActive = true
            };


            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(admin);
            daMock.Setup(x => x.Update(id,admin)).Verifiable();
            daMock.Setup(x => x.Save());

            administratorLogic.Update(id,admin);

            daMock.VerifyAll();

        }


    }
    
}

