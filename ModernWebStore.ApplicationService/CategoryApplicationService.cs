using ModerWebStore.Domain.Services;
using System.Collections.Generic;
using ModerWebStore.Domain.Commands.CategoryCommands;
using ModerWebStore.Domain.Entities;
using ModerWebStore.Domain.Repositories;
using ModernWebStore.Infra.Persistence;

namespace ModernWebStore.ApplicationService
{
    public class CategoryApplicationService : ApplicationServiceBase, ICategoryApplicationService
    {
        private ICategoryRepository _repository;

        public CategoryApplicationService(ICategoryRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }

        public Category Create(CreateCategoryCommand command)
        {
            var category = new Category(command.Title);
            category.Register();
            _repository.Create(category);

            if (Commit())
                return category;

            return null;
        }

        public Category Delete(int id)
        {
            var category = _repository.Get(id);
            if (Commit())
                return category;

            return null;
        }

        public List<Category> Get()
        {
            return _repository.Get();
        }

        public Category Get(int id)
        {
            return _repository.Get(id);

        }

        public List<Category> Get(int skip, int take)
        {
            return _repository.Get(skip, take);

        }

        public Category Update(EditCategoryCommand command)
        {
            var category = _repository.Get(command.Id);
            category.UpdateTitle(command.Title);
            _repository.Update(category);

            if (Commit())
                return category;

            return null;
        }
    }
}
