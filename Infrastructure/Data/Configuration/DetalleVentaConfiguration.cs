using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
{
    public void Configure(EntityTypeBuilder<DetalleVenta> builder)
    {
        builder.ToTable("detalleventa");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);

        builder.Property(x => x.Cantidad).HasColumnType("int");

        builder.Property(x => x.ValorUnit).HasColumnType("double");

        builder.Property(x => x.IdVenta).HasColumnType("int");
        builder.HasOne(x => x.Ventas).WithMany(x => x.DetalleVentas).HasForeignKey(x => x.IdVenta);

        builder.Property(x => x.IdProducto).HasColumnType("int");
        builder.HasOne(x => x.Inventarios).WithMany(x => x.DetalleVentas).HasForeignKey(x => x.IdProducto);

        builder.Property(x => x.IdTalla).HasColumnType("int");
        builder.HasOne(x => x.Tallas).WithMany(x => x.DetalleVentas).HasForeignKey(x => x.IdTalla);
    }
}