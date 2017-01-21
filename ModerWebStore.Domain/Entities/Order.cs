﻿using ModerWebStore.Domain.Enums;
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
        public IEnumerable<OrderItem> OrderItems
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
            if (item == null)
            {
                throw new Exception("Item inválido");
            }
            if (item.Price <= 0)
            {
                throw new Exception("Preço inválido");
            }
            if (item.Quantity <= 0)
            {
                throw new Exception("Quantidade inválida");
            }

            _orderItems.Add(item);
        }

    }

}
