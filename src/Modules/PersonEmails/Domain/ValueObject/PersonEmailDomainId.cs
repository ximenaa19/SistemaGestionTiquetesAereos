namespace GestionAerolineas.src.Modules.PersonEmails.Domain.ValueObject
{
    public sealed record PersonEmailDomainId
    {
        public int Value { get; }

        private PersonEmailDomainId(int value)
        {
            Value = value;
        }

        public static PersonEmailDomainId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El valor no puede ser menor a 1");

            return new PersonEmailDomainId(value);
        }
    }
}

