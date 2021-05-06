using MSP.BetterCalm.BusinessLogic.Interface;
using System.Linq;
using MSP.BetterCalm.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using MSP.BetterCalm.WebApi.Controllers;
using MSP.BetterCalm.WebApi.Models;


namespace MSP.BetterCalm.WebApi.Test
{
    [TestClass]
    public class AudioControllerTest
    {

        private Mock<IAudioLogic> Mock;
        private AudioController controller;
        IEnumerable<Audio> audioList;

        AudioDTO audioDTO1;
        Audio audio1;

        [TestInitialize]
        public void Setup()
        {

            Mock = new Mock<IAudioLogic>(MockBehavior.Strict);
            controller = new AudioController(Mock.Object);
            audio1 = new Audio
            {
                Id = Guid.NewGuid(),
                Name = "Ven Miente",
                Duration = 150,
                IsActive = true,

            };
            audioDTO1 = new AudioDTO(audio1);

            audioList = new List<Audio>{
                audio1,
                    new Audio{
                     Id = Guid.NewGuid(),
                Name = "Gaucho",
                Duration = 150,
                IsActive = true,
                },
            };
        }

        [TestMethod]
        public void GetAudiosOK()
        {

            Mock.Setup(audioLogic => audioLogic.GetAll()).Returns(audioList);

            var result = controller.Get();
            var OkResult = result as OkObjectResult;
            var controllerAdmins = OkResult.Value as IEnumerable<AudioDTO>; ;
            var statusCode = OkResult.StatusCode;

            Mock.VerifyAll();

            Assert.IsTrue(audioList.Select(audio => new AudioDTO(audio)).SequenceEqual(controllerAdmins));
            Assert.AreEqual(200, statusCode);


        }


        [TestMethod]
        public void GetByIdOK()
        {

            Mock.Setup(audioLogic => audioLogic.Get(It.IsAny<Guid>())).Returns(audio1);

            var result = controller.Get(It.IsAny<Guid>());
            var okResult = result as OkObjectResult;
            var controllerAdmin = okResult.Value as AudioDTO;
            var statusCode = okResult.StatusCode;

            Mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
            Assert.IsTrue(new AudioDTO(audio1).Equals(controllerAdmin));
        }


        [TestMethod]
        public void GetByIdNotExist()
        {

            Audio audio = null;

            Mock.Setup(audioLogic => audioLogic.Get(It.IsAny<Guid>())).Returns(audio);

            var result = controller.Get(It.IsAny<Guid>());
            var okResult = result as NotFoundObjectResult;
            var statusCode = okResult.StatusCode;

            Mock.VerifyAll();
            Assert.AreEqual(404, statusCode);

        }


        [TestMethod]
        public void PostAudioOK()
        {
            Mock.Setup(audioLogic => audioLogic.Create(It.IsAny<Audio>())).Returns(audio1);

            var result = controller.Post(audioDTO1);
            var okResult = result as OkObjectResult;
            var audioAdded = okResult.Value as AudioDTO;

            Mock.VerifyAll();

            Assert.IsTrue(audioAdded.Equals(audioDTO1));

        }


        [TestMethod]
        public void PutAudioNotExist()
        {


            Mock.Setup(touristSpotlogic => touristSpotlogic.Update(It.IsAny<Guid>(), It.IsAny<Audio>())).Throws(new Exception());

            var result = controller.Put(audio1.Id, audioDTO1);

            var okResult = result as NotFoundObjectResult;

            Mock.VerifyAll();

            Assert.AreEqual(404, okResult.StatusCode);
        }

        [TestMethod]
        public void DeleteOK()
        {
            Mock.Setup(audioLogic => audioLogic.Delete(It.IsAny<Guid>())).Verifiable();

            var result = controller.Delete(Guid.NewGuid());
            var okResult = result as OkObjectResult;
            Mock.VerifyAll();

        }

        [TestMethod]
        public void DeleteIdNotExist()
        {


            Mock.Setup(audLogic => audLogic.Delete(It.IsAny<Guid>())).Throws(new Exception());

            var result = controller.Delete(Guid.NewGuid());

            var okResult = result as NotFoundObjectResult;

            Mock.VerifyAll();

            Assert.AreEqual(404, okResult.StatusCode);

        }

    }
}