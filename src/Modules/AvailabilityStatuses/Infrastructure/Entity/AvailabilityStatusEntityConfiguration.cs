using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionAerolineas.src.Modules.AvailabilityStatuses.Infrastructure.Entity;

public sealed class AvailabilityStatusEntityConfiguration : IEntityTypeConfiguration<AvailabilityStatusEntity>
{
    public void Configure(EntityTypeBuilder<AvailabilityStatusEntity> builder)
    {
        builder.ToTable("estados_disponibilidad");

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
