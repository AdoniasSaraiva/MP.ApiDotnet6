using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotnet6.Infra.Data.Maps
{
    public  class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Idproduto").ValueGeneratedOnAdd();
            builder.Property(c => c.CodeErp).HasColumnName("Coderp");
            builder.Property(c => c.Name).HasColumnName("Nome");
            builder.Property(c => c.Price).HasColumnName("preco");

            builder.HasMany(c => c.Purchases).WithOne(p => p.Product).HasForeignKey(c => c.ProductId);
        }
    }
}
