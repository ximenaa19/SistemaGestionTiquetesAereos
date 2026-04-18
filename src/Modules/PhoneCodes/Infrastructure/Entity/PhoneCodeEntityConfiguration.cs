using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionAerolineas.src.Modules.PhoneCodes.Infrastructure.Entity;

public sealed class PhoneCodeEntityConfiguration : IEntityTypeConfiguration<PhoneCodeEntity>
{
    public void Configure(EntityTypeBuilder<PhoneCodeEntity> builder)
    {
        builder.ToTable("phonecodes");

        builder.HasKey(x => x.Id);
        builder
            .Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(x => x.CountryCode)
            .HasColumnName("codigo_pais")
            .HasColumnType("varchar(5)")
            .IsRequired();

        builder
            .Property(x => x.CountryName)
            .HasColumnName("nombre_pais")
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.HasIndex(x => x.CountryCode).IsUnique();
    }
}

