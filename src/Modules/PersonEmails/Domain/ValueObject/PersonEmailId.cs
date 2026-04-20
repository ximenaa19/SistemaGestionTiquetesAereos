namespace GestionAerolineas.src.Modules.PersonEmails.Domain.ValueObject
{
    public sealed record PersonEmailId
    {
        public int Value { get; }

        private PersonEmailId(int value)
        {
            Value = value;
        }

        public static PersonEmailId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El valor no puede ser menor a 1");

            return new PersonEmailId(value);
        }

        public static PersonEmailId CreateEmpty()
        {
            return new PersonEmailId(0);
        }
    }
}

