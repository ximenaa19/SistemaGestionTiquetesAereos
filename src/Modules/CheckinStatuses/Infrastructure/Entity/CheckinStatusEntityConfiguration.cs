using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionAerolineas.src.Modules.CheckinStatuses.Infrastructure.Entity;

public sealed class CheckinStatusEntityConfiguration : IEntityTypeConfiguration<CheckinStatusEntity>
{
    public void Configure(EntityTypeBuilder<CheckinStatusEntity> builder)
    {
        builder.ToTable("estados_checkin");

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
