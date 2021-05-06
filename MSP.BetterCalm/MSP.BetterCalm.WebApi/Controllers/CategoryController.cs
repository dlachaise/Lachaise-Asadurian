using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic.Interface;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebApi.Models;
using MSP.BetterCalm.WebApi.Filters;

namespace MSP.BetterCalm.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : BetterCalm
    {
        private readonly ICategoryLogic categoryLogic;
        public CategoryController(ICategoryLogic logic) : base()
        {
            this.categoryLogic = logic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<CategoryDTO> Categories = this.categoryLogic.GetAll().Select(cat => new CategoryDTO(cat));

            return Ok(Categories);
        }


        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Category category = this.categoryLogic.Get(id);

            if (category != null)
            {
                return Ok(new CategoryDTO(category));
            }
            else
            {
                return NotFound("Category not found with id: " + id);

            }
        }
    }
}