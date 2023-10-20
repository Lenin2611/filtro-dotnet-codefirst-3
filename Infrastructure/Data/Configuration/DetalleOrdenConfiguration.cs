using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class DetalleOrdenConfiguration : IEntityTypeConfiguration<DetalleOrden>
{
    public void Configure(EntityTypeBuilder<DetalleOrden> builder)
    {
        builder.ToTable("detalleorden");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);

        builder.Property(x => x.CantidadProducir).HasColumnType("int");

        builder.Property(x => x.CantidadProducida).HasColumnType("int");

        builder.Property(x => x.IdOrden).HasColumnType("int");
        builder.HasOne(x => x.Ordenes).WithMany(x => x.DetalleOrdenes).HasForeignKey(x => x.IdOrden);

        builder.Property(x => x.IdPrenda).HasColumnType("int");
        builder.HasOne(x => x.Prendas).WithMany(x => x.DetalleOrdenes).HasForeignKey(x => x.IdPrenda);

        builder.Property(x => x.IdColor).HasColumnType("int");
        builder.HasOne(x => x.Colores).WithMany(x => x.DetalleOrdenes).HasForeignKey(x => x.IdColor);

        builder.Property(x => x.IdEstado).HasColumnType("int");
        builder.HasOne(x => x.Estados).WithMany(x => x.DetalleOrdenes).HasForeignKey(x => x.IdEstado);
    }
}