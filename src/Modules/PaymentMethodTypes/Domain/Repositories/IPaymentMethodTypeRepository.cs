using GestionAerolineas.src.Modules.PaymentMethodTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.PaymentMethodTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PaymentMethodTypes.Domain.Repositories;

public interface IPaymentMethodTypeRepository
{
    Task<IEnumerable<PaymentMethodType>> GetAllAsync();
    Task<PaymentMethodType?> GetByIdAsync(PaymentMethodTypeId id);
    Task<PaymentMethodType?> GetByNameAsync(PaymentMethodTypeName name);
    Task AddAsync(PaymentMethodType paymentMethodType);
    Task UpdateAsync(PaymentMethodType paymentMethodType);
    Task DeleteAsync(PaymentMethodType paymentMethodType);
    Task<bool> ExistsAsync(PaymentMethodTypeId id);
}
