using ModerWebStore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModerWebStore.Domain.Commands.OrderCommands;
using ModerWebStore.Domain.Entities;
using ModerWebStore.Domain.Repositories;
using ModernWebStore.Infra.Persistence;

namespace ModernWebStore.ApplicationService
{
    public class OrderApplicationService : ApplicationServiceBase, IOrderApplicationService
    {
        private IOrderRepository _orderRepository;
        private IUserRepository _userRepository;
        private IProductRepository _productRepository;

        public OrderApplicationService(
            IOrderRepository orderRepository, 
            IUserRepository userRepository,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._userRepository = userRepository;
            this._productRepository = productRepository;
            this._orderRepository = orderRepository;
        }

        public void Cancel(int id, string email)
        {
            var order = _orderRepository.GetHeader(id, email);
            order.Cancel();
            _orderRepository.Update(order);

            Commit();
        }

        public Order Create(CreateOrderCommand command, string email)
        {
            var user = _userRepository.GetByEmail(email);
            var ordersItems = new List<OrderItem>();
            foreach (var item in command.OrderItems)
            {
                var orderItem = new OrderItem();
                var product = _productRepository.Get(item.Product);
            }
        }

        public void Delivery(int id, string email)
        {
            throw new NotImplementedException();
        }

        public List<Order> Get(string email, int skip, int take)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCanceled(string email)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCreated(string email)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetDelivered(string email)
        {
            throw new NotImplementedException();
        }

        public Order GetDetails(int id, string email)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetPaid(string email)
        {
            throw new NotImplementedException();
        }

        public void Pay(int id, string email)
        {
            
        }
    }
}
