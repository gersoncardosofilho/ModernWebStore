using ModerWebStore.Domain.Enums;
using ModerWebStore.Domain.Scopes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModerWebStore.Domain.Entities
{
    public class Order
    {
        private IList<OrderItem> _orderItems;

        public Order(IList<OrderItem> orderItems, int userId)
        {
           this.OrderDate = DateTime.Now;
           this._orderItems = new List<OrderItem>();
           orderItems.ToList().ForEach(x => AddItem(x));
           this.UserId = userId;
           this.Status = EOrderStatus.Created;
        }

        public int Id { get; private set; }
        public DateTime OrderDate { get; private set; }
        public ICollection<OrderItem> OrderItems
        {
            get { return _orderItems; }
            private set { _orderItems = new List<OrderItem>(value); }
        }

        public int UserId { get; private set; }
        public User User { get; private set; }

        public EOrderStatus Status { get; private set; }

        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (var item in _orderItems)
                {
                    total += (item.Price * item.Quantity);                
                }
                return total;
            }

        }

        public void AddItem(OrderItem item)
        {
            if (item.Register())
                _orderItems.Add(item);
        }

        public void Place()
        {
            if (!this.PlaceOrderScopeIsValid())
                return;
        }

        public void MarkAsPaid()
        {
            //Baixa no estoque
            this.Status = EOrderStatus.Paid;
        }

        public void MarkAsDelivered()
        {
            this.Status = EOrderStatus.Delivered;
        }

        public void Cancel()
        {
            this.Status = EOrderStatus.Cancelled;
        }
    }

}
