namespace GestionAerolineas.src.Modules.PersonEmails.Domain.ValueObject
{
    public sealed record PersonEmailIsPrimary
    {
        public bool Value { get; }

        private PersonEmailIsPrimary(bool value)
        {
            Value = value;
        }

        public static PersonEmailIsPrimary Create(bool value)
        {
            return new PersonEmailIsPrimary(value);
        }
    }
}

