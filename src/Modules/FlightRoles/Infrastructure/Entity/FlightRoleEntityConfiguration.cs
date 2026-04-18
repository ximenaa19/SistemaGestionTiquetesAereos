using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionAerolineas.src.Modules.FlightRoles.Infrastructure.Entity;

public sealed class FlightRoleEntityConfiguration : IEntityTypeConfiguration<FlightRoleEntity>
{
    public void Configure(EntityTypeBuilder<FlightRoleEntity> builder)
    {
        builder.ToTable("fligthroles");

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

        builder.HasIndex(x => x.Name).IsUnique();
    }
}

