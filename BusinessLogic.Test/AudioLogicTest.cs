
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
            var audio = new Audio()
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
        public void GetAudioByIdOk()
        {
            Guid id = Guid.NewGuid();
            var audio = new Audio()
            {
                Id = id,
                Name = "Dime si eres feliz",
                Duration = 135,
                CreatorName = "La Champions Liga",
                ImageUrl = "/Desktop/ImagenesAudio/DimeSiEres.png",
                AudioUrl = "www.betterCalm.com.uy/DimeSiEres.mp3" ,
                IsActive = true
            };

            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(audio);

            var ret = audioLogic.Get(id);
            daMock.VerifyAll();
            Assert.IsTrue(ret.Equals(audio));

        }
        [TestMethod]
        public void RemoveAudioOk()
        {
            Guid id = Guid.NewGuid();
            var audio = new Audio()
            {
                Id = id,
                Name = "Mia",
                Duration = 151,
                CreatorName = "18 Kilates",
                ImageUrl = "/Desktop/ImagenesAudio/Mia.png",
                AudioUrl = "www.betterCalm.com.uy/Mia.mp3" ,
                IsActive = true
            };
            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(audio);
            daMock.Setup(m => m.Remove(audio));
            daMock.Setup(m => m.Save());

            audioLogic.Delete(id);
            daMock.VerifyAll();
        }

        [TestMethod]
        public void GetAllTestEmptyList()
        {

            List<Audio> list = new List<Audio>();
            daMock.Setup(x => x.GetAll()).Returns(list);

            IEnumerable<Audio> ret = audioLogic.GetAll();
            daMock.VerifyAll();
            Assert.IsTrue(ret.SequenceEqual(list));
        }


         [TestMethod]
        public void CreateAudioOk()
        {
            Guid id = Guid.NewGuid();
            var audio = new Audio()
            {
                Id = id,
                Name = "Eres Mia",
                Duration = 124,
                CreatorName = "Rome Santos",
                ImageUrl = "/Desktop/ImagenesAudio/EresMia.png",
                AudioUrl = "www.betterCalm.com.uy/EresMia.mp3" ,
                IsActive = true
            };
            daMock.Setup(x => x.Add(audio)).Verifiable();
            daMock.Setup(x => x.Save());
                         
            audioLogic.CreateAudio(audio);
            daMock.VerifyAll();

        }

        [ExpectedException(typeof(Exception), "The Audio doesn't exists")]
        [TestMethod]
        public void RemoveAudioFail()
        {
            Audio audioNull = null;

            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(audioNull);
            daMock.Setup(m => m.Remove(audioNull));
            daMock.Setup(m => m.Save());

            audioLogic.Delete(Guid.NewGuid());
        }

         [ExpectedException(typeof(Exception), "The audio doesn't exists")]
        [TestMethod]
        public void GetAudioByIdFail()
        {
            Guid id = Guid.NewGuid();
            Audio audio = null;
            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(audio);
            var ret = audioLogic.Get(id);

        }

     /*      

        [ExpectedException(typeof(Exception), "The administrator doesn't exists")]
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
            daMock.Setup(x => x.Add(admin)).Verifiable();
            daMock.Setup(x => x.Save());
            daMock.Setup(x => x.GetAll()).Returns(list);
            administratorLogic.Create(admin);
            list.Add(admin);
            daMock.Setup(x => x.GetAll()).Returns(list);
            administratorLogic.Create(admin);

        }
*/
    }

}

