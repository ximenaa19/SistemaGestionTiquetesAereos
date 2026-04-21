namespace GestionAerolineas.src.Modules.Staff.Domain.ValueObject
{
    public sealed record StaffIsActive
    {
        public bool Value { get; }

        private StaffIsActive(bool value)
        {
            Value = value;
        }

        public static StaffIsActive Create(bool value)
        {
            return new StaffIsActive(value);
        }
    }
}

