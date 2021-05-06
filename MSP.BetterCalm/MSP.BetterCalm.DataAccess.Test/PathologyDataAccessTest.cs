using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess.Test
{
    [TestClass]
    public class PathologyDataAccessTest
    {
        private DataContext context;
        private Pathology pathology;
        private Repository<Pathology> pathologyRepo;

        [TestInitialize]
        public void InitTest()
        {
            Guid id = new Guid();
            pathology = new Pathology()
            {
                Id = id,
                Name = "Ansiedad"
            };

        }

        private void CreateDataBase(string name)
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: name)
            .Options;

            context = new DataContext(options);

            context.Set<Pathology>().Add(pathology);
            context.SaveChanges();

            pathologyRepo = new Repository<Pathology>(context);
        }

        [TestMethod]
        public void GetAllPathology()
        {
            CreateDataBase("GetPathologyTestDB");
            int size = pathologyRepo.GetAll().ToList().Count;
            Assert.AreEqual(1, size);
        }

        [TestMethod]
        public void GetPahtologyById()
        {
            CreateDataBase("GetPathologyDB");
            var getPathology = pathologyRepo.Get(pathology.Id);
            Assert.AreEqual(getPathology.Id, pathology.Id);
        }
    }

}
