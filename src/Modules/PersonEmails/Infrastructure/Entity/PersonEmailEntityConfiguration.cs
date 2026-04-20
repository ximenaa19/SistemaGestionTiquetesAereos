using GestionAerolineas.src.Modules.EmailDomains.Infrastructure.Entity;
using GestionAerolineas.src.Modules.People.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionAerolineas.src.Modules.PersonEmails.Infrastructure.Entity;

public sealed class PersonEmailEntityConfiguration : IEntityTypeConfiguration<PersonEmailEntity>
{
    public void Configure(EntityTypeBuilder<PersonEmailEntity> builder)
    {
        builder.ToTable("personemails");

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
            .Property(x => x.User)
            .HasColumnName("usuario_email")
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder
            .Property(x => x.EmailDomainId)
            .HasColumnName("dominio_email_id")
            .HasColumnType("int")
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
            .HasOne<EmailDomainEntity>()
            .WithMany()
            .HasForeignKey(x => x.EmailDomainId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

