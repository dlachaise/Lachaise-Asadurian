
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
    public class PsychologistLoginTest
    {
        private Mock<IPsychologistLogic> Mock;
        private Mock<IPsychologistRepository> daMock;

        PsychologistLogic psychologistLogic;
        Psychologist psyco1, psyco2, psyco3;
        IEnumerable<Pathology> patList1, patList2, patList3;

        [TestInitialize]
        public void Setup()
        {
            daMock = new Mock<IPsychologistRepository>(MockBehavior.Strict);
            Mock = new Mock<IPsychologistLogic>(MockBehavior.Strict);
            this.psychologistLogic = new PsychologistLogic(daMock.Object, Mock.Object);
            patList1 = new List<Pathology>{
                new Pathology{
                    Id = Guid.NewGuid(),
                    Name = "Estres"
                },
                    new Pathology{
                    Id = Guid.NewGuid(),
                    Name = "Ansiedad"
                },
            };
            patList2 = new List<Pathology>{
                new Pathology{
                    Id = Guid.NewGuid(),
                    Name = "Relaciones"
                },
                    new Pathology{
                    Id = Guid.NewGuid(),
                    Name = "Ansiedad"
                },
            };
            psyco1 = new Psychologist()
            {
                Id = Guid.NewGuid(),
                Name = "Joaquin Perez",
                MeetingType = "presencial",
                Address = "",
                IsActive = true,
                Pathologies = patList1
            };
            psyco2 = new Psychologist()
            {
                Id = Guid.NewGuid(),
                Name = "Magdalena Perez",
                MeetingType = "presencial",
                Address = "",
                IsActive = true,
                Pathologies = patList2
            };
            psyco3 = new Psychologist()
            {
                Id = Guid.NewGuid(),
                Name = "Antonio Gonzalez",
                MeetingType = "presencial",
                Address = "",
                IsActive = false,
                Pathologies = patList2
            };
        }

        [TestMethod]
        public void GetAllTest()
        {

            List<Psychologist> list = new List<Psychologist>();
            list.Add(psyco1);
            daMock.Setup(x => x.GetAll()).Returns(list);

            IEnumerable<Psychologist> ret = psychologistLogic.GetAll();
            daMock.VerifyAll();
            Assert.IsTrue(ret.SequenceEqual(list));
        }


        [TestMethod]
        public void GetAllTestEmptyList()
        {

            List<Psychologist> list = new List<Psychologist>();
            daMock.Setup(x => x.GetAll()).Returns(list);

            IEnumerable<Psychologist> ret = psychologistLogic.GetAll();
            daMock.VerifyAll();
            Assert.IsTrue(ret.SequenceEqual(list));
        }


        [TestMethod]
        public void GetPsychologistByIdOk()
        {
            Guid id = this.psyco1.Id;
            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(psyco1);
            var ret = psychologistLogic.Get(id);
            daMock.VerifyAll();
            Assert.IsTrue(ret.Equals(psyco1));

        }
        [ExpectedException(typeof(Exception), "The psychologist doesn't exists")]
        [TestMethod]
        public void GetPsychologistByIdFail()
        {
            Guid id = Guid.NewGuid();
            Psychologist psyco = null;
            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(psyco);
            var ret = psychologistLogic.Get(id);
        }


        [TestMethod]
        public void PsychologistUpdateOk()
        {
            Guid id = this.psyco1.Id;
            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(psyco1);
            var updatedPsyco = new Psychologist()
            {
                Id = id,
                Name = "Joaquin Perez",
                MeetingType = "virtual",
                Address = "",
                IsActive = true,
                Pathologies = patList1
            };
            daMock.Setup(x => x.Update(updatedPsyco));
            daMock.Setup(x => x.Save());

            psychologistLogic.Update(id, updatedPsyco);

            daMock.VerifyAll();

        }

        [ExpectedException(typeof(Exception), "The psychologist doesn't exists")]
        [TestMethod]
        public void PsychologistUpdateAdminNoExists()
        {
            Guid id = Guid.NewGuid();
            Psychologist psyco = null;
            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(psyco);
            var updatedPsyco = new Psychologist()
            {
                Id = id,
                Name = "Joaquin Perez",
                MeetingType = "virtual",
                Address = "",
                IsActive = true,
                Pathologies = patList1
            };
            daMock.Setup(x => x.Update(updatedPsyco));
            daMock.Setup(x => x.Save());
            psychologistLogic.Update(id, updatedPsyco);
        }

        [TestMethod]
        public void CreatePsychologistOk()
        {

            daMock.Setup(x => x.Add(psyco1)).Verifiable();
            daMock.Setup(x => x.Save());
            psychologistLogic.Create(psyco1);
            daMock.VerifyAll();

        }





        [TestMethod]
        public void RemovePsychologistOk()
        {
            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(psyco1);
            daMock.Setup(m => m.Remove(psyco1));
            daMock.Setup(m => m.Save());

            psychologistLogic.Delete(psyco1.Id);
            daMock.VerifyAll();
        }

        [ExpectedException(typeof(Exception), "The psychologist doesn't exists")]
        [TestMethod]
        public void RemovePsychologistFail()
        {
            Psychologist adminNull = null;

            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(adminNull);
            daMock.Setup(m => m.Remove(adminNull));
            daMock.Setup(m => m.Save());

            psychologistLogic.Delete(Guid.NewGuid());
        }


    }

}

