namespace GestionAerolineas.src.Modules.People.Domain.ValueObject
{
    public sealed record PersonId
    {
        public int Value { get; }

        private PersonId(int value)
        {
            Value = value;
        }

        public static PersonId Create(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("El valor no puede ser menor a 1");
            }

            return new PersonId(value);
        }

        public static PersonId CreateEmpty()
        {
            return new PersonId(0);
        }
    }
}

