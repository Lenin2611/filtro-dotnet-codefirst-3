using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class InventarioTallaConfiguration : IEntityTypeConfiguration<InventarioTalla>
{
    public void Configure(EntityTypeBuilder<InventarioTalla> builder)
    {
        builder.ToTable("inventariotalla");

        builder.HasKey(e => new { e.IdInv, e.IdTalla });

        builder.Property(x => x.Cantidad).HasColumnType("int");

        builder.Property(x => x.IdInv).HasColumnType("int");
        builder.HasOne(x => x.Inventarios).WithMany(x => x.InventarioTallas).HasForeignKey(x => x.IdInv);

        builder.Property(x => x.IdTalla).HasColumnType("int");
        builder.HasOne(x => x.Tallas).WithMany(x => x.InventarioTallas).HasForeignKey(x => x.IdTalla);
    }
}