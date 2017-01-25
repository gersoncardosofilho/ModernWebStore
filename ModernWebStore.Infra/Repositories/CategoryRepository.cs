using ModerWebStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModerWebStore.Domain.Entities;
using ModernWebStore.Infra.DataContext;
using System.Data.Entity;

namespace ModernWebStore.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private StoreDataContext _context;

        public CategoryRepository(StoreDataContext context)
        {
            this._context = context;
        }

        public void Create(Category category)
        {
            _context.Categories.Add(category);
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
        }

        public List<Category> Get()
        {
            return _context.Categories.ToList();
        }

        public Category Get(int id)
        {
            return _context.Categories.Find(id);
        }

        public List<Category> Get(int skip, int take)
        {
            return _context.Categories
                .OrderBy(x => x.Title)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public void Update(Category category)
        {
            _context
                .Entry<Category>(category)
                .State = EntityState.Modified;
        }
    }
}
