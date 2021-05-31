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
        public CategoryListRepresentation GetAll()
        {
            var dbCategories = _repo.GetAll();

            return new CategoryListRepresentation(dbCategories);
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public CategoryRepresentation GetById(int id)
        {
            var dbCategories = _repo.GetById(id);

            return new CategoryRepresentation(dbCategories.CategoryID, dbCategories.Name);

        }

        // PUT: api/[controller]/5
        [HttpPut]
        public CategoryRepresentation Put(Category category)
        {
            var dbCategories = _repo.Update(category);

            return new CategoryRepresentation(dbCategories.CategoryID, dbCategories.Name);


        }

        // POST: api/[controller]
        [HttpPost]
        public CategoryRepresentation Post(Category category)
        {
            var dbCategories = _repo.Insert(category);

            return new CategoryRepresentation(dbCategories.CategoryID, dbCategories.Name);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public void  Delete(int id)
        {
            var dbCategories = _repo.Delete(id);

        }


    }
}
