using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionAerolineas.src.Modules.StaffRoles.Infrastructure.Entity;

public sealed class StaffRoleEntityConfiguration : IEntityTypeConfiguration<StaffRoleEntity>
{
    public void Configure(EntityTypeBuilder<StaffRoleEntity> builder)
    {
        builder.ToTable("cargos_personal");

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
