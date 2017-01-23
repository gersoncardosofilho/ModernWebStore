using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModerWebStore.Domain.Commands.OrderCommands
{
    public class CreateOrderCommand
    {
        public CreateOrderCommand(IList<CreateOrderCommand> orderItems)
        {
            this.OrderItems = orderItems;
        }

        public IList<CreateOrderCommand> OrderItems { get; private set; }
    }
}
