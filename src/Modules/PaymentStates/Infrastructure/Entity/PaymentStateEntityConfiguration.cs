using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionAerolineas.src.Modules.PaymentStates.Infrastructure.Entity;

public sealed class PaymentStateEntityConfiguration : IEntityTypeConfiguration<PaymentStateEntity>
{
    public void Configure(EntityTypeBuilder<PaymentStateEntity> builder)
    {
        builder.ToTable("estados_pago");

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
