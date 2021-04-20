using System;
using Domain;
using  System.Collections.Generic;
using  System.Linq;
using  Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AudioRepository : IAudioRepository
    {
       
		protected  DataContext  Context {get; set;}
		public  AudioRepository(DataContext  context)
		{
			Context = context;
		}

		public  Audio  Get(Guid  id)
		{
			return  Context.Set<Audio>().First(x => x.Id == id);
		}

		public  IEnumerable<Audio> GetAll()
		{
			return  Context.Set<Audio>().ToList();
		}

		  public IEnumerable<Audio> GetByCategory(Guid categoryId)
        {
			var category = Context.Set<Category>().Include(x => x.Audios).Where(x => x.Id == categoryId).First();
            return category.Audios.ToList();
        }

		public  void  Add(Audio  entity) 
		{
			Context.Set<Audio>().Add(entity);
		}

		public  void  Remove(Audio  entity) 
		{
			Context.Set<Audio>().Remove(entity);
		}


		public  void  Save() 
		{
			Context.SaveChanges();
		}
	}
}
    

