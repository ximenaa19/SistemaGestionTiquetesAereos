using GestionAerolineas.src.Modules.PaymentStates.Domain.Aggregate;
using GestionAerolineas.src.Modules.PaymentStates.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PaymentStates.Domain.Repositories;

public interface IPaymentStateRepository
{
    Task<IEnumerable<PaymentState>> GetAllAsync();
    Task<PaymentState?> GetByIdAsync(PaymentStateId id);
    Task<PaymentState?> GetByNameAsync(PaymentStateName name);
    Task AddAsync(PaymentState paymentState);
    Task UpdateAsync(PaymentState paymentState);
    Task DeleteAsync(PaymentState paymentState);
    Task<bool> ExistsAsync(PaymentStateId id);
}
