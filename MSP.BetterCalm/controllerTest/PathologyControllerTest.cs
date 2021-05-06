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
    public class PathologyControllerTest
    {

        private Mock<IPathologyLogic> Mock;
        private PathologyController controller;
        IEnumerable<Pathology> patList;

        PathologyDTO patDTO1;
        Pathology pat1;

        [TestInitialize]
        public void Setup()
        {

            Mock = new Mock<IPathologyLogic>(MockBehavior.Strict);
            controller = new PathologyController(Mock.Object);
            pat1 = new Pathology
            {
                Id = Guid.NewGuid(),
                Name = "Separacion",

            };
            patDTO1 = new PathologyDTO(pat1);

            patList = new List<Pathology>{
                pat1,
                    new Pathology{
                    Id = Guid.NewGuid(),
                    Name = "Estres"
                },
            };
        }

        [TestMethod]
        public void GetPathologyOK()
        {

            Mock.Setup(pathologyLogic => pathologyLogic.GetAll()).Returns(patList);

            var result = controller.Get();
            var OkResult = result as OkObjectResult;
            var controllerAdmins = OkResult.Value as IEnumerable<PathologyDTO>; ;
            var statusCode = OkResult.StatusCode;

            Mock.VerifyAll();

            Assert.IsTrue(patList.Select(pat => new PathologyDTO(pat)).SequenceEqual(controllerAdmins));
            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        public void GetByIdOK()
        {

            Mock.Setup(pathologyLogic => pathologyLogic.Get(It.IsAny<Guid>())).Returns(pat1);

            var result = controller.Get(It.IsAny<Guid>());
            var okResult = result as OkObjectResult;
            var controllerAdmin = okResult.Value as PathologyDTO;
            var statusCode = okResult.StatusCode;

            Mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
            Assert.IsTrue(new PathologyDTO(pat1).Equals(controllerAdmin));
        }

        [TestMethod]
        public void GetByIdNotExist()
        {


            Pathology pat = null;

            Mock.Setup(patLogic => patLogic.Get(It.IsAny<Guid>())).Returns(pat);

            var result = controller.Get(It.IsAny<Guid>());
            var okResult = result as NotFoundObjectResult;
            var statusCode = okResult.StatusCode;

            Mock.VerifyAll();
            Assert.AreEqual(404, statusCode);

        }

    }
}