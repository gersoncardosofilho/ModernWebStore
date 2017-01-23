namespace ModerWebStore.Domain.Commands.ProductCommands
{
    public class UpdateProductInfoCommand
    {
        public UpdateProductInfoCommand(int id, string title, string description, int categoryId)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.CategoryId = categoryId;
        }

        public int CategoryId { get; private set; }
        public string Description { get; private set; }
        public int Id { get; private set; }
        public string Title { get; private set; }
    }
}
