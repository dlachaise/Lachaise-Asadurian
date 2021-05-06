
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
    public class PlaylistLogicTest
    {
        private Mock<IPlaylistLogic> Mock;
        private Mock<IRepository<Playlist>> daMock;

        PlaylistLogic playlistLogic;

        [TestInitialize]
        public void Setup()
        {
            daMock = new Mock<IRepository<Playlist>>(MockBehavior.Strict);
            Mock = new Mock<IPlaylistLogic>(MockBehavior.Strict);
            this.playlistLogic = new PlaylistLogic(daMock.Object);
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
                Audios = new List<Audio>(),
               

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
                Audios = new List<Audio>(),
                
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
                Audios = new List<Audio>(),
            };
            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(playlist);
            daMock.Setup(m => m.Delete(playlist));
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
                Audios = new List<Audio>(),
            };
            daMock.Setup(x => x.Create(playlist)).Verifiable();
            daMock.Setup(x => x.Save());

            playlistLogic.Create(playlist);
            daMock.VerifyAll();
            Assert.AreEqual(playlist.Name, "Perreo duro");

        }

        [ExpectedException(typeof(Exception), "The Playlist doesn't exists")]
        [TestMethod]
        public void GetPlaylistByIdFail()
        {
            Guid id = Guid.NewGuid();
            Playlist playlist = null;
            daMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(playlist);
            var ret = playlistLogic.Get(id);
            Assert.IsFalse(ret.Equals(playlist));

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
  */
    }
}

