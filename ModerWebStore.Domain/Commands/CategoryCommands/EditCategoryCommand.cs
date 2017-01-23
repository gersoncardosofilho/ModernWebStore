using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModerWebStore.Domain.Commands.CategoryCommands
{
    public class EditCategoryCommand
    {
        public EditCategoryCommand(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
    }
}
