
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
    public class PlaylistLogicTest
    {
        private Mock<IPlaylistLogic> Mock;
        private Mock<IPlaylistRepository> daMock;

        PlaylistLogic playlistLogic;

        [TestInitialize]
        public void Setup()
        {
            daMock = new Mock<IPlaylistRepository>(MockBehavior.Strict);
            Mock = new Mock<IPlaylistLogic>(MockBehavior.Strict);
            this.playlistLogic = new PlaylistLogic(daMock.Object, Mock.Object);
        }

        [TestMethod]
        public void GetAllPlaylist()
        {
            Guid id = Guid.NewGuid();
            var playlist = new Playlist()
            {
                Id = id,
                Name = "Musica para entrenar",
                Description = "Una playlist para entrenar duro",
                ImageUrl = "/Desktop/ImagenesAudio/musicaEntrenar.png",
                Audios =  new List<Audio>(),
               // IsActive = true

            };
            List<Playlist> list = new List<Playlist>();
            list.Add(playlist);
            daMock.Setup(x => x.GetAll()).Returns(list);

            IEnumerable<Playlist> ret = playlistLogic.GetAll();
            daMock.VerifyAll();
            Assert.IsTrue(ret.SequenceEqual(list));
        }

         [TestMethod]
        public void GetPlaylistByIdOk()
        {
            Guid id = Guid.NewGuid();
            var playlist = new Playlist()
            {
                Id = id,
                Name = "Be Chill",
                Description = "Buenas musicas para relajarte",
                ImageUrl = "/Desktop/ImagenesAudio/BeChill.png",
                Audios =  new List<Audio>(),
                 // IsActive = true
            };

            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(playlist);

            var ret = playlistLogic.Get(id);
            daMock.VerifyAll();
            Assert.IsTrue(ret.Equals(playlist));

        }
        [TestMethod]
        public void RemovePlaylistOk()
        {
            Guid id = Guid.NewGuid();
            var playlist = new Playlist()
            {
               Id = id,
                Name = "Musica para dormir",
                Description = "Sonidos de la naturaleza para poder dormirte",
                ImageUrl = "/Desktop/ImagenesAudio/dormir.png",
                Audios =  new List<Audio>(),
            };
            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(playlist);
            daMock.Setup(m => m.Remove(playlist));
            daMock.Setup(m => m.Save());

            playlistLogic.Delete(id);
            daMock.VerifyAll();
        }

       [TestMethod]
        public void GetAllTestEmptyList()
        {

            List<Playlist> list = new List<Playlist>();
            daMock.Setup(x => x.GetAll()).Returns(list);

            IEnumerable<Playlist> ret = playlistLogic.GetAll();
            daMock.VerifyAll();
            Assert.IsTrue(ret.SequenceEqual(list));
        }


         [TestMethod]
        public void CreatePlaylistOk()
        {
            Guid id = Guid.NewGuid();
            var playlist = new Playlist()
            {
                Id = id,
                Name = "Perreo duro",
                Description = "Musica para perrear pre boliche",
                ImageUrl = "/Desktop/ImagenesAudio/perreoDuro.png",
                Audios =  new List<Audio>(),
            };
            daMock.Setup(x => x.Add(playlist)).Verifiable();
            daMock.Setup(x => x.Save());
                         
            playlistLogic.CreatePlaylist(playlist);
            daMock.VerifyAll();

        }

        [ExpectedException(typeof(Exception), "The Playlist doesn't exists")]
        [TestMethod]
        public void GetPlaylistByIdFail()
        {
            Guid id = Guid.NewGuid();
            Playlist playlist = null;
            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(playlist);
            var ret = playlistLogic.Get(id);

        }

      /*  [ExpectedException(typeof(Exception), "The Audio doesn't exists")]
        [TestMethod]
        public void RemoveAudioFail()
        {
            Audio audioNull = null;

            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(audioNull);
            daMock.Setup(m => m.Remove(audioNull));
            daMock.Setup(m => m.Save());

            playlistLogic.Delete(Guid.NewGuid());
        }
       

        [ExpectedException(typeof(Exception), "The administrator doesn't exists")]
        [TestMethod]
        public void CreateAdministratorFailAlreadyExists()
        {
            Guid id = Guid.NewGuid();
            var admin = new Administrator()
            {
                Id = id,
                Name = "Dominique",
                Email = "domi@gmail.com",
                Password = "admin1234",
                IsActive = true
            };

            List<Administrator> list = new List<Administrator>();
            daMock.Setup(x => x.Add(admin)).Verifiable();
            daMock.Setup(x => x.Save());
            daMock.Setup(x => x.GetAll()).Returns(list);
            administratorLogic.Create(admin);
            list.Add(admin);
            daMock.Setup(x => x.GetAll()).Returns(list);
            administratorLogic.Create(admin);

        }
*/
    }
}

