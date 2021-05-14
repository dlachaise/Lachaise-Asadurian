
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic.Interface;
using MSP.BetterCalm.DataAccess.Interface;
using MSP.BetterCalm.Domain;
namespace MSP.BetterCalm.BusinessLogic.Test
{
    [TestClass]
    public class PsychologistLoginTest
    {

         //probando Obl 2
        private Mock<IAdministratorLogic> MockAdm;
        private Mock<IPsychologistLogic> Mock;
        private Mock<IRepository<Psychologist>> daMock;

        PsychologistLogic psychologistLogic;
        Psychologist psyco1, psyco2, psyco3;
        IEnumerable<Pathology> patList1, patList2, patList3;

        [TestInitialize]
        public void Setup()
        {
            SortedList<DateTime, int> meet = new SortedList<DateTime, int>();
            meet.Add(DateTime.Now.AddDays(-2), 2);
            MockAdm = new Mock<IAdministratorLogic>(MockBehavior.Strict); //probando obl 2
            daMock = new Mock<IRepository<Psychologist>>(MockBehavior.Strict);
            Mock = new Mock<IPsychologistLogic>(MockBehavior.Strict);
            //this.psychologistLogic = new PsychologistLogic(daMock.Object);
             this.psychologistLogic = new PsychologistLogic(daMock.Object, MockAdm.Object);//probando obl 2
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
                MeetingType = 1,
                Address = "Julio Cesar 1569",
                IsActive = true,
                Pathologies = patList1,
                MeetingList = meet,
                Tariff = 750
            };
            psyco2 = new Psychologist()
            {
                Id = Guid.NewGuid(),
                Name = "Magdalena Perez",
                MeetingType = 2,
                Address = "",
                IsActive = true,
                Pathologies = patList2,
                Tariff = 1000
            };
            psyco3 = new Psychologist()
            {
                Id = Guid.NewGuid(),
                Name = "Antonio Gonzalez",
                MeetingType = 2,
                Address = "",
                IsActive = false,
                Pathologies = patList2,
                Tariff = 500
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


        [TestMethod]
        public void GetPsychologistByPathologyIdOk()
        {

            List<Psychologist> list = new List<Psychologist>();
            list.Add(psyco1);
            daMock.Setup(x => x.GetAll()).Returns(list);
            
            Guid id = patList1.First().Id;
            IEnumerable<Psychologist> psychoToReturn = new List<Psychologist> { this.psyco1 };
            Mock.Setup(x => x.GetByPathology(id)).Returns(psychoToReturn);

            IEnumerable<Psychologist> ret = psychologistLogic.GetByPathology(id);
            daMock.VerifyAll();

            var psycoRet = ret.Where(c => c.Id == psyco1.Id);
            Assert.AreEqual(ret.First().Address,psyco1.Address);         

        }
        
        [TestMethod]
        public void GetPsychologistByPathologyEmpty()
        {
          
            List<Psychologist> list = new List<Psychologist>();
            daMock.Setup(x => x.GetAll()).Returns(list);
            Mock.Setup(x => x.GetByPathology(Guid.NewGuid())).Returns(list);

            IEnumerable<Psychologist> ret = psychologistLogic.GetByPathology(Guid.NewGuid());
            daMock.VerifyAll();
            int result = ret.Count();
            int exp = list.Count();

            Assert.IsTrue(result == exp);
        }

        [TestMethod]
        public void GetPsychologistAvailableOk()
        {

            List<Psychologist> list = new List<Psychologist>();
            list.Add(psyco1);
      
            Guid id = patList1.First().Id;
            IEnumerable<Psychologist> psychoToReturn = new List<Psychologist> { this.psyco1 };
            Mock.Setup(x => x.GetByPathology(id)).Returns(psychoToReturn);

            var psychoToReturnAvailable = new List<Psychologist> { this.psyco1 };
            Mock.Setup(x => x.GetPsychoAvailable(psychoToReturn, DateTime.Now.AddDays(+1))).Returns(psychoToReturnAvailable);

            IEnumerable<Psychologist> ret = psychologistLogic.GetPsychoAvailable(psychoToReturn, DateTime.Now.AddDays(+1));
            daMock.VerifyAll();

            Assert.IsTrue(ret.SequenceEqual(psychoToReturnAvailable));

        }


        [TestMethod]
        public void GetPsychologistAvailableEmpty()
        {
            List<Psychologist> list = new List<Psychologist>();
            Guid id = patList1.First().Id;
            IEnumerable<Psychologist> psychoToReturn = new List<Psychologist>(); 
            Mock.Setup(x => x.GetByPathology(id)).Returns(psychoToReturn);

            var psychoToReturnAvailable = new List<Psychologist>();
            Mock.Setup(x => x.GetPsychoAvailable(psychoToReturn, DateTime.Now.AddDays(+1))).Returns(psychoToReturnAvailable);

            IEnumerable<Psychologist> ret = psychologistLogic.GetPsychoAvailable(psychoToReturn, DateTime.Now.AddDays(+1));
            daMock.VerifyAll();

            int result = ret.Count();
            int psychoAvailable = psychoToReturnAvailable.Count();

            Assert.IsTrue(result == psychoAvailable);

        }


        [TestMethod]
        public void GetPsychologistOlderOk()
        {

            List<Psychologist> list = new List<Psychologist>();
            list.Add(psyco1);

            Guid id = patList1.First().Id;
            IEnumerable<Psychologist> psychoToReturn = new List<Psychologist> { this.psyco1 };
            Mock.Setup(x => x.GetByPathology(id)).Returns(psychoToReturn);

            var psychoToReturnAvailable = new List<Psychologist> { this.psyco1 };
            Mock.Setup(x => x.GetPsychoAvailable(psychoToReturn, DateTime.Now.AddDays(+1))).Returns(psychoToReturnAvailable);

            Mock.Setup(x => x.OlderPsycho(psychoToReturnAvailable)).Returns(this.psyco1);

            var ret = psychologistLogic.OlderPsycho(psychoToReturnAvailable);
            daMock.VerifyAll();

            Assert.AreEqual(ret.Id, psyco1.Id);

        }

        [ExpectedException(typeof(Exception), "No psychologist")]
        [TestMethod]
        public void GetEmptyPsychologistOlder()
        {
            Psychologist psychoEmpty = new Psychologist();
            List<Psychologist> list = new List<Psychologist>();
            

            Guid id = patList1.First().Id;
            IEnumerable<Psychologist> psychoToReturn = new List<Psychologist>(); 
            Mock.Setup(x => x.GetByPathology(id)).Returns(psychoToReturn);

            var psychoToReturnAvailable = new List<Psychologist>();
            Mock.Setup(x => x.GetPsychoAvailable(psychoToReturn, DateTime.Now.AddDays(+1))).Returns(psychoToReturnAvailable);

            Mock.Setup(x => x.OlderPsycho(psychoToReturnAvailable)).Returns(psychoEmpty);

            var ret = psychologistLogic.OlderPsycho(psychoToReturnAvailable);
            daMock.VerifyAll();

            Assert.AreEqual(ret.Id, psychoEmpty.Id);

        }



        [ExpectedException(typeof(Exception), "The psychologist doesn't exists")]
        [TestMethod]
        public void GetPsychologistByIdFail()
        {
            Guid id = Guid.NewGuid();
            Psychologist psyco = null;
            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(psyco);
            var ret = psychologistLogic.Get(id);
            Assert.IsFalse(ret.Equals(psyco));
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
                MeetingType = 2,
                Address = "",
                IsActive = true,
                Pathologies = patList1
            };
            daMock.Setup(x => x.Update(updatedPsyco));
            daMock.Setup(x => x.Save());
            psychologistLogic.Update(id, updatedPsyco);
            daMock.VerifyAll();

            var ret = psychologistLogic.Get(id);
            Assert.AreEqual(updatedPsyco.Name, psyco1.Name);

        }

