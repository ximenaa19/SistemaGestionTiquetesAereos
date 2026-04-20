namespace GestionAerolineas.src.Modules.People.Domain.ValueObject
{
    public sealed record PersonAddressId
    {
        public int? Value { get; }

        private PersonAddressId(int? value)
        {
            Value = value;
        }

        public static PersonAddressId Create(int? value)
        {
            if (!value.HasValue)
                return new PersonAddressId((int?)null);

            if (value.Value <= 0)
                throw new ArgumentException("El valor no puede ser menor a 1");

            return new PersonAddressId(value.Value);
        }
    }
}
