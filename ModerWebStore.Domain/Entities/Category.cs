using ModerWebStore.Domain.Scopes;

namespace ModerWebStore.Domain.Entities
{
    public class Category
    {
        public Category(string title)
        {
            this.Title = title;
       
        }

        public int Id { get; private set; }
        public string Title { get; private set; }

        public void Register()
        {
            if (!this.CreateCategoryScopeIsValid())
            {
                return;
            }
        }

        public void UpdateTitle(string title)
        {
            if (!this.UpdateCategoryScopeIsValid(title))
            {
                return;
            }
            this.Title = title;

        }
    }
}
