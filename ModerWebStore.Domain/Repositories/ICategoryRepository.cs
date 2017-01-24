using ModerWebStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModerWebStore.Domain.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> Get();

        //Utilizado para paginação
        List<Category> Get(int skip, int take);

        Category Get(int id);
        void Create(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
