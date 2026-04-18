using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionAerolineas.src.Modules.SeatLocationTypes.Infrastructure.Entity;

public sealed class SeatLocationTypeEntityConfiguration : IEntityTypeConfiguration<SeatLocationTypeEntity>
{
    public void Configure(EntityTypeBuilder<SeatLocationTypeEntity> builder)
    {
        builder.ToTable("tipos_ubicacion_asiento");

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

        builder.HasIndex(x => x.Name).IsUnique();
    }
}

