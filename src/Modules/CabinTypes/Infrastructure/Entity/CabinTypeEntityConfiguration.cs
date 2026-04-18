using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionAerolineas.src.Modules.CabinTypes.Infrastructure.Entity;

public class CabinTypeEntityConfiguration : IEntityTypeConfiguration<CabinTypeEntity>
{
    public void Configure(EntityTypeBuilder<CabinTypeEntity> builder)
    {
        builder.ToTable("CabinTypes");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.Name).IsRequired();
    }


}
