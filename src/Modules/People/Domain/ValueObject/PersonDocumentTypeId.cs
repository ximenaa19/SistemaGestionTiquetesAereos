namespace GestionAerolineas.src.Modules.People.Domain.ValueObject
{
    public sealed record PersonDocumentTypeId
    {
        public int Value { get; }

        private PersonDocumentTypeId(int value)
        {
            Value = value;
        }

        public static PersonDocumentTypeId Create(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("El valor no puede ser menor a 1");
            }

            return new PersonDocumentTypeId(value);
        }
    }
}

