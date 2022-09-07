using Domain.Entities.TableClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.Mapping
{

    public class MD_CustomerMap : IEntityTypeConfiguration<MD_Customer>
    {
        public void Configure(EntityTypeBuilder<MD_Customer> entity)
        {
            entity.HasKey(e => e.CustomerID);

            entity.ToTable("MD_Customer");

            entity.Property(e => e.CustomerID).HasColumnName("CustomerID");

            entity.Property(e => e.Address).HasMaxLength(100);

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.Property(e => e.CreatedUser)
                .HasMaxLength(125)
                .IsUnicode(false);

            entity.Property(e => e.CustomerCode)
                .HasMaxLength(50)
                .IsUnicode(false);


            entity.Property(e => e.FullName).HasMaxLength(50);

            entity.Property(e => e.TaxCode)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsBlocked)
                     .HasColumnType("bit");
            entity.Property(e => e.UpdatedUser)
                .HasMaxLength(125)
                .IsUnicode(false);
        }
    }
}
