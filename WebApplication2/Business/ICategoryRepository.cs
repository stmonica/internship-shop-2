using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Domain;

namespace WebApplication2.Business
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category Insert(Category category);
        Category Delete(int id);
        Task<Category> GetById(int id);
        Task<Category> Update(Category category);
        
    }
}
