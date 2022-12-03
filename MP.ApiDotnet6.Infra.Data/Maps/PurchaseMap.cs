using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotnet6.Infra.Data.Maps
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Compra");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Idcompra").ValueGeneratedOnAdd();
            builder.Property(c => c.PersonId).HasColumnName("Idpessoa");
            builder.Property(c => c.ProductId).HasColumnName("Idproduto");
            builder.Property(c => c.Date).HasColumnName("Datacompra");

            builder.HasOne(c => c.Person).WithMany(p => p.Purchases);
            builder.HasOne(c => c.Product).WithMany(p => p.Purchases);
        }
    }
}