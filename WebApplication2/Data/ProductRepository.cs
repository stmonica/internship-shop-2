using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Business;
using WebApplication2.Domain;

namespace WebApplication2.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext _context;
        public ProductRepository(ShopContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }
        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }


        public Product Insert(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }



        public Product Delete(int id)
        {
            var entity = _context.Products.Find(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Products.Remove(entity);
            _context.SaveChanges();

            return entity;
        }


        public Product Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
            return product;
        }
    }
}
