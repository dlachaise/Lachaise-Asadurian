using System;
using System.Collections.Generic;
using Domain;
using DataAccess;
using BusinessLogicInterface;
using System.Linq;
namespace BusinessLogic
{
    public class PlaylistLogic : IPlaylistLogic
    {

       private IPlaylistRepository iPlayR;
        private PlaylistLogic playlistLogic;
        private IPlaylistLogic iPlaylistLogic;

        public PlaylistLogic(IPlaylistRepository PlayR)
        {
            this.iPlayR = PlayR;
        }

        public PlaylistLogic(PlaylistLogic playL)
        {
            this.playlistLogic = playL;
        }
        public PlaylistLogic(IPlaylistLogic playLogic)
        {
            this.iPlaylistLogic = playLogic;
        }
        public PlaylistLogic(IPlaylistRepository repository, IPlaylistLogic playlistsLogic)
        {
            this.iPlayR = repository;
            this.iPlaylistLogic = playlistsLogic;
        }

    public void CreatePlaylist(Playlist playlistToAdd){
            iPlayR.Add(playlistToAdd);
            iPlayR.Save();
       }
        public void Delete(Guid id)
        {
            Playlist playL = iPlayR.Get(id);

            if (playL != null)
            {
               // playL.IsActive= false;
                iPlayR.Remove(playL);
                iPlayR.Save();
            }
            else
            {
                throw new Exception("Playlist does not exist");
            }

        }

        public Playlist Get(Guid id)
        {
            Playlist playL = iPlayR.Get(id);
            if (playL != null /*&& playL.IsActive == true*/)
            {
                return playL;
            }
            else
            {
                throw new Exception("Playlist does not exist");
            }
        }

        public IEnumerable<Playlist> GetAll()
        {
            return this.iPlayR.GetAll();
        }
/*
        public IEnumerable<Playlist> GetByCategory(Guid categoryId){
            return iPlayR.GetByCategory(categoryId);
        }

       public IEnumerable<Playlist> GetByPlaylist(Guid idPlaylist){
           return iPlayR.GetByPlaylist(idPlaylist);
       }*/
    }
}