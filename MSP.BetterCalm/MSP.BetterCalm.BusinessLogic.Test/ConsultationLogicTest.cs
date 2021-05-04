
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
    public class ConsultationLogicTest
    {

        private Mock<IConsultationLogic> Mock;
        private Mock<IRepository<Consultation>> daMock;
        private Mock<IPsychologistLogic> MockPsycho;

        ConsultationLogic consultationLogic;

        private Psychologist psycho;

        [TestInitialize]
        public void Setup()
        {
            MockPsycho = new Mock<IPsychologistLogic>(MockBehavior.Strict);
            daMock = new Mock<IRepository<Consultation>>(MockBehavior.Strict);
            Mock = new Mock<IConsultationLogic>(MockBehavior.Strict);
            this.consultationLogic = new ConsultationLogic(daMock.Object, MockPsycho.Object);

            List<Pathology> patList1 = new List<Pathology>{
                new Pathology{
                    Id = Guid.NewGuid(),
                    Name = "Estres"
                },
                    new Pathology{
                    Id = Guid.NewGuid(),
                    Name = "Ansiedad"
                },
            };
            psycho = new Psychologist()
            {
                Id = Guid.NewGuid(),
                Name = "Joaquin Perez",
                MeetingType = "presencial",
                Address = "Julio cesar 1569",
                IsActive = true,
                Pathologies = patList1,
                StartDate = DateTime.Now.AddDays(-3),
                MeetingList = new SortedList<DateTime, int>()
            };
        }


        [TestMethod]
        public void GetAllConsultations()
        {
            Guid id = Guid.NewGuid();
            var consultation = new Consultation()
            {

                Id = id,
                MeetingType = 1,
                MeetingLink = "www.zoom.com/consulta1",
                Date = new DateTime(),
                UserCompleteName = "Diego Asadurian",
                UserBirthDate = "11/11/1994",
                UserCel = "099894147",
                UserEmail = "diego@gmail.com",
                Psychologist = psycho

            };
            List<Consultation> list = new List<Consultation>();
            list.Add(consultation);
            daMock.Setup(x => x.GetAll()).Returns(list);

            IEnumerable<Consultation> ret = consultationLogic.GetAll();
            daMock.VerifyAll();
            Assert.IsTrue(ret.SequenceEqual(list));
        }

        [TestMethod]
        public void CreateConsultationOk()
        {
            var pathology = new Pathology()
            {
                Id = Guid.NewGuid(),
                Name = "Estres"
            };
            Guid id = Guid.NewGuid();
            var consult = new Consultation()
            {
                Id = id,
                MeetingType = 1,
                MeetingLink = "www.esporahi.com",
                Date = DateTime.Now,
                UserCompleteName = "Juan manuel",
                UserBirthDate = "11/11/1994",
                UserCel = "099894147",
                UserEmail = "diego@gmail.com",
                Psychologist = psycho
            };
            var psychoToReturn = new List<Psychologist> { this.psycho };
            var psychoToReturnAvailable = new List<Psychologist> { this.psycho };
            daMock.Setup(x => x.Create(consult)).Verifiable();
            daMock.Setup(x => x.Save());
           
            MockPsycho.Setup(x => x.GetByPathology(pathology.Id)).Returns(psychoToReturn);
            MockPsycho.Setup(x => x.GetPsychoAvailable(psychoToReturn, consult.Date)).Returns(psychoToReturnAvailable);
            MockPsycho.Setup(x => x.OlderPsycho(psychoToReturnAvailable)).Returns(this.psycho);

            consultationLogic.CreateConsultation(consult, pathology.Id); 
            daMock.VerifyAll();
            Assert.AreEqual(consult.Psychologist.Id, psycho.Id);
        }


        [ExpectedException(typeof(Exception), "There are no psychologists available for this pathology")]
        [TestMethod]
        public void NoPsychologistAvailableToThisPathology()
        {
        var pathology = new Pathology()
            {
                Id = Guid.NewGuid(),
                Name = "Mal Humor"
            };
            Guid id = Guid.NewGuid();
            var consult = new Consultation()
            {
                Id = id,
                MeetingType = 1,
                MeetingLink = "www.meetGoogle.com",
                Date = DateTime.Now,
                UserCompleteName = "Diego Lopez",
                UserBirthDate = "01/10/1994",
                UserCel = "0996225836",
                UserEmail = "maria@gmail.com",
                Psychologist = psycho
            };
            
             var psychoToReturn = new List<Psychologist> { this.psycho };
             List<Psychologist> psychoToReturnAvailable = null;
            daMock.Setup(x => x.Create(consult)).Verifiable();
            daMock.Setup(x => x.Save());

            MockPsycho.Setup(x => x.GetByPathology(pathology.Id)).Returns(psychoToReturn);
            MockPsycho.Setup(x => x.GetPsychoAvailable(psychoToReturn, consult.Date)).Returns(psychoToReturnAvailable);
            MockPsycho.Setup(x => x.OlderPsycho(psychoToReturnAvailable)).Returns(this.psycho);

            consultationLogic.CreateConsultation(consult, pathology.Id); 
            daMock.VerifyAll();
            Assert.AreNotEqual(consult.Psychologist.Id, psycho.Id);
        }


         [ExpectedException(typeof(Exception), "There are no psychologists available for this date")]
        [TestMethod]
          public void NoPsychologistAvailableForDate()
        {
        var pathology = new Pathology()
            {
                Id = Guid.NewGuid(),
                Name = "Estres"
            };
            Guid id = Guid.NewGuid();
            var consult = new Consultation()
            {
                Id = id,
                MeetingType = 1,
                MeetingLink = "www.teams.com",
                Date = DateTime.Now,
                UserCompleteName = "Mariana Haedo",
                UserBirthDate = "01/10/1994",
                UserCel = "09965848",
                UserEmail = "mariana@gmail.com",
                Psychologist = psycho
            };
            List<Psychologist> psychoToReturn = null;
            var psychoToReturnAvailable = new List<Psychologist> { this.psycho };
            daMock.Setup(x => x.Create(consult)).Verifiable();
            daMock.Setup(x => x.Save());
            
            MockPsycho.Setup(x => x.GetByPathology(pathology.Id)).Returns(psychoToReturn);
            MockPsycho.Setup(x => x.GetPsychoAvailable(psychoToReturn, consult.Date)).Returns(psychoToReturnAvailable);
            MockPsycho.Setup(x => x.OlderPsycho(psychoToReturnAvailable)).Returns(this.psycho);

            consultationLogic.CreateConsultation(consult, pathology.Id); 
            daMock.VerifyAll();
            Assert.AreNotEqual(consult.Psychologist.Id, psycho.Id);
        }

    }
}

