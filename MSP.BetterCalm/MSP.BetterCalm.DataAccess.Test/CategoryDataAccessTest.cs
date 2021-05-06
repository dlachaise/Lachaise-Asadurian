using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;

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
        public void GetAllCategory()
        {
            CreateDataBase("GetCategoryTestDB");
            int size = categoryRepo.GetAll().ToList().Count;
            Assert.AreEqual(1, size);
        }

        [TestMethod]
        public void GetCategoryById()
        {
            CreateDataBase("GetCategoryDB");
            var getCategory = categoryRepo.Get(category.Id);
            Assert.AreEqual(getCategory.Id, category.Id);
        }

    }

}
