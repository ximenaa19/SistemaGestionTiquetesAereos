namespace GestionAerolineas.src.Modules.People.Domain.ValueObject
{
    public sealed record PersonBirthDate
    {
        public DateTime? Value { get; }

        private PersonBirthDate(DateTime? value)
        {
            Value = value;
        }

        public static PersonBirthDate Create(DateTime? value)
        {
            if (value.HasValue && value.Value.Date > DateTime.UtcNow.Date)
                throw new ArgumentException("La fecha de nacimiento no puede ser futura");

            return new PersonBirthDate(value?.Date);
        }
    }
}

