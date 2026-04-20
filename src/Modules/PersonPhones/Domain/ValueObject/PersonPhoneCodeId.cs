namespace GestionAerolineas.src.Modules.PersonPhones.Domain.ValueObject
{
    public sealed record PersonPhoneCodeId
    {
        public int Value { get; }

        private PersonPhoneCodeId(int value)
        {
            Value = value;
        }

        public static PersonPhoneCodeId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El valor no puede ser menor a 1");

            return new PersonPhoneCodeId(value);
        }
    }
}

