using GestionAerolineas.src.Modules.SeatLocationTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.SeatLocationTypes.Application.Interfaces;

public interface ISeatLocationTypeValidator
{
    Task ValidateNameAsync(SeatLocationTypeName name, SeatLocationTypeId? currentId = null);
}

