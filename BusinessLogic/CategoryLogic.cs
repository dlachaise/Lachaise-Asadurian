using System;
using System.Collections.Generic;
using Domain;
using DataAccess;
using BusinessLogicInterface;
using System.Linq;
namespace BusinessLogic
{
    public class CategoryLogic : ICategoryLogic
    {

       private ICategoryRepository iCategoryR;
        private CategoryLogic categoryLogic;
        private ICategoryLogic iCategorylogic;

        public CategoryLogic(ICategoryRepository categoryR)
        {
            this.iCategoryR = categoryR;
        }

        public CategoryLogic(CategoryLogic categoryL)
        {
            this.categoryLogic = categoryL;
        }
        public CategoryLogic(ICategoryLogic categoryLogic)
        {
            this.iCategorylogic = categoryLogic;
        }
        public CategoryLogic(ICategoryRepository repository, ICategoryLogic categoryLogic)
        {
            this.iCategoryR = repository;
            this.iCategorylogic = categoryLogic;
        }

        public Category Get(Guid id)
        {
            Category category = iCategoryR.Get(id);
            if (category != null)
            {
                return category;
            }
            else
            {
                throw new Exception("Category does not exist");
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return this.iCategoryR.GetAll();
        }






    /*public void CreateCategory(Playlist playlistToAdd){
            iCategoryR.Add(playlistToAdd);
            iCategoryR.Save();
       }
        public void Delete(Guid id)
        {
            Playlist playL = iCategoryR.Get(id);

            if (playL != null)
            {
               // playL.IsActive= false;
                iCategoryR.Remove(playL);
                iCategoryR.Save();
            }
            else
            {
                throw new Exception("Playlist does not exist");
            }

        }*/
    }
}