        [ExpectedException(typeof(Exception), "The psychologist doesn't exists")]
        [TestMethod]
        public void PsychologistUpdateNoExists()
        {
            Guid id = Guid.NewGuid();
            Psychologist psyco = null;
            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(psyco);
            var updatedPsyco = new Psychologist()
            {
                Id = id,
                Name = "Joaquin Perez",
                MeetingType = 1,
                Address = "",
                IsActive = true,
                Pathologies = patList1
            };
            daMock.Setup(x => x.Update(updatedPsyco));
            daMock.Setup(x => x.Save());
            psychologistLogic.Update(id, updatedPsyco);
           
            var ret = psychologistLogic.Get(id);
            Assert.AreNotEqual(updatedPsyco.Name, psyco.Name);

        }

        [TestMethod]
        public void CreatePsychologistOk()
        {
            var psycoToCreate = new Psychologist()
            {
                Id = Guid.NewGuid(),
                Name = "Marco Gomez",
                MeetingType = 2,
                Address = "Luis Alberto de Herrerra 6555",
                IsActive = true,
                Pathologies = patList1,
                Tariff = 750
            };
            daMock.Setup(x => x.Create(psycoToCreate)).Verifiable();
            daMock.Setup(x => x.Save());
            List<Psychologist> list = new List<Psychologist>();
            daMock.Setup(x => x.GetAll()).Returns(list);
            psychologistLogic.Create(psycoToCreate);

            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(psycoToCreate);
            var ret = psychologistLogic.Get(psycoToCreate.Id);
           
            daMock.VerifyAll();
            Assert.IsTrue(ret.Equals(psycoToCreate));


        }

