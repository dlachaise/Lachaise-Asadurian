
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Moq;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Interface;
using MSP.BetterCalm.DataAccess.Interface;
using System.Linq;
namespace MSP.BetterCalm.BusinessLogic.Test
{
    [TestClass]
    public class PathologyLogicTest
    {
        private Mock<IPathologyLogic> Mock;
        private Mock<IRepository<Pathology>> daMock;

        PathologyLogic pathologyLogic;

        [TestInitialize]
        public void Setup()
        {
            daMock = new Mock<IRepository<Pathology>>(MockBehavior.Strict);
            Mock = new Mock<IPathologyLogic>(MockBehavior.Strict);
            this.pathologyLogic = new PathologyLogic(daMock.Object);
        }

        [TestMethod]
        public void GetAllPathologys()
        {
            Guid id = Guid.NewGuid();
            var pathology = new Pathology()
            {
                Id = id,
                Name = "Estres"
            };
            List<Pathology> list = new List<Pathology>();
            list.Add(pathology);
            daMock.Setup(x => x.GetAll()).Returns(list);

            IEnumerable<Pathology> ret = pathologyLogic.GetAll();
            daMock.VerifyAll();
            Assert.IsTrue(ret.SequenceEqual(list));
        }

        [TestMethod]
        public void GetPathologyByIdOk()
        {
            Guid id = Guid.NewGuid();
            var pathology = new Pathology()
            {
                Id = id,
                Name = "Ansiedad"
            };

            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(pathology);

            var ret = pathologyLogic.Get(id);
            daMock.VerifyAll();
            Assert.IsTrue(ret.Equals(pathology));

        }

        [ExpectedException(typeof(Exception), "The Pathology doesn't exists")]
        [TestMethod]
        public void GetPathologyByIdFail()
        {
            Guid id = Guid.NewGuid();
            Pathology pathology = null;
            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(pathology);
            var ret = pathologyLogic.Get(id);

        }
    }
}

