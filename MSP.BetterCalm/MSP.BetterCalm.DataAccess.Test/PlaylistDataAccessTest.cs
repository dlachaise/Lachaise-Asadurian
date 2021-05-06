using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess.Test
{
    [TestClass]
    public class PlaylistDataAccessTest
    {
        private DataContext context;
        private Playlist playlist;
        private Repository<Playlist> playlistRepo;

        [TestInitialize]
        public void InitTest()
        {
            Guid id = new Guid();
            playlist = new Playlist()
            {
                Id = id,
                Name = "Musica para entrenar",
                Description = "Una playlist para entrenar duro",
                ImageUrl = "/Desktop/ImagenesAudio/musicaEntrenar.png",
                Audios = new List<Audio>(),
            };

        }

        private void CreateDataBase(string name)
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: name)
            .Options;

            context = new DataContext(options);

            context.Set<Playlist>().Add(playlist);
            context.SaveChanges();

            playlistRepo = new Repository<Playlist>(context);
        }

        [TestMethod]
        public void GetAllPlaylist()
        {
            CreateDataBase("GetPlaylistTestDB");
            int size = playlistRepo.GetAll().ToList().Count;
            Assert.AreEqual(1, size);
        }

        [TestMethod]
        public void GetPlaylistById()
        {
            CreateDataBase("GetPlaylistDB");
            var getPlaylist = playlistRepo.Get(playlist.Id);
            Assert.AreEqual(getPlaylist.Id, playlist.Id);
        }


        [TestMethod]
        public void InsertPlaylist()
        {
            Guid id = new Guid();
            Playlist playlist = new Playlist()
            {
                Id = id,
                Name = "Noche",
                Description = "Una playlist para previar",
                ImageUrl = "/Desktop/ImagenesAudio/previa.png",
                Audios = new List<Audio>(),
            };

            CreateDataBase("InsertPlaylistTestDB");
            playlistRepo.Create(playlist);
            playlistRepo.Save();
            int size = playlistRepo.GetAll().ToList().Count;
            Assert.AreEqual(2, size);
        }

    }

}
