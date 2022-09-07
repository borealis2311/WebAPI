using Domain.Entities.TableClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.Mapping
{
    public class SAM_RoleMap : IEntityTypeConfiguration<SAM_Role>
    {
        public void Configure(EntityTypeBuilder<SAM_Role> entity)
        {
            entity.HasKey(e => e.RoleID);

            entity.ToTable("SAM_Role");

            entity.Property(e => e.RoleID).HasColumnName("RoleID");
            entity.Property(e => e.RoleName)
                .HasColumnName("RoleName")
                .HasMaxLength(100);

            entity.Property(e => e.RoleNotes)
                .HasColumnName("RoleNotes")
                .HasMaxLength(1000);

            entity.Property(e => e.RoleCode)
                .HasColumnName("RoleCode")
                .HasMaxLength(50);

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.Property(e => e.CreatedUser)
                .HasMaxLength(125)
                .IsUnicode(false);

            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.Property(e => e.UpdatedUser)
                .HasMaxLength(125)
                .IsUnicode(false);

            entity.Property(e => e.IsBlocked)
                  .HasColumnName("IsBlocked")
                  .HasColumnType("bit");
        }
    }
}
