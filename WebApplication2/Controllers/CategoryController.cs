using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication2.Business;
using WebApplication2.Domain;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;

        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<CategoryListRepresentation>> GetAll()
        {
            try
            {
                var dbCategories = _repo.GetAll();

                return new CategoryListRepresentation(dbCategories);
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
           
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryRepresentation>> GetById(int id)
        {
            
            try
            {

                var dbCategories = await _repo.GetById(id);
                if (dbCategories == null)
                {
                  
                    return NotFound($"Category with ID = {id} not found");
                }

                return new CategoryRepresentation(dbCategories.CategoryID, dbCategories.Name, dbCategories.Description);


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }

        }

        // PUT: api/[controller]/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<CategoryRepresentation>> Put(int id, Category category)
        {
           
            try
            {
                if (id != category.CategoryID)
                {
                    return BadRequest("Category ID mismatch");
                }

                var categoryToUpdate = await _repo.GetById(id);
                if (categoryToUpdate == null)
                {
                    return NotFound($"Category with ID = {id} not found");
                }
                    var dbCategories = await _repo.Update(category);

                    return new CategoryRepresentation(dbCategories.CategoryID, dbCategories.Name, dbCategories.Description);

                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }

        }
    

        // POST: api/[controller]
        [HttpPost]
        public CategoryRepresentation Post(CategoryRepresentation category)
       {
            var catToInsert = new Category() { Description = category.Description, Name = category.Name };
            var dbCategories = _repo.Insert(catToInsert);

            return new CategoryRepresentation(dbCategories.CategoryID, dbCategories.Name, dbCategories.Description);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public void  Delete(int id)
        {
            var dbCategories = _repo.Delete(id);

        }


    }
}
