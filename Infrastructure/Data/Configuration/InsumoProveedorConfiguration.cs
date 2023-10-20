using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class InsumoProveedorConfiguration : IEntityTypeConfiguration<InsumoProveedor>
{
    public void Configure(EntityTypeBuilder<InsumoProveedor> builder)
    {
        builder.ToTable("insumoproveedor");

        builder.HasKey(e => new { e.IdInsumo, e.IdProveedor });

        builder.Property(x => x.IdInsumo).HasColumnType("int");
        builder.HasOne(x => x.Insumos).WithMany(x => x.InsumoProveedores).HasForeignKey(x => x.IdInsumo);

        builder.Property(x => x.IdProveedor).HasColumnType("int");
        builder.HasOne(x => x.Proveedores).WithMany(x => x.InsumoProveedores).HasForeignKey(x => x.IdProveedor);
    }
}