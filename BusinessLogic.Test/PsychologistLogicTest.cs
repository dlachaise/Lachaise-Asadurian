
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
                Pathologies = patList
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
    }
}
//         [TestMethod]
//         public void GetAllTestEmptyList()
//         {

//             List<Psychologist> list = new List<Psychologist>();
//             daMock.Setup(x => x.GetAll()).Returns(list);

//             IEnumerable<Psychologist> ret = psychologistLogic.GetAll();
//             daMock.VerifyAll();
//             Assert.IsTrue(ret.SequenceEqual(list));
//         }

//         [TestMethod]
//         public void GetPsychologistByIdOk()
//         {
//             Guid id = this.psyco1.id;
//             daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(psyco1);
//             var ret = psychologistLogic.Get(id);
//             daMock.VerifyAll();
//             Assert.IsTrue(ret.Equals(admin));

//         }
//         [ExpectedException(typeof(Exception), "The psychologist doesn't exists")]
//         [TestMethod]
//         public void GetPsychologistByIdFail()
//         {
//             Guid id = Guid.NewGuid();
//             Psychologist psyco = null;
//             daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(psyco);
//             var ret = psychologistLogic.Get(id);
//         }

//         [TestMethod]
//         public void PsychologistUpdateOk()
//         {
//             Guid id = Guid.NewGuid();
//             daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(psyco1);
//             var updatedPsyco = new Psychologist()
//             {
//                 Id = Guid.NewGuid(),
//                 Name = "Joaquin Perez",
//                 MeetingType = "virtual",
//                 Address = "",
//                 IsActive = true,
//                 Pathologies = patList
//             };
//             daMock.Setup(x => x.Update(updatedPsyco));
//             daMock.Setup(x => x.Save());

//             psychologistLogic.Update(id, updatedPsyco);

//             daMock.VerifyAll();

//         }
//         [ExpectedException(typeof(Exception), "The psychologist doesn't exists")]
//         [TestMethod]
//         public void PsychologistUpdateAdminNoExists()
//         {
//             Guid id = Guid.NewGuid();
//             Psychologist adm = null;
//             daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(adm);
//             var updatedAdmin = new Psychologist()
//             {
//                 Id = id,
//                 Name = "Dominique Lachaise",
//                 Email = "dominique@gmail.com",
//                 Password = "admin1234",
//                 IsActive = true
//             };

//             daMock.Setup(x => x.Update(updatedAdmin));
//             daMock.Setup(x => x.Save());
//             psychologistLogic.Update(id, updatedAdmin);
//         }


//         [TestMethod]
//         public void CreatePsychologistOk()
//         {
//             Guid id = Guid.NewGuid();
//             var admin = new Psychologist()
//             {
//                 Id = id,
//                 Name = "Dominique",
//                 Email = "domi@gmail.com",
//                 Password = "admin1234",
//                 IsActive = true
//             };
//             daMock.Setup(x => x.Add(admin)).Verifiable();
//             daMock.Setup(x => x.Save());
//             List<Psychologist> list = new List<Psychologist>();
//             daMock.Setup(x => x.GetAll()).Returns(list);
//             psychologistLogic.Create(admin);
//             daMock.VerifyAll();

//         }

//         [ExpectedException(typeof(Exception), "The psychologist doesn't exists")]
//         [TestMethod]
//         public void CreatePsychologistFailAlreadyExists()
//         {
//             Guid id = Guid.NewGuid();
//             var admin = new Psychologist()
//             {
//                 Id = id,
//                 Name = "Dominique",
//                 Email = "domi@gmail.com",
//                 Password = "admin1234",
//                 IsActive = true
//             };

//             List<Psychologist> list = new List<Psychologist>();
//             daMock.Setup(x => x.Add(admin)).Verifiable();
//             daMock.Setup(x => x.Save());
//             daMock.Setup(x => x.GetAll()).Returns(list);
//             psychologistLogic.Create(admin);
//             list.Add(admin);
//             daMock.Setup(x => x.GetAll()).Returns(list);
//             psychologistLogic.Create(admin);

//         }

//         [TestMethod]
//         public void RemovePsychologistOk()
//         {
//             Guid id = Guid.NewGuid();
//             Psychologist admin = new Psychologist
//             {
//                 Id = id,
//                 Name = "Dominique",
//                 Email = "domi@gmail.com",
//                 Password = "admin1234",
//                 IsActive = true
//             };
//             daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(admin);
//             daMock.Setup(m => m.Remove(admin));
//             daMock.Setup(m => m.Save());

//             psychologistLogic.Delete(id);
//             daMock.VerifyAll();
//         }

//         [ExpectedException(typeof(Exception), "The psychologist doesn't exists")]
//         [TestMethod]
//         public void RemovePsychologistFail()
//         {
//             Psychologist adminNull = null;

//             daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(adminNull);
//             daMock.Setup(m => m.Remove(adminNull));
//             daMock.Setup(m => m.Save());

//             psychologistLogic.Delete(Guid.NewGuid());
//         }


//     }

// }

