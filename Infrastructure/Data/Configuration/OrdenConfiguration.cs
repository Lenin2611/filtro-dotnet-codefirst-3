using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class OrdenConfiguration : IEntityTypeConfiguration<Orden>
{
    public void Configure(EntityTypeBuilder<Orden> builder)
    {
        builder.ToTable("orden");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);

        builder.Property(x => x.Fecha).HasColumnType("date");

        builder.Property(x => x.IdCliente).HasColumnType("int");
        builder.HasOne(x => x.Clientes).WithMany(x => x.Ordenes).HasForeignKey(x => x.IdCliente);

        builder.Property(x => x.IdEmpleado).HasColumnType("int");
        builder.HasOne(x => x.Empleados).WithMany(x => x.Ordenes).HasForeignKey(x => x.IdEmpleado);

        builder.Property(x => x.IdEstado).HasColumnType("int");
        builder.HasOne(x => x.Estados).WithMany(x => x.Ordenes).HasForeignKey(x => x.IdEstado);
    }
}