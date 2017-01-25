﻿using ModerWebStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModerWebStore.Domain.Entities;
using ModernWebStore.Infra.DataContext;
using ModerWebStore.Domain.Specs;
using System.Data.Entity;

namespace ModernWebStore.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private StoreDataContext _context;

        public OrderRepository(StoreDataContext context)
        {
            this._context = context;
        }

        public void Create(Order order)
        {
            _context.Orders.Add(order);
        }

        public List<Order> Get(string email, int skip, int take)
        {
            return _context.Orders
                .Where(OrderSpecs.GetOrdersFromUser(email))
                .OrderByDescending(x => x.OrderDate)
                .Skip(skip)
                .Take(take)
                .ToList(); 
        }

        public List<Order> GetCanceled(string email)
        {
            return _context.Orders
                .Where(OrderSpecs.GetCanceledOrders(email))
                .OrderByDescending(x => x.OrderDate)
                .ToList();

        }

        public List<Order> GetCreated(string email)
        {
            return _context.Orders
                .Where(OrderSpecs.GetCreatedOrders(email))
                .OrderByDescending(x => x.OrderDate)
                .ToList();
        }

        public List<Order> GetDelivered(string email)
        {
            return _context.Orders
                .Where(OrderSpecs.GetDeliveredOrders(email))
                .OrderByDescending(x => x.OrderDate)
                .ToList();
        }

        public Order GetDetails(int id, string email)
        {
            return _context.Orders
                .Include(x => x.OrderItems)
                .Where(OrderSpecs.GetOrderDetails(id, email))
                .FirstOrDefault();
        }

        public Order GetHeader(int id, string email)
        {
            return _context.Orders
                .Where(OrderSpecs.GetOrderDetails(id, email))
                .FirstOrDefault();
        }

        public List<Order> GetPaid(string email)
        {
            return _context.Orders
                .Where(OrderSpecs.GetPaidOrders(email))
                .OrderByDescending(x => x.OrderDate)
                .ToList();
        }

        public void Update(Order order)
        {
            _context.Entry<Order>(order).State = EntityState.Modified;
        }
    }
}
