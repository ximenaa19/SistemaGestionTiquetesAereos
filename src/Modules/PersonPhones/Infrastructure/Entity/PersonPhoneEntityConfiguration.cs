using GestionAerolineas.src.Modules.People.Infrastructure.Entity;
using GestionAerolineas.src.Modules.PhoneCodes.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionAerolineas.src.Modules.PersonPhones.Infrastructure.Entity;

public sealed class PersonPhoneEntityConfiguration : IEntityTypeConfiguration<PersonPhoneEntity>
{
    public void Configure(EntityTypeBuilder<PersonPhoneEntity> builder)
    {
        builder.ToTable("personphones");

        builder.HasKey(x => x.Id);
        builder
            .Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(x => x.PersonId)
            .HasColumnName("persona_id")
            .HasColumnType("int")
            .IsRequired();

        builder
            .Property(x => x.PhoneCodeId)
            .HasColumnName("codigo_telefono_id")
            .HasColumnType("int")
            .IsRequired();

        builder
            .Property(x => x.PhoneNumber)
            .HasColumnName("numero_telefono")
            .HasColumnType("varchar(20)")
            .IsRequired();

        builder
            .Property(x => x.IsPrimary)
            .HasColumnName("es_principal")
            .HasColumnType("tinyint(1)")
            .IsRequired();

        builder
            .HasOne<PersonEntity>()
            .WithMany()
            .HasForeignKey(x => x.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne<PhoneCodeEntity>()
            .WithMany()
            .HasForeignKey(x => x.PhoneCodeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

