using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("departamento");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);

        builder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);

        builder.Property(x => x.IdPais).HasColumnType("int");
        builder.HasOne(x => x.Paises).WithMany(x => x.Departamentos).HasForeignKey(x => x.IdPais);
    }
}