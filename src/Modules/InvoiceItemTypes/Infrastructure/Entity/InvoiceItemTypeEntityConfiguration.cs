using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionAerolineas.src.Modules.InvoiceItemTypes.Infrastructure.Entity;

public sealed class InvoiceItemTypeEntityConfiguration : IEntityTypeConfiguration<InvoiceItemTypeEntity>
{
    public void Configure(EntityTypeBuilder<InvoiceItemTypeEntity> builder)
    {
        builder.ToTable("tipos_item_factura");

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
