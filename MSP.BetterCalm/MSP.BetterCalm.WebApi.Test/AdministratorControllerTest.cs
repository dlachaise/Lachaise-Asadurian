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
    public class AdministratorControllerTest
    {

        private Mock<IAdministratorLogic> Mock;
        private AdministratorController controller;
        IEnumerable<Administrator> adminList;

        AdministratorDTO adminDTO1;
        Administrator admin1;

        [TestInitialize]
        public void Setup()
        {

            Mock = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            controller = new AdministratorController(Mock.Object);
            admin1 = new Administrator
            {
                Id = Guid.NewGuid(),
                Name = "Alvaro Perez",
                Email = "Aalvaro@gmail.com",
                Password = "alvaro123"
            };
            adminDTO1 = new AdministratorDTO(admin1);

            adminList = new List<Administrator>{
                admin1,
                    new Administrator{
                    Id = Guid.NewGuid(),
                    Name = "Julia Terra"
                },
            };
        }

        [TestMethod]
        public void GetAdministratorOK()
        {

            Mock.Setup(administratorLogic => administratorLogic.GetAll()).Returns(adminList);

            var result = controller.Get();
            var OkResult = result as OkObjectResult;
            var controllerAdmins = OkResult.Value as IEnumerable<AdministratorDTO>; ;
            var statusCode = OkResult.StatusCode;

            Mock.VerifyAll();

            Assert.IsTrue(adminList.Select(admin => new AdministratorDTO(admin)).SequenceEqual(controllerAdmins));
            Assert.AreEqual(200, statusCode);


        }


        [TestMethod]
        public void GetByIdOK()
        {

            Mock.Setup(administratorLogic => administratorLogic.Get(It.IsAny<Guid>())).Returns(admin1);

            var result = controller.Get(It.IsAny<Guid>());
            var okResult = result as OkObjectResult;
            var controllerAdmin = okResult.Value as AdministratorDTO;
            var statusCode = okResult.StatusCode;

            Mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
            Assert.IsTrue(new AdministratorDTO(admin1).Equals(controllerAdmin));
        }

        [TestMethod]
        public void GetByIdNotExist()
        {


            Administrator admin = null;

            Mock.Setup(adminLogic => adminLogic.Get(It.IsAny<Guid>())).Returns(admin);

            var result = controller.Get(It.IsAny<Guid>());
            var okResult = result as NotFoundObjectResult;
            var statusCode = okResult.StatusCode;

            Mock.VerifyAll();
            Assert.AreEqual(404, statusCode);

        }


        [TestMethod]
        public void PostAdministratorOK()
        {
            Mock.Setup(adminLogic => adminLogic.Create(It.IsAny<Administrator>())).Returns(admin1);

            var result = controller.Post(adminDTO1);
            var okResult = result as OkObjectResult;
            var adminAdded = okResult.Value as AdministratorDTO;

            Mock.VerifyAll();

            Assert.IsTrue(adminAdded.Equals(adminDTO1));

        }


        [TestMethod]
        public void PutTouristSpotNotExist()
        {


            Mock.Setup(touristSpotlogic => touristSpotlogic.Update(It.IsAny<Guid>(), It.IsAny<Administrator>())).Throws(new Exception());

            var result = controller.Put(admin1.Id, adminDTO1);

            var okResult = result as NotFoundObjectResult;

            Mock.VerifyAll();

            Assert.AreEqual(404, okResult.StatusCode);
        }

        [TestMethod]
        public void DeleteOK()
        {
            Mock.Setup(adminLogic => adminLogic.Delete(It.IsAny<Guid>())).Verifiable();

            var result = controller.Delete(Guid.NewGuid());
            var okResult = result as OkObjectResult;
            Mock.VerifyAll();

        }

        [TestMethod]
        public void DeleteIdNotExist()
        {


            Mock.Setup(admLogic => admLogic.Delete(It.IsAny<Guid>())).Throws(new Exception());

            var result = controller.Delete(Guid.NewGuid());

            var okResult = result as NotFoundObjectResult;

            Mock.VerifyAll();

            Assert.AreEqual(404, okResult.StatusCode);

        }

    }
}
















//     }
// }
