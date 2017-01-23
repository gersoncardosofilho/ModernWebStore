using ModerWebStore.Domain.Scopes;
using System;

namespace ModerWebStore.Domain.Entities
{
    public class OrderItem
    {
        public OrderItem()
        {
        }

        public int Id { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public int ProductId { get; private set; }
        public Product Product { get; private set; }

        public int OerderId { get; private set; }
        public Order Order { get; private set; }
        
        public bool Register()
        {
            return this.RegisterOrderItemScopeIsValid();
        }

        public void AddProduct(Product product, int quantity, decimal price)
        {
            if (!this.AddProductScopeIsValid(product, price, quantity))
                return;

            this.ProductId = ProductId;
            this.Product = product;
            this.Quantity = quantity;
            this.Price = price;

            //reserva o estoque
            this.Product.UpdateQuantityOnHand(this.Product.QuantityOnHand - quantity);
        }

   

    }
}