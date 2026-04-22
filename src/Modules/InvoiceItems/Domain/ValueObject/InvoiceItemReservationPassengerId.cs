namespace GestionAerolineas.src.Modules.InvoiceItems.Domain.ValueObject;

public sealed record InvoiceItemReservationPassengerId
{
    public int? Value { get; }

    private InvoiceItemReservationPassengerId(int? value)
    {
        Value = value;
    }

    public static InvoiceItemReservationPassengerId Create(int? value)
    {
        if (value.HasValue && value.Value <= 0)
            throw new ArgumentException("reserva_pasajero_id no es valido");
        return new InvoiceItemReservationPassengerId(value);
    }
}

