using Domain.Entities.TableClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.Mapping
{
    public class SAM_ModuleMap : IEntityTypeConfiguration<SAM_Module>
    {
        public void Configure(EntityTypeBuilder<SAM_Module> entity)
        {
            entity.HasKey(e => e.ModuleID);

            entity.ToTable("SAM_Module");
            entity.Property(e => e.ModuleID)
                  .HasColumnName("ModuleID");

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

            entity.Property(e => e.ModuleCode).HasMaxLength(50);

            entity.Property(e => e.ModuleDesc).HasMaxLength(50);

            entity.Property(e => e.Icon).HasMaxLength(250);

            entity.Property(e => e.OrderNo);

        }
    }
}
