namespace GestionAerolineas.src.Modules.Invoices.Domain.ValueObject;

public record InvoiceReservationId(int Value)
{
    public static InvoiceReservationId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("reserva_id no es valido");
        return new InvoiceReservationId(value);
    }
}

