using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernWebStore.SharedKernel.Events.Contracts
{
    public interface IDomainEvent
    {
        DateTime DateOcurred { get; }
    }
}
