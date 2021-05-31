using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Domain;

namespace WebApplication2.Business
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product Insert(Product product);
        Product Delete(int id);
        Product GetById(int id);
        Product Update(Product product);

    }
}
