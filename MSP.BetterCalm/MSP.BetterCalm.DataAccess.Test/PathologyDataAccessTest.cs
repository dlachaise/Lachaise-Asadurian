using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

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
        public void GetPathology()
        {
            CreateDataBase("GetPathologyTestDB");
            int size = pathologyRepo.GetAll().ToList().Count;
            Assert.AreEqual(1, size);
        }

    }

}
