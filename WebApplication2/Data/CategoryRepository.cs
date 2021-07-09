using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Business;
using WebApplication2.Domain;

namespace WebApplication2.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopContext _context;
        public CategoryRepository(ShopContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
        public async Task<Category> GetById(int id)
        {
            return  await  _context.Categories
                .FirstOrDefaultAsync(e =>e.CategoryID == id);

        }


        public Category Insert(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }

       

        public Category Delete(int id)
        {
            var entity =  _context.Categories.Find(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Categories.Remove(entity);
            _context.SaveChanges();

            return entity;
        }
      

        public async Task<Category> Update( Category category)
        {
            var result = await _context.Categories
                 .FirstOrDefaultAsync(e => e.CategoryID == category.CategoryID);

            if (result != null)
            {
                result.Name = category.Name;
                result.Description = category.Description;

                await _context.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
