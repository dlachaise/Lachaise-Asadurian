
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
    public class CategoryLogicTest
    {
        private Mock<ICategoryLogic> Mock;
        private Mock<ICategoryRepository> daMock;

        CategoryLogic categoryLogic;

        [TestInitialize]
        public void Setup()
        {
            daMock = new Mock<ICategoryRepository>(MockBehavior.Strict);
            Mock = new Mock<ICategoryLogic>(MockBehavior.Strict);
            this.categoryLogic = new CategoryLogic(daMock.Object, Mock.Object);
        }

        [TestMethod]
        public void GetAllCategorys()
        {
            Guid id = Guid.NewGuid();
            var category = new Category()
            {
                Id = id,
                Name = "Dormir",
                Audios =  new List<Audio>(),
                Playlists =  new List<Playlist>()
            };
            List<Category> list = new List<Category>();
            list.Add(category);
            daMock.Setup(x => x.GetAll()).Returns(list);

            IEnumerable<Category> ret = categoryLogic.GetAll();
            daMock.VerifyAll();
            Assert.IsTrue(ret.SequenceEqual(list));
        }

         [TestMethod]
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

      

    }
}

