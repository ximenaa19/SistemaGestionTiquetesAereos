namespace GestionAerolineas.src.Modules.PersonEmails.Domain.ValueObject
{
    public sealed record PersonEmailPersonId
    {
        public int Value { get; }

        private PersonEmailPersonId(int value)
        {
            Value = value;
        }

        public static PersonEmailPersonId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El valor no puede ser menor a 1");

            return new PersonEmailPersonId(value);
        }
    }
}

