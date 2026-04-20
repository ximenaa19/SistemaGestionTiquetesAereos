namespace GestionAerolineas.src.Modules.PersonPhones.Domain.ValueObject
{
    public sealed record PersonPhoneIsPrimary
    {
        public bool Value { get; }

        private PersonPhoneIsPrimary(bool value)
        {
            Value = value;
        }

        public static PersonPhoneIsPrimary Create(bool value)
        {
            return new PersonPhoneIsPrimary(value);
        }
    }
}

