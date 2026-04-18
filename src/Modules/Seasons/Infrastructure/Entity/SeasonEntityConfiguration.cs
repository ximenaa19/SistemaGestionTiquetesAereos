using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionAerolineas.src.Modules.Seasons.Infrastructure.Entity;

public sealed class SeasonEntityConfiguration : IEntityTypeConfiguration<SeasonEntity>
{
    public void Configure(EntityTypeBuilder<SeasonEntity> builder)
    {
        builder.ToTable("temporadas");

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
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder
            .Property(x => x.Description)
            .HasColumnName("descripcion")
            .HasColumnType("varchar(150)");

        builder
            .Property(x => x.PriceFactor)
            .HasColumnName("precio_factor")
            .HasColumnType("decimal(5,4)")
            .IsRequired();

        builder.HasIndex(x => x.Name).IsUnique();
    }
}
