using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.ToTable("empresa");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);

        builder.Property(x => x.Nit).HasColumnType("int");
        builder.HasIndex(x=>x.Nit).IsUnique();

        builder.Property(x => x.RazonSocial).IsRequired().HasMaxLength(50);

        builder.Property(x => x.RepresentanteLegal).IsRequired().HasMaxLength(50);

        builder.Property(x => x.FechaCreacion).HasColumnType("date");

        builder.Property(x => x.IdMun).HasColumnType("int");
        builder.HasOne(x => x.Municipios).WithMany(x => x.Empresas).HasForeignKey(x => x.IdMun);
    }
}