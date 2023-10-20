using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class MunicipioConfiguration : IEntityTypeConfiguration<Municipio>
{
    public void Configure(EntityTypeBuilder<Municipio> builder)
    {
        builder.ToTable("municipio");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);

        builder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);

        builder.Property(x => x.IdDep).HasColumnType("int");
        builder.HasOne(x => x.Departamentos).WithMany(x => x.Municipios).HasForeignKey(x => x.IdDep);
    }
}