using MSP.BetterCalm.BusinessLogic.Interface;
using System.Linq;
using MSP.BetterCalm.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using MSP.BetterCalm.WebApi.Controllers;
using MSP.BetterCalm.WebApi.Models;


namespace MSP.BetterCalm.WebApi.Test
{
    [TestClass]
    public class CategoryControllerTest
    {

        private Mock<ICategoryLogic> Mock;
        private CategoryController controller;
        IEnumerable<Category> categoryList;

        CategoryDTO categoryDTO1;
        Category category1;

        [TestInitialize]
        public void Setup()
        {

            Mock = new Mock<ICategoryLogic>(MockBehavior.Strict);
            controller = new CategoryController(Mock.Object);
            category1 = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Meditar",
            };
            categoryDTO1 = new CategoryDTO(category1);

            categoryList = new List<Category>{
                category1,
                    new Category{
                    Id = Guid.NewGuid(),
                    Name = "Dormir"
                },
            };
        }

        [TestMethod]
        public void GetCategoryOK()
        {
            Mock.Setup(categoryLogic => categoryLogic.GetAll()).Returns(categoryList);

            var result = controller.Get();
            var OkResult = result as OkObjectResult;
            var controllerAdmins = OkResult.Value as IEnumerable<CategoryDTO>; ;
            var statusCode = OkResult.StatusCode;

            Mock.VerifyAll();

            Assert.IsTrue(categoryList.Select(category => new CategoryDTO(category)).SequenceEqual(controllerAdmins));
            Assert.AreEqual(200, statusCode);
        }


        [TestMethod]
        public void GetByIdOK()
        {
            Mock.Setup(categoryLogic => categoryLogic.Get(It.IsAny<Guid>())).Returns(category1);

            var result = controller.Get(It.IsAny<Guid>());
            var okResult = result as OkObjectResult;
            var controllerAdmin = okResult.Value as CategoryDTO;
            var statusCode = okResult.StatusCode;

            Mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
            Assert.IsTrue(new CategoryDTO(category1).Equals(controllerAdmin));
        }

        [TestMethod]
        public void GetByIdNotExist()
        {
            Category category = null;

            Mock.Setup(categoryLogic => categoryLogic.Get(It.IsAny<Guid>())).Returns(category);

            var result = controller.Get(It.IsAny<Guid>());
            var okResult = result as NotFoundObjectResult;
            var statusCode = okResult.StatusCode;

            Mock.VerifyAll();
            Assert.AreEqual(404, statusCode);

        }

    }
}