using GestionAerolineas.src.Modules.PaymentMethods.Domain.Aggregate;
using GestionAerolineas.src.Modules.PaymentMethods.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PaymentMethods.Domain.Repositories;

public interface IPaymentMethodRepository
{
    Task<IEnumerable<PaymentMethod>> GetAllAsync();
    Task<PaymentMethod?> GetByIdAsync(PaymentMethodId id);
    Task<PaymentMethod?> GetByCommercialNameAsync(PaymentMethodCommercialName commercialName);
    Task AddAsync(PaymentMethod paymentMethod);
    Task UpdateAsync(PaymentMethod paymentMethod);
    Task DeleteAsync(PaymentMethod paymentMethod);
    Task<bool> ExistsAsync(PaymentMethodId id);
}

