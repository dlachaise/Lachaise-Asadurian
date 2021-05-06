
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic.Interface;
using MSP.BetterCalm.DataAccess.Interface;
using MSP.BetterCalm.Domain;
namespace MSP.BetterCalm.BusinessLogic.Test
{
    [TestClass]
    public class AdministratorLogicTest
    {
        private Mock<IAdministratorLogic> Mock;
        private Mock<IRepository<Administrator>> daMock;

        AdministratorLogic administratorLogic;

        [TestInitialize]
        public void Setup()
        {
            daMock = new Mock<IRepository<Administrator>>(MockBehavior.Strict);
            Mock = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            this.administratorLogic = new AdministratorLogic(daMock.Object);
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
        public void GetAllTestEmptyList()
        {

            List<Administrator> list = new List<Administrator>();
            daMock.Setup(x => x.GetAll()).Returns(list);

            IEnumerable<Administrator> ret = administratorLogic.GetAll();
            daMock.VerifyAll();
            Assert.IsTrue(ret.SequenceEqual(list));
        }

        [TestMethod]
        public void GetAdministratorByIdOk()
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
        [ExpectedException(typeof(Exception), "The administrator doesn't exists")]
        [TestMethod]
        public void GetAdministratorByIdFail()
        {
            Guid id = Guid.NewGuid();
            Administrator admin = null;
            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(admin);
            var ret = administratorLogic.Get(id);
            Assert.IsFalse(ret.Equals(admin));

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
            var updatedAdmin = new Administrator()
            {
                Id = id,
                Name = "Dominique Lachaise",
                Email = "dominique@gmail.com",
                Password = "admin1234",
                IsActive = true
            };
            daMock.Setup(x => x.Update(updatedAdmin));
            daMock.Setup(x => x.Save());

            administratorLogic.Update(id, updatedAdmin);

            daMock.VerifyAll();
            Assert.AreEqual(updatedAdmin.Name, "Dominique Lachaise");

        }
        [ExpectedException(typeof(Exception), "The administrator doesn't exists")]
        [TestMethod]
        public void AdministratorUpdateAdminNoExists()
        {
            Guid id = Guid.NewGuid();
            Administrator adm = null;
            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(adm);
            var updatedAdmin = new Administrator()
            {
                Id = id,
                Name = "Dominique Lachaise",
                Email = "dominique@gmail.com",
                Password = "admin1234",
                IsActive = true
            };

            daMock.Setup(x => x.Update(updatedAdmin));
            daMock.Setup(x => x.Save());
            administratorLogic.Update(id, updatedAdmin);
            Assert.AreNotEqual(adm,updatedAdmin);

        }


        [TestMethod]
        public void CreateAdministratorOk()
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
            daMock.Setup(x => x.Create(admin)).Verifiable();
            daMock.Setup(x => x.Save());
            List<Administrator> list = new List<Administrator>();
            daMock.Setup(x => x.GetAll()).Returns(list);
            administratorLogic.Create(admin);
            daMock.VerifyAll();
            Assert.AreEqual(admin.Name,"Dominique");

        }

        [ExpectedException(typeof(Exception), "The administrator exists")]
        [TestMethod]
        public void CreateAdministratorFailAlreadyExists()
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

            List<Administrator> list = new List<Administrator>();
            daMock.Setup(x => x.Create(admin)).Verifiable();
            daMock.Setup(x => x.Save());
            daMock.Setup(x => x.GetAll()).Returns(list);
            administratorLogic.Create(admin);
            list.Add(admin);
            daMock.Setup(x => x.GetAll()).Returns(list);
            administratorLogic.Create(admin);

           

        }

        [TestMethod]
        public void RemoveAdministratorOk()
        {
            Guid id = Guid.NewGuid();
            Administrator admin = new Administrator
            {
                Id = id,
                Name = "Dominique",
                Email = "domi@gmail.com",
                Password = "admin1234",
                IsActive = true
            };
            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(admin);
            daMock.Setup(m => m.Delete(admin));
            daMock.Setup(m => m.Save());

            administratorLogic.Delete(id);
            daMock.VerifyAll();

        }

        [ExpectedException(typeof(Exception), "The administrator doesn't exists")]
        [TestMethod]
        public void RemoveAdministratorFail()
        {
            Administrator adminNull = null;

            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(adminNull);
            daMock.Setup(m => m.Delete(adminNull));
            daMock.Setup(m => m.Save());

            administratorLogic.Delete(Guid.NewGuid());
        }


    }

}

