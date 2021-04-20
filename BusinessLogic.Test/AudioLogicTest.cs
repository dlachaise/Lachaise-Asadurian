
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
    public class AudioLogicTest
    {
        private Mock<IAudioLogic> Mock;
        private Mock<IAudioRepository> daMock;

        AudioLogic audioLogic;

        [TestInitialize]
        public void Setup()
        {
            daMock = new Mock<IAudioRepository>(MockBehavior.Strict);
            Mock = new Mock<IAudioLogic>(MockBehavior.Strict);
            this.audioLogic = new AudioLogic(daMock.Object, Mock.Object);
        }

        [TestMethod]
        public void GetAllAudios()
        {
            Guid id = Guid.NewGuid();
            Audio audio = new Audio()
            {
                Id = id,
                Name = "Loco por vos",
                Duration = 120,
                CreatorName = "Chili Fernandez",
                ImageUrl = "/Desktop/ImagenesAudio/LocoPorVos.png",
                AudioUrl = "www.betterCalm.com.uy/LocoPorVos.mp3" ,
                IsActive = true
            };
            List<Audio> list = new List<Audio>();
            list.Add(audio);
            daMock.Setup(x => x.GetAll()).Returns(list);

            IEnumerable<Audio> ret = audioLogic.GetAll();
            daMock.VerifyAll();
            Assert.IsTrue(ret.SequenceEqual(list));
        }
        [TestMethod]
        public void GetAllTestEmptyList()
        {
/*
            List<Administrator> list = new List<Administrator>();
            daMock.Setup(x => x.GetAll()).Returns(list);

            IEnumerable<Administrator> ret = administratorLogic.GetAll();
            daMock.VerifyAll();*
            Assert.IsTrue(ret.SequenceEqual(list));*/
        }

        [TestMethod]
        public void GetAdministratorByIdOk()
        {
           /* Guid id = Guid.NewGuid();
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
            Assert.IsTrue(ret.Equals(admin));*/

        }
        [ExpectedException(typeof(Exception), "The administrator doesn't exists")]
        [TestMethod]
        public void GetAdministratorByIdFail()
        {
            Guid id = Guid.NewGuid();
            Administrator admin = null;
            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(admin);
            var ret = administratorLogic.Get(id);

        }

        [TestMethod]
        public void AdministratorUpdateOk()
        {
           /* Guid id = Guid.NewGuid();
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

            daMock.VerifyAll();*/

        }
        [ExpectedException(typeof(Exception), "The administrator doesn't exists")]
        [TestMethod]
        public void AdministratorUpdateAdminNoExists()
        {
            /*Guid id = Guid.NewGuid();
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
            administratorLogic.Update(id, updatedAdmin);*/
        }


        [TestMethod]
        public void CreateAdministratorOk()
        {
            /*Guid id = Guid.NewGuid();
            var admin = new Administrator()
            {
                Id = id,
                Name = "Dominique",
                Email = "domi@gmail.com",
                Password = "admin1234",
                IsActive = true
            };
            daMock.Setup(x => x.Add(admin)).Verifiable();
            daMock.Setup(x => x.Save());
            List<Administrator> list = new List<Administrator>();
            daMock.Setup(x => x.GetAll()).Returns(list);
            administratorLogic.Create(admin);
            daMock.VerifyAll();*/

        }

        [ExpectedException(typeof(Exception), "The administrator doesn't exists")]
        [TestMethod]
        public void CreateAdministratorFailAlreadyExists()
        {
           /* Guid id = Guid.NewGuid();
            var admin = new Administrator()
            {
                Id = id,
                Name = "Dominique",
                Email = "domi@gmail.com",
                Password = "admin1234",
                IsActive = true
            };

            List<Administrator> list = new List<Administrator>();
            daMock.Setup(x => x.Add(admin)).Verifiable();
            daMock.Setup(x => x.Save());
            daMock.Setup(x => x.GetAll()).Returns(list);
            administratorLogic.Create(admin);
            list.Add(admin);
            daMock.Setup(x => x.GetAll()).Returns(list);
            administratorLogic.Create(admin);*/

        }

        [TestMethod]
        public void RemoveAdministratorOk()
        {
          /*  Guid id = Guid.NewGuid();
            Administrator admin = new Administrator
            {
                Id = id,
                Name = "Dominique",
                Email = "domi@gmail.com",
                Password = "admin1234",
                IsActive = true
            };
            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(admin);
            daMock.Setup(m => m.Remove(admin));
            daMock.Setup(m => m.Save());

            administratorLogic.Delete(id);
            daMock.VerifyAll();*/
        }

        [ExpectedException(typeof(Exception), "The administrator doesn't exists")]
        [TestMethod]
        public void RemoveAdministratorFail()
        {
            /*Administrator adminNull = null;

            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(adminNull);
            daMock.Setup(m => m.Remove(adminNull));
            daMock.Setup(m => m.Save());

            administratorLogic.Delete(Guid.NewGuid());*/
        }


    }

}

