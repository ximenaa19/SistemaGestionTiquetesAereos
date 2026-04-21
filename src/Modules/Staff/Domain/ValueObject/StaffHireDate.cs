namespace GestionAerolineas.src.Modules.Staff.Domain.ValueObject
{
    public sealed record StaffHireDate
    {
        public DateTime Value { get; }

        private StaffHireDate(DateTime value)
        {
            Value = value.Date;
        }

        public static StaffHireDate Create(DateTime value)
        {
            var date = value.Date;
            if (date > DateTime.Today)
                throw new ArgumentException("La fecha_ingreso no puede ser futura");

            return new StaffHireDate(date);
        }
    }
}

