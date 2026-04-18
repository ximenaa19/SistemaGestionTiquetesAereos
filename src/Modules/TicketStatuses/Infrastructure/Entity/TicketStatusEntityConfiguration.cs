using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionAerolineas.src.Modules.TicketStatuses.Infrastructure.Entity;

public sealed class TicketStatusEntityConfiguration : IEntityTypeConfiguration<TicketStatusEntity>
{
    public void Configure(EntityTypeBuilder<TicketStatusEntity> builder)
    {
        builder.ToTable("estados_tiquete");

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
