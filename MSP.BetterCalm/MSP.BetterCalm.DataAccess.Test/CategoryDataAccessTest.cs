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
    public class CategoryDataAccessTest
    {
        private DataContext context;
        private Category category;
        private Repository<Category> categoryRepo;

        [TestInitialize]
        public void InitTest()
        {
            Guid id = new Guid();
            category = new Category()
            {
                Id = id,
                Name = "Dormir",
                Audios = new List<Audio>(),
                Playlists = new List<Playlist>()
            };

        }

        private void CreateDataBase(string name)
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: name)
            .Options;

            context = new DataContext(options);

            context.Set<Category>().Add(category);
            context.SaveChanges();

            categoryRepo = new Repository<Category>(context);
        }

        [TestMethod]
        public void GetCategory()
        {
            CreateDataBase("GetCategoryTestDB");
            int size = categoryRepo.GetAll().ToList().Count;
            Assert.AreEqual(1, size);
        }

    }

}
