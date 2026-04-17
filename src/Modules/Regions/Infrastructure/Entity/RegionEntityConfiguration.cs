using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GestionAerolineas.src.Modules.Countries.Infrastructure.Entity;

namespace GestionAerolineas.src.Modules.Regions.Infrastructure.Entity;

public class RegionEntityConfiguration : IEntityTypeConfiguration<RegionEntity>
{
    public void Configure(EntityTypeBuilder<RegionEntity> builder)
    {
        builder.ToTable("regions");

        builder.HasKey(x => x.Id);
        builder
            .Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder
            .Property(x => x.Type)
            .HasColumnName("type")
            .HasColumnType("varchar(30)")
            .IsRequired();

        builder
            .Property(x => x.CountryId)
            .HasColumnName("Country_id")
            .HasColumnType("int")
            .IsRequired();
        builder
            .HasOne<CountryEntity>()
            .WithMany()
            .HasForeignKey(x => x.CountryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}


