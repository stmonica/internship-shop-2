using System.Collections.Generic;
using WebApplication2.Domain;

namespace WebApplication2.Business
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category Insert(Category category);
        Category Delete(int id);
        Category GetById(int id);
        Category Update(Category category);
        
    }
}
