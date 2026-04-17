using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionAerolineas.src.Modules.RoadTypes.Infrastructure.Entity;

public sealed class RoadTypeEntityConfiguration : IEntityTypeConfiguration<RoadTypeEntity>
{
    public void Configure(EntityTypeBuilder<RoadTypeEntity> builder)
    {
        builder.ToTable("RoadTypes");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.Name).IsRequired();
    }
    
}




