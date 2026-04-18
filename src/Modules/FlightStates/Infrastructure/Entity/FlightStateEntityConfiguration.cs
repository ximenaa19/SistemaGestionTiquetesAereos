using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionAerolineas.src.Modules.FlightStates.Infrastructure.Entity;

public sealed class FlightStateEntityConfiguration : IEntityTypeConfiguration<FlightStateEntity>
{
    public void Configure(EntityTypeBuilder<FlightStateEntity> builder)
    {
        builder.ToTable("estados_vuelo");

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
