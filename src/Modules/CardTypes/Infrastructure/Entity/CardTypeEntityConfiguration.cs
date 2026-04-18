using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionAerolineas.src.Modules.CardTypes.Infrastructure.Entity;

public sealed class CardTypeEntityConfiguration : IEntityTypeConfiguration<CardTypeEntity>
{
    public void Configure(EntityTypeBuilder<CardTypeEntity> builder)
    {
        builder.ToTable("tipos_tarjeta");

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
