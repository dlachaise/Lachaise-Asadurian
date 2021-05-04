
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
                StartDate = DateTime.Now.AddDays(-3)
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
            List<Pathology> pat = new List<Pathology>{
                new Pathology{
                    Id = Guid.NewGuid(),
                    Name = "Estres"
                },

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
                UserEmail = "diego@gmail.com"
            };

            daMock.Setup(x => x.Create(consult)).Verifiable();
            daMock.Setup(x => x.Save());
            
            List<Consultation> list = new List<Consultation>();
            daMock.Setup(x => x.GetAll()).Returns(list);
            consultationLogic.CreateConsultation(consult, pat.First().Id); //ver como pasarle la patologia para que nosea nula
            daMock.VerifyAll();

        }


        /* [TestMethod]
        public void GetCategoryByIdOk()
        {
            Guid id = Guid.NewGuid();
            var category = new Category()
            {
                Id = id,
                Name = "Meditar",
                Audios =  new List<Audio>(),
                Playlists =  new List<Playlist>()
            };

            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(category);

            var ret = categoryLogic.Get(id);
            daMock.VerifyAll();
            Assert.IsTrue(ret.Equals(category));

        }
  
        [ExpectedException(typeof(Exception), "The Category doesn't exists")]
        [TestMethod]
        public void GetCategoryByIdFail()
        {
            Guid id = Guid.NewGuid();
            Category category = null;
            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(category);
            var ret = categoryLogic.Get(id);

        }
*/


    }
}

