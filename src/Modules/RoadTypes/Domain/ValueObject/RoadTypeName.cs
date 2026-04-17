namespace GestionAerolineas.src.Modules.RoadTypes.Domain.ValueObject;

public sealed record RoadTypeName
{
    public string Value { get; }

    private RoadTypeName(string value)
    {
        Value = value;
    }

    public static RoadTypeName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("El valor no puede estar vacío");
        }

        return new RoadTypeName(value);
    }
    public override string ToString() => Value;
}
