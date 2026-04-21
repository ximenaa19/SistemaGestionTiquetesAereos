using GestionAerolineas.src.Modules.Sessions.Application.Interfaces;
using GestionAerolineas.src.Modules.Sessions.Domain.Aggregate;
using GestionAerolineas.src.Modules.Sessions.Domain.Repositories;
using GestionAerolineas.src.Modules.Sessions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Sessions.Application.UseCases;

public class ForceEndSessionUseCase
{
    private readonly ISessionRepository _repository;
    private readonly ISessionValidator _validator;

    public ForceEndSessionUseCase(ISessionRepository repository, ISessionValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<int> ExecuteAsync(int actingUserId, int targetUserId)
    {
        await _validator.ValidateCanForceEndAsync(actingUserId, targetUserId);

        var sessions = (await _repository.GetActiveByUserIdAsync(SessionUserId.Create(targetUserId))).ToList();
        foreach (var session in sessions)
        {
            await _validator.ValidateSessionBelongsToOtherUserAsync(session, actingUserId);

            var updated = Session.Create(
                session.Id,
                session.UserId,
                session.StartedAt,
                SessionEndedAt.Create(DateTime.Now),
                session.IpAddress,
                SessionIsActive.Create(false));

            await _repository.UpdateAsync(updated);
        }

        return sessions.Count;
    }
}
