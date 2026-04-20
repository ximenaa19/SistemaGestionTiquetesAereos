using GestionAerolineas.src.Modules.Continents.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionAerolineas.src.Modules.Countries.Infrastructure.Entity;

public sealed class CountryEntityConfiguration : IEntityTypeConfiguration<CountryEntity>
{
    public void Configure(EntityTypeBuilder<CountryEntity> builder)
    {
        builder.ToTable("countries");

        builder.HasKey(x => x.Id);
        builder
            .Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(x => x.Name)
            .HasColumnName("nombre")
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder
            .Property(x => x.IsoCode)
            .HasColumnName("codigo_iso")
            .HasColumnType("varchar(3)")
            .IsRequired();

        builder
            .Property(x => x.ContinentId)
            .HasColumnName("continente_id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasIndex(x => x.IsoCode).IsUnique();

        builder
            .HasOne<ContinentEntity>()
            .WithMany()
            .HasForeignKey(x => x.ContinentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

