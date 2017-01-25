using ModerWebStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernWebStore.Infra.Persistence.Map
{
    public class CategoryMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable("Category");
            HasKey(x => x.Id);
            Property(x => x.Title)
                .HasMaxLength(60)
                .IsRequired();
        }
    }
}
