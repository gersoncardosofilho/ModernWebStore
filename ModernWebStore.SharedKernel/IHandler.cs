using ModernWebStore.SharedKernel.Events.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModernWebStore.SharedKernel
{
    public interface IHandler<T> : IDisposable where T : IDomainEvent
    {
        void Handle(Task args);
        IEnumerable<T> Notify();
        bool HasNotifications();
        void Handle<T>(T args) where T : IDomainEvent;
    }
}
