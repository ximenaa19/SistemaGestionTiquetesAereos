using GestionAerolineas.src.Modules.PhoneCodes.Domain.Aggregate;
using GestionAerolineas.src.Modules.PhoneCodes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PhoneCodes.Domain.Repositories;

public interface IPhoneCodeRepository
{
    Task<IEnumerable<PhoneCode>> GetAllAsync();
    Task<PhoneCode?> GetByIdAsync(PhoneCodeId id);
    Task<PhoneCode?> GetByCountryCodeAsync(PhoneCountryCode countryCode);
    Task<PhoneCode?> GetByCountryNameAsync(CountryName countryName);
    Task AddAsync(PhoneCode phoneCode);
    Task UpdateAsync(PhoneCode phoneCode);
    Task DeleteAsync(PhoneCode phoneCode);
    Task<bool> ExistsAsync(PhoneCodeId id);
}
