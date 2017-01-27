using ModerWebStore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModerWebStore.Domain.Commands.ProductCommands;
using ModerWebStore.Domain.Entities;
using ModerWebStore.Domain.Repositories;
using ModernWebStore.Infra.Persistence;

namespace ModernWebStore.ApplicationService
{
    public class ProductApplicationService : ApplicationServiceBase, IProductApplicationService
    {
        private IProductRepository _repository;

        public ProductApplicationService(IProductRepository repository, IUnitOfWork unityOfWork) : base(unityOfWork)
        {
            this._repository = repository;

        }

        public Product Create(CreateProductCommand command)
        {
            var product = new Product(command.Title, command.Description, command.Price, command.QuantityOnHand, command.CategoryId);
            product.Register();
            _repository.Create(product);

            if (Commit())
                return product;

            return null;
        }

        public Product Delete(int id)
        {
            var product = _repository.Get(id);
            _repository.Delete(product);
            if (Commit())
                return product;

            return null;
        }

        public List<Product> Get()
        {
            return _repository.Get();
        }

        public Product Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Product> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public List<Product> GetOutOfStock()
        {
            return _repository.GetProductOutOfStock();
        }

        public Product UpdateBasicInformation(UpdateProductInfoCommand command)
        {
            var product = _repository.Get(command.Id);
            product.UpdateInfo(command.Title, command.Description, command.CategoryId);
            _repository.Update(product);

            if (Commit())
                return product;

            return null;

        }
    }
}
