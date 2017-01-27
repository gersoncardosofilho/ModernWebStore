using ModerWebStore.Domain.Commands.CategoryCommands;
using ModerWebStore.Domain.Entities;
using System.Collections.Generic;

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
