using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModerWebStore.Domain.Commands.CategoryCommands
{
    public class CreateCategoryCommand
    {
        public CreateCategoryCommand(string title)
        {
            this.Title = title;
        }

        public string Title { get; private set; }
    }
}
