using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("empleado");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);

        builder.Property(x => x.IdEmpleado).HasColumnType("int");
        builder.HasIndex(x=>x.IdEmpleado).IsUnique();

        builder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);

        builder.Property(x => x.FechaIngreso).HasColumnType("date");

        builder.Property(x => x.IdCargo).HasColumnType("int");
        builder.HasOne(x => x.Cargos).WithMany(x => x.Empleados).HasForeignKey(x => x.IdCargo);

        builder.Property(x => x.IdMunicipio).HasColumnType("int");
        builder.HasOne(x => x.Municipios).WithMany(x => x.Empleados).HasForeignKey(x => x.IdMunicipio);
    }
}