       /*  [ExpectedException(typeof(Exception), "The tariff is not acepted")]
        [TestMethod]
        public void CreatePsychologistTariffError()
        {
            var psycoToCreate = new Psychologist()
            {
                Id = Guid.NewGuid(),
                Name = "Marco Gomez",
                MeetingType = 2,
                Address = "Luis Alberto de Herrerra 6555",
                IsActive = true,
                Pathologies = patList1,
                Tariff = 850
            };
            daMock.Setup(x => x.Create(psycoToCreate)).Verifiable();
            daMock.Setup(x => x.Save());
            List<Psychologist> list = new List<Psychologist>();
            daMock.Setup(x => x.GetAll()).Returns(list);
            psychologistLogic.Create(psycoToCreate);

            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(psycoToCreate);
            var ret = psychologistLogic.Get(psycoToCreate.Id);
           
            daMock.VerifyAll();
            Assert.IsFalse(ret.Equals(psycoToCreate));
        }
*/
        [TestMethod]
        public void RemovePsychologistOk()
        {
            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(psyco1);
            daMock.Setup(m => m.Delete(psyco1));
            daMock.Setup(m => m.Save());
            psychologistLogic.Delete(psyco1.Id);
            daMock.VerifyAll();
                      
        }

        [ExpectedException(typeof(Exception), "The psychologist doesn't exists")]
        [TestMethod]
        public void RemovePsychologistFail()
        {
            Guid id = Guid.NewGuid();
            Psychologist psychoNull = null;

            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(psychoNull);
            daMock.Setup(m => m.Delete(psychoNull));
            daMock.Setup(m => m.Save());
            psychologistLogic.Delete(Guid.NewGuid());
            var ret = psychologistLogic.Get(id);
            Assert.IsFalse(ret.Equals(psychoNull));
        }



        [ExpectedException(typeof(Exception), "The psychologist doesn't exists")]
        [TestMethod]
        public void CreatePsychologistFailAlreadyExists()
        {
            var psycoToCreate = new Psychologist()
            {
                Id = Guid.NewGuid(),
                Name = "Juan Perez",
                MeetingType = 2,
                Address = "Julio Herrera 5252",
                IsActive = true,
                Pathologies = patList2
            };

            List<Psychologist> list = new List<Psychologist>();
            daMock.Setup(x => x.Create(psycoToCreate)).Verifiable();
            daMock.Setup(x => x.Save());
            daMock.Setup(x => x.GetAll()).Returns(list);
            psychologistLogic.Create(psycoToCreate);
            list.Add(psycoToCreate);
            daMock.Setup(x => x.GetAll()).Returns(list);
            psychologistLogic.Create(psycoToCreate);

            var ret = psychologistLogic.Get(psycoToCreate.Id);
            daMock.VerifyAll();
            Assert.IsTrue(ret.Equals(psycoToCreate));

        }

    }

}

