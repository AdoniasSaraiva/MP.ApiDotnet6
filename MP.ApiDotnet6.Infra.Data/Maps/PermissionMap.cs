using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotnet6.Infra.Data.Maps
{
    public class PermissionMap : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("PermissionId").ValueGeneratedOnAdd();
            builder.Property(x => x.VisualName).HasColumnName("VisualName");
            builder.Property(x => x.PermissionName).HasColumnName("PermissionName");

            builder.HasMany(x => x.UserPermissions).WithOne(p => p.Permission).HasForeignKey(p => p.PermissionId);
        }
    }
}
