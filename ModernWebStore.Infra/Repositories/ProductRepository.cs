using ModerWebStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModerWebStore.Domain.Entities;
using ModernWebStore.Infra.DataContext;
using ModerWebStore.Domain.Specs;
using System.Data.Entity;

namespace ModernWebStore.Infra.Repositories
{
    class ProductRepository : IProductRepository
    {
        private StoreDataContext _context;

        public ProductRepository(StoreDataContext context)
        {
            this._context = context;
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }

        public List<Product> Get()
        {
            return _context.Products.ToList();
        }

        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }

        public List<Product> Get(int skip, int take)
        {
            return _context
                .Products
                .OrderBy(x => x.Title)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public List<Product> GetProductInStock()
        {
            return _context.Products
                        .Where(ProductSpecs.GetProductsInStock())
                        .ToList();
                    
        }

        public List<Product> GetProductOutOfStock()
        {
            return _context.Products
                        .Where(ProductSpecs.GetProductsOutOfStock())
                       .ToList();
        }

        public void Update(Product product)
        {
            _context.Entry<Product>(product).State = EntityState.Modified;
        }
    }
}
