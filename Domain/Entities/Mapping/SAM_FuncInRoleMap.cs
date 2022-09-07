using Domain.Entities.TableClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.Mapping
{
    public class SAM_FuncInRoleMap : IEntityTypeConfiguration<SAM_FuncInRole>
    {
        public void Configure(EntityTypeBuilder<SAM_FuncInRole> entity)
        {
            entity.HasKey(e => e.FID);

            entity.ToTable("SAM_FuncInRole");
            entity.Property(e => e.FID).HasColumnName("FID");

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

            entity.Property(e => e.RoleID).HasColumnName("RoleID");

            entity.Property(e => e.FuncID).HasColumnName("FuncID");

            entity.HasOne(d => d.Role)
                  .WithMany(p => p.SamFuncInRole)
                  .HasForeignKey(d => d.RoleID);
            entity.HasOne(d => d.Function)
                  .WithMany(p => p.SamFuncInRole)
                  .HasForeignKey(d => d.FuncID);
        }
    }
}
