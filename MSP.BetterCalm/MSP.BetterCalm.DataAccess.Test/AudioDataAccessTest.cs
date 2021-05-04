﻿using MSP.BetterCalm.DataAccess;
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
    public class AudioDataAccessTest
    {
        private DataContext context;
        private Audio audio;
        private Repository<Audio> audioRepo;

        [TestInitialize]
        public void InitTest()
        {
            Guid id = new Guid();
            audio = new Audio()
            {
                Id = id,
                Name = "Eres Mia",
                Duration = 124,
                CreatorName = "Rome Santos",
                ImageUrl = "/Desktop/ImagenesAudio/EresMia.png",
                AudioUrl = "www.betterCalm.com.uy/EresMia.mp3",
                IsActive = true
            };

        }

        private void CreateDataBase(string name)
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: name)
            .Options;

            context = new DataContext(options);

            context.Set<Audio>().Add(audio);
            context.SaveChanges();

            audioRepo = new Repository<Audio>(context);
        }

        [TestMethod]
        public void GetAudio()
        {
            CreateDataBase("GetAudioTestDB");
            int size = audioRepo.GetAll().ToList().Count;
            Assert.AreEqual(1, size);
        }


        [TestMethod]
        public void InsertAudio()
        {
            Guid id = new Guid();
            Audio audio = new Audio()
            {
                Id = id,
                Name = "Dime que sera",
                Duration = 100,
                CreatorName = "Rome Santos",
                ImageUrl = "/Desktop/ImagenesAudio/dimeQSera.png",
                AudioUrl = "www.betterCalm.com.uy/dimeQSera.mp3",
                IsActive = true
            };

            CreateDataBase("InsertAudioTestDB");
            audioRepo.Create(audio);
            audioRepo.Save();
            int size = audioRepo.GetAll().ToList().Count;
            Assert.AreEqual(2, size);
        }

        [TestMethod]
        public void DeleteAudio()
        {
            CreateDataBase("DeleteAudioTestDB");
            audioRepo.Delete(audio);
            audioRepo.Save();
            int size = audioRepo.GetAll().ToList().Count;
            Assert.AreEqual(0, size);
        }

    }

}
