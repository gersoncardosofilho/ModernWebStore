using ModerWebStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModerWebStore.Domain.Repositories
{
    public interface IOrderRepository
    {
        List<Order> Get(string email, int skip, int take);
        List<Order> GetCreated(string email);
        List<Order> GetPaid(string email);
        List<Order> GetDelivered(string email);
        List<Order> GetCanceled(string email);
        Order GetDetails(int id, string email);
        Order GetHeader(int id, string email);
        void Create(Order order);
        void Update(Order order);
    }
}
