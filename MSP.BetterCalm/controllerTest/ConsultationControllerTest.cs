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
    public class ConsultationControllerTest
    {

        private Mock<IConsultationLogic> Mock;
        private ConsultationController controller;
        IEnumerable<Consultation> consList;

        ConsultationDTO consDTO1;
        Consultation cons1;

        [TestInitialize]
        public void Setup()
        {

            Mock = new Mock<IConsultationLogic>(MockBehavior.Strict);
            controller = new ConsultationController(Mock.Object);
            cons1 = new Consultation
            {
                Id = Guid.NewGuid(),
                MeetingType = 1,
                Date = DateTime.Now,
                UserEmail = "domi.lachaise@hotmail.com"
            };
            consDTO1 = new ConsultationDTO(cons1);

            consList = new List<Consultation>{
                cons1,
                    new Consultation{
                    Id = Guid.NewGuid(),
                    MeetingType = 1,
                Date = DateTime.Now,
                UserEmail = "domie@hotmail.com"
                },
            };
        }




        [TestMethod]
        public void GetByIdOK()
        {

            Mock.Setup(consistratorLogic => consistratorLogic.Get(It.IsAny<Guid>())).Returns(cons1);

            var result = controller.Get(It.IsAny<Guid>());
            var okResult = result as OkObjectResult;
            var controllerAdmin = okResult.Value as ConsultationDTO;
            var statusCode = okResult.StatusCode;

            Mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
            Assert.IsTrue(new ConsultationDTO(cons1).Equals(controllerAdmin));
        }

        [TestMethod]
        public void GetByIdNotExist()
        {


            Consultation cons = null;

            Mock.Setup(consLogic => consLogic.Get(It.IsAny<Guid>())).Returns(cons);

            var result = controller.Get(It.IsAny<Guid>());
            var okResult = result as NotFoundObjectResult;
            var statusCode = okResult.StatusCode;

            Mock.VerifyAll();
            Assert.AreEqual(404, statusCode);

        }


        [TestMethod]
        public void PostConsultationOK()
        {
            Mock.Setup(consLogic => consLogic.Create(It.IsAny<Consultation>())).Returns(cons1);

            var result = controller.Post(consDTO1);
            var okResult = result as OkObjectResult;
            var consAdded = okResult.Value as ConsultationDTO;

            Mock.VerifyAll();

            Assert.IsTrue(consAdded.Equals(consDTO1));

        }

    }
}