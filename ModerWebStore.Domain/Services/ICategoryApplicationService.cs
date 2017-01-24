using ModerWebStore.Domain.Commands.CategoryCommands;
using ModerWebStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModerWebStore.Domain.Services
{
    public interface ICategoryApplicationService
    {
        List<Category> Get();
        List<Category> Get(int skip, int take);
        Category Get(int id);
        Category Create(CreateCategoryCommand command);
        Category Update(EditCategoryCommand command);
        Category Delete(int id);
    }
}
