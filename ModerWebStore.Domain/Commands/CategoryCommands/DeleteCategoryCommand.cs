namespace ModerWebStore.Domain.Commands.CategoryCommands
{
    public class DeleteCategoryCommand
    {
        public DeleteCategoryCommand(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
    }
}
