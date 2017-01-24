using ModerWebStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModerWebStore.Domain.Repositories
{
    public interface IProductRepository
    {
        List<Product> Get();
        List<Product> Get(int skip, int take);
        List<Product> GetProductInStock();
        List<Product> GetProductOutOfStock();
        Product Get(int id);
        void Create(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
