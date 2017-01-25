using ModerWebStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ModerWebStore.Domain.Specs
{
    public static class OrderSpecs
    {
        public static Expression<Func<Order, bool>> GetCreatedOrders(string email)
        {
            return x => x.User.Email == email && x.Status == Enums.EOrderStatus.Created;
        }

        public static Expression<Func<Order, bool>> GetPaidOrders(string email)
        {
            return x => x.User.Email == email && x.Status == Enums.EOrderStatus.Paid;
        }

        public static Expression<Func<Order, bool>> GetDeliveredOrders(string email)
        {
            return x => x.User.Email == email && x.Status == Enums.EOrderStatus.Delivered;
        }

        public static Expression<Func<Order, bool>> GetCanceledOrders(string email)
        {
            return x => x.User.Email == email && x.Status == Enums.EOrderStatus.Created;
        }

        public static Expression<Func<Order, bool>> GetOrderDetails(int id, string email)
        {
            return x => x.Id == id && x.User.Email == email;
        }

        public static Expression<Func<Order, bool>> GetOrdersFromUser(string email)
        {
            return x => x.User.Email == email;
        }
    }
}
