using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class InsumoConfiguration : IEntityTypeConfiguration<Insumo>
{
    public void Configure(EntityTypeBuilder<Insumo> builder)
    {
        builder.ToTable("insumo");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);

        builder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);
        builder.HasIndex(x=>x.Nombre).IsUnique();

        builder.Property(x => x.ValorUnit).HasColumnType("double");

        builder.Property(x => x.StockMin).HasColumnType("int");

        builder.Property(x => x.StockMax).HasColumnType("int");
    }
}