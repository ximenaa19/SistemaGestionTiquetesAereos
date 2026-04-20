using GestionAerolineas.src.Modules.Regions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Regions.Domain.Aggregate
{
    public sealed record Region
    {
        public RegionId Id { get; private set; }
        public RegionName Name { get; private set; }
        public RegionType Type { get; private set; }
        public RegionCountryId CountryId { get; private set; }

        private Region(RegionId id, RegionName name, RegionType type, RegionCountryId countryId)
        {
            Id = id;
            Name = name;
            Type = type;
            CountryId = countryId;
        }

        public static Region Create(
            RegionId id,
            RegionName name,
            RegionType type,
            RegionCountryId countryId
        )
        {
            return new Region(id, name, type, countryId);
        }

        public static Region CreateNew(RegionName name, RegionType type, RegionCountryId countryId)
        {
            return new Region(RegionId.CreateEmpty(), name, type, countryId);
        }
    }
}


