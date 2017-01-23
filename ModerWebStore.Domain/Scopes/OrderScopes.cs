using DomainNotificationHelper.Validation;
using ModerWebStore.Domain.Entities;
using System.Linq;

namespace ModerWebStore.Domain.Scopes
{
    public static class OrderScopes
    {
        public static bool PlaceOrderScopeIsValid(this Order order)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertIsGreaterThan(order.OrderItems.Count(), 0, "Nenhum pedido pode ter itens do pedido igual a zero")
                );
        }
    }
}
