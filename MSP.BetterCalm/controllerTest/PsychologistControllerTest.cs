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
    public class PsychologistControllerTest
    {

        private Mock<IPsychologistLogic> Mock;
        private Mock<ISessionLogic> SessionMock;
        private PsychologistController controller;
        IEnumerable<Psychologist> psychoList;

        PsychologistDTO psychoDTO1;
        Psychologist psycho1;
        Guid token;

        [TestInitialize]
        public void Setup()
        {

            Mock = new Mock<IPsychologistLogic>(MockBehavior.Strict);
            SessionMock = new Mock<SessionLogic>(MockBehavior, Strict);
            controller = new PsychologistController(Mock.Object);
            psycho1 = new Psychologist
            {
                Id = Guid.NewGuid(),
                Name = "Alvaro Perez",
                IsActive = true,

            };
            psychoDTO1 = new PsychologistDTO(psycho1);

            psychoList = new List<Psychologist>{
                psycho1,
                    new Psychologist{
                    Id = Guid.NewGuid(),
                Name = "Alvarito",
                IsActive = true,
                },
            };
        }

        [TestMethod]
        public void GetPsychologistOK()
        {

            Mock.Setup(psychologistLogic => psychologistLogic.GetAll()).Returns(psychoList);

            var result = controller.Get();
            var OkResult = result as OkObjectResult;
            var controllerAdmins = OkResult.Value as IEnumerable<PsychologistDTO>; ;
            var statusCode = OkResult.StatusCode;

            Mock.VerifyAll();

            Assert.IsTrue(psychoList.Select(psycho => new PsychologistDTO(psycho)).SequenceEqual(controllerAdmins));
            Assert.AreEqual(200, statusCode);


        }


        [TestMethod]
        public void GetByIdOK()
        {

            Mock.Setup(psychologistLogic => psychologistLogic.Get(It.IsAny<Guid>())).Returns(psycho1);

            var result = controller.Get(It.IsAny<Guid>());
            var okResult = result as OkObjectResult;
            var controllerAdmin = okResult.Value as PsychologistDTO;
            var statusCode = okResult.StatusCode;

            Mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
            Assert.IsTrue(new PsychologistDTO(psycho1).Equals(controllerAdmin));
        }

        [TestMethod]
        public void GetByIdNotExist()
        {


            Psychologist psycho = null;

            Mock.Setup(psychoLogic => psychoLogic.Get(It.IsAny<Guid>())).Returns(psycho);

            var result = controller.Get(It.IsAny<Guid>());
            var okResult = result as NotFoundObjectResult;
            var statusCode = okResult.StatusCode;

            Mock.VerifyAll();
            Assert.AreEqual(404, statusCode);

        }


        [TestMethod]
        public void PostPsychologistOK()
        {
            Mock.Setup(psychoLogic => psychoLogic.Create(It.IsAny<Psychologist>())).Returns(psycho1);

            var result = controller.Post(psychoDTO1);
            var okResult = result as OkObjectResult;
            var psychoAdded = okResult.Value as PsychologistDTO;

            Mock.VerifyAll();

            Assert.IsTrue(psychoAdded.Equals(psychoDTO1));

        }


        [TestMethod]
        public void PutTouristSpotNotExist()
        {


            Mock.Setup(touristSpotlogic => touristSpotlogic.Update(It.IsAny<Guid>(), It.IsAny<Psychologist>())).Throws(new Exception());

            var result = controller.Put(psycho1.Id, psychoDTO1);

            var okResult = result as NotFoundObjectResult;

            Mock.VerifyAll();

            Assert.AreEqual(404, okResult.StatusCode);
        }

        [TestMethod]
        public void DeleteOK()
        {
            Mock.Setup(psychoLogic => psychoLogic.Delete(It.IsAny<Guid>())).Verifiable();

            var result = controller.Delete(Guid.NewGuid());
            var okResult = result as OkObjectResult;
            Mock.VerifyAll();

        }

        [TestMethod]
        public void DeleteIdNotExist()
        {


            Mock.Setup(psychoLogic => psychoLogic.Delete(It.IsAny<Guid>())).Throws(new Exception());

            var result = controller.Delete(Guid.NewGuid());

            var okResult = result as NotFoundObjectResult;

            Mock.VerifyAll();

            Assert.AreEqual(404, okResult.StatusCode);

        }

    }
}