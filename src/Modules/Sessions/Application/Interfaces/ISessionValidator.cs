using GestionAerolineas.src.Modules.Sessions.Domain.Aggregate;
using GestionAerolineas.src.Modules.Sessions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Sessions.Application.Interfaces;

public interface ISessionValidator
{
    Task ValidateUserExistsAsync(SessionUserId userId);
    Task ValidateLifecycleAsync(SessionStartedAt startedAt, SessionEndedAt endedAt, SessionIsActive isActive);
    Task ValidateCanForceEndAsync(int actingUserId, int targetUserId);
    Task ValidateSessionExistsAsync(SessionId id);
    Task ValidateSessionBelongsToOtherUserAsync(Session session, int actingUserId);
}
