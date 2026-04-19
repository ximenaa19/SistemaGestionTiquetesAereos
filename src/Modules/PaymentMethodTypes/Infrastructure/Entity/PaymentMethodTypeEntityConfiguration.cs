using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionAerolineas.src.Modules.PaymentMethodTypes.Infrastructure.Entity;

public sealed class PaymentMethodTypeEntityConfiguration : IEntityTypeConfiguration<PaymentMethodTypeEntity>
{
    public void Configure(EntityTypeBuilder<PaymentMethodTypeEntity> builder)
    {
        builder.ToTable("payment_method_types");

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
