using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class PrendaConfiguration : IEntityTypeConfiguration<Prenda>
{
    public void Configure(EntityTypeBuilder<Prenda> builder)
    {
        builder.ToTable("prenda");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);

        builder.Property(x => x.IdPrenda).HasColumnType("int");
        builder.HasIndex(x=>x.IdPrenda).IsUnique();

        builder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);

        builder.Property(x => x.ValorUnitCop).HasColumnType("double");

        builder.Property(x => x.ValorUnitUsd).HasColumnType("double");

        builder.Property(x => x.IdEstado).HasColumnType("int");
        builder.HasOne(x => x.Estados).WithMany(x => x.Prendas).HasForeignKey(x => x.IdEstado);

        builder.Property(x => x.IdTipoProteccion).HasColumnType("int");
        builder.HasOne(x => x.TipoProtecciones).WithMany(x => x.Prendas).HasForeignKey(x => x.IdTipoProteccion);

        builder.Property(x => x.IdGenero).HasColumnType("int");
        builder.HasOne(x => x.Generos).WithMany(x => x.Prendas).HasForeignKey(x => x.IdGenero);
    }
}