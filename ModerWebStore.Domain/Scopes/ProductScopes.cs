using DomainNotificationHelper.Validation;
using ModerWebStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModerWebStore.Domain.Scopes
{
    public static class ProductScopes
    {
        public static bool RegisterProductScopeIsValid(this Product product)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotNull(product.Title, "O título do produto é obrigatório"),
                    AssertionConcern.AssertNotNull(product.Description, "A descrição do produto é obrigatória"),
                    AssertionConcern.AssertIsGreaterThan(product.Price, 0, "O preço do produto não pode ser zero"),
                    AssertionConcern.AssertIsGreaterThan(product.CategoryId, 0, "A categoria do produtro é obrigatória"),
                    AssertionConcern.AssertIsGreaterThan(product.QuantityOnHand, 0 , "A quantidade do produto não pode ser zero")
                );
        }

        public static bool UpdateQuantityOnHandScopeIsValid(this Product product, int quantity)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertIsGreaterOrEqualThan(quantity, 0, "A quantidade do produto deve ser maior ou igual a zero.")
                );
        }

        public static bool UpdatePriceScopeIsValid(this Product product, decimal price)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertIsGreaterThan(price, 0, "O valor do produto deve ser maior que zero")
                );
        }

        public static bool UpdateInfoScopeIsValid(this Product product, string title, string description, int category)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertIsGreaterThan(category, 0, "A categoria do produto deve ser maior que zero"),
                    AssertionConcern.AssertIsNull(title, "O título do produto é obrigatório"),
                    AssertionConcern.AssertIsNull(description, "A descrição do produto é obrigatória")
                );
        }

    }
}
