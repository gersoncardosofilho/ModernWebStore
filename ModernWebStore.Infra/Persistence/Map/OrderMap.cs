using ModerWebStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernWebStore.Infra.Persistence.Map
{
    public class OrderMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable("Order");

            HasKey(x => x.Id);

            Property(x => x.OrderDate).IsRequired();
            Property(x =>x.Status).IsRequired();
            Property(x => x.Total);

            HasRequired(x => x.User);
            HasMany(x => x.OrderItems)
                .WithRequired(x => x.Order);
        }
    }
}
