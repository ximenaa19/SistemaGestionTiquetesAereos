using GestionAerolineas.src.Shared.Contracts;
using GestionAerolineas.src.Shared.Context;

namespace GestionAerolineas.src.shared.Context;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}

