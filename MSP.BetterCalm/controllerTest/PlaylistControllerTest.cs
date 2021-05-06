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
    public class PlaylistControllerTest
    {

        private Mock<IPlaylistLogic> Mock;
        private PlaylistController controller;
        IEnumerable<Playlist> playList;

        PlaylistDTO playDTO1;
        Playlist play1;

        [TestInitialize]
        public void Setup()
        {

            Mock = new Mock<IPlaylistLogic>(MockBehavior.Strict);
            controller = new PlaylistController(Mock.Object);
            play1 = new Playlist
            {
                Id = Guid.NewGuid(),
                Name = "Para descansar",
                Description = "Ideal para dormir",
            };
            playDTO1 = new PlaylistDTO(play1);

            playList = new List<Playlist>{
                play1,
                    new Playlist{
                    Id = Guid.NewGuid(),
                    Name = "Ejercitate",
                    Description = "Ideal para correr",
                },
            };
        }

        [TestMethod]
        public void GetPlaylistOK()
        {

            Mock.Setup(playlistLogic => playlistLogic.GetAll()).Returns(playList);

            var result = controller.Get();
            var OkResult = result as OkObjectResult;
            var controllerAdmins = OkResult.Value as IEnumerable<PlaylistDTO>; ;
            var statusCode = OkResult.StatusCode;

            Mock.VerifyAll();

            Assert.IsTrue(playList.Select(play => new PlaylistDTO(play)).SequenceEqual(controllerAdmins));
            Assert.AreEqual(200, statusCode);


        }


        [TestMethod]
        public void GetByIdOK()
        {

            Mock.Setup(playlistLogic => playlistLogic.Get(It.IsAny<Guid>())).Returns(play1);

            var result = controller.Get(It.IsAny<Guid>());
            var okResult = result as OkObjectResult;
            var controllerAdmin = okResult.Value as PlaylistDTO;
            var statusCode = okResult.StatusCode;

            Mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
            Assert.IsTrue(new PlaylistDTO(play1).Equals(controllerAdmin));
        }

        [TestMethod]
        public void GetByIdNotExist()
        {


            Playlist play = null;

            Mock.Setup(playLogic => playLogic.Get(It.IsAny<Guid>())).Returns(play);

            var result = controller.Get(It.IsAny<Guid>());
            var okResult = result as NotFoundObjectResult;
            var statusCode = okResult.StatusCode;

            Mock.VerifyAll();
            Assert.AreEqual(404, statusCode);

        }


        [TestMethod]
        public void PostPlaylistOK()
        {
            Mock.Setup(playLogic => playLogic.Create(It.IsAny<Playlist>())).Returns(play1);

            var result = controller.Post(playDTO1);
            var okResult = result as OkObjectResult;
            var playAdded = okResult.Value as PlaylistDTO;

            Mock.VerifyAll();

            Assert.IsTrue(playAdded.Equals(playDTO1));

        }

    }
}