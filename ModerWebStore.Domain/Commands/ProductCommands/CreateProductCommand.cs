using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModerWebStore.Domain.Commands.ProductCommands
{
    public class CreateProductCommand
    {
        public CreateProductCommand(string title, string description, decimal price, int quantityOnHand, int categoryId)
        {
            this.Title = title;
            this.Description = description;
            this.Price = price;
            this.QuantityOnHand = quantityOnHand;
            this.CategoryId = categoryId;
        }

        public int CategoryId { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int QuantityOnHand { get; private set; }
        public string Title { get; private set; }
    }
}
