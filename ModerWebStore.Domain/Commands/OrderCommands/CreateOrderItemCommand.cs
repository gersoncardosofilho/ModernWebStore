namespace ModerWebStore.Domain.Commands.OrderCommands
{
    public class CreateOrderItemCommand
    {
        public CreateOrderItemCommand(int quantity, decimal price, int product)
        {
            this.Quantity = quantity;
            this.Price = price;
            this.Product = product;
        }

        public decimal Price { get; private set; }
        public int Product { get; private set; }
        public int Quantity { get; private set; }
    }
}
