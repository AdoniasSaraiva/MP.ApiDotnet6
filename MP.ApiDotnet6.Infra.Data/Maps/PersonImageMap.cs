using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotnet6.Infra.Data.Maps
{
    public class PersonImageMap : IEntityTypeConfiguration<PersonImage>
    {
        public void Configure(EntityTypeBuilder<PersonImage> builder)
        {
            builder.ToTable("PersonImage");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("PersonImageId").ValueGeneratedOnAdd();
            builder.Property(x => x.PersonId).HasColumnName("IdPessoa");
            builder.Property(x => x.ImageBase).HasColumnName("ImageBase");
            builder.Property(x => x.ImageUri).HasColumnName("ImgUrl");


            builder.HasOne(x => x.Person).WithMany(x => x.PersonImages);
        }
    }
}
