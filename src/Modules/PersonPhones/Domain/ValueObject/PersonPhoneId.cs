namespace GestionAerolineas.src.Modules.PersonPhones.Domain.ValueObject
{
    public sealed record PersonPhoneId
    {
        public int Value { get; }

        private PersonPhoneId(int value)
        {
            Value = value;
        }

        public static PersonPhoneId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El valor no puede ser menor a 1");

            return new PersonPhoneId(value);
        }

        public static PersonPhoneId CreateEmpty()
        {
            return new PersonPhoneId(0);
        }
    }
}

