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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        public ProductListRepresentation GetAll()
        {
            var dbProducts = _repo.GetAll();

            return new ProductListRepresentation(dbProducts);
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public ProductRepresentation GetById(int id, string name, string description, decimal price, decimal basePrice, int categoryId, string filename)
        {
            var dbProducts = _repo.GetById(id);

            return new ProductRepresentation(dbProducts.ProductID, dbProducts.Name, dbProducts.Description, dbProducts.Price, dbProducts.BasePrice, dbProducts.CategoryID, dbProducts.FileName);

        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public ProductRepresentation Put(Product product)
        {
            var dbProducts = _repo.Update(product);

            return new ProductRepresentation(dbProducts.ProductID, dbProducts.Name, dbProducts.Description, dbProducts.Price, dbProducts.BasePrice, dbProducts.CategoryID, dbProducts.FileName);


        }

        // POST: api/[controller]
        [HttpPost]
        public ProductRepresentation Post(Product product)
        {
            var dbProducts = _repo.Insert(product);

            return new ProductRepresentation(dbProducts.ProductID, dbProducts.Name, dbProducts.Description, dbProducts.Price, dbProducts.BasePrice, dbProducts.CategoryID, dbProducts.FileName);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            var dbProducts = _repo.Delete(id);


        }


    }
}
