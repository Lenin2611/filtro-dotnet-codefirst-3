using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
{
    public void Configure(EntityTypeBuilder<Inventario> builder)
    {
        builder.ToTable("inventario");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);

        builder.Property(x => x.CodInv).HasColumnType("int");
        builder.HasIndex(x=>x.CodInv).IsUnique();

        builder.Property(x => x.ValorVtaCop).HasColumnType("double");

        builder.Property(x => x.ValorVtaUsd).HasColumnType("double");

        builder.Property(x => x.IdPrenda).HasColumnType("int");
        builder.HasOne(x => x.Prendas).WithMany(x => x.Inventarios).HasForeignKey(x => x.IdPrenda);
    }
}