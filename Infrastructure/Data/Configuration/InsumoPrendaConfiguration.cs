using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class InsumoPrendaConfiguration : IEntityTypeConfiguration<InsumoPrenda>
{
    public void Configure(EntityTypeBuilder<InsumoPrenda> builder)
    {
        builder.ToTable("insumoprenda");

        builder.HasKey(e => new { e.IdInsumo, e.IdPrenda });

        builder.Property(x => x.Cantidad).HasColumnType("int");

        builder.Property(x => x.IdInsumo).HasColumnType("int");
        builder.HasOne(x => x.Insumos).WithMany(x => x.InsumoPrendas).HasForeignKey(x => x.IdInsumo);

        builder.Property(x => x.IdPrenda).HasColumnType("int");
        builder.HasOne(x => x.Prendas).WithMany(x => x.InsumoPrendas).HasForeignKey(x => x.IdPrenda);
    }
}