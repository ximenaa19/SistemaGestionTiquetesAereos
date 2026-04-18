using GestionAerolineas.src.Modules.PhoneCodes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PhoneCodes.Application.Interfaces;

public interface IPhoneCodeValidator
{
    Task ValidateCountryCodeAsync(PhoneCountryCode countryCode, PhoneCodeId? currentId = null);
}

