using Inventory.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.Configurations
{
    public class ItemEntityTypeConfiguration : IEntityTypeConfiguration<Item>
    {

        public void Configure(EntityTypeBuilder<Item> itemConfiguration)
        {



            itemConfiguration.Property(o => o.Id);
            itemConfiguration.HasKey(o => o.Id);
                

            itemConfiguration
                .Property<string>("_name")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired(true);

            itemConfiguration
                .Property(O => O.Name);
                

            itemConfiguration
              .Property<int>("_units")
              .UsePropertyAccessMode(PropertyAccessMode.Field)
              .IsRequired(true);

            itemConfiguration
                .Property<decimal>("_unitPrice")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired();

            itemConfiguration
               .Property<DateTime>("_expirationDate")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .IsRequired();

        }
    }
}
