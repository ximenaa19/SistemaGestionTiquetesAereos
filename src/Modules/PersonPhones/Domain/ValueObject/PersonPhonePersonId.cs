namespace GestionAerolineas.src.Modules.PersonPhones.Domain.ValueObject
{
    public sealed record PersonPhonePersonId
    {
        public int Value { get; }

        private PersonPhonePersonId(int value)
        {
            Value = value;
        }

        public static PersonPhonePersonId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El valor no puede ser menor a 1");

            return new PersonPhonePersonId(value);
        }
    }
}

