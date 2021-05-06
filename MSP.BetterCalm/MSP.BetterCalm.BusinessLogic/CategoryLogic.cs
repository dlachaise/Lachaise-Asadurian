using System;
using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Interface;
using MSP.BetterCalm.DataAccess.Interface;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public class CategoryLogic : ICategoryLogic
    {

        private IRepository<Category> iCategoryR;

        public CategoryLogic(IRepository<Category> categoryR)
        {
            this.iCategoryR = categoryR;
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
    }
}