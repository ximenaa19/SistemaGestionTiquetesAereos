using GestionAerolineas.src.shared.Context;
using Microsoft.EntityFrameworkCore;

namespace GestionAerolineas.src.shared.Seed;

public static class SeedRunner
{
    public static async Task SeedMasterAndCatalogsAsync(AppDbContext context)
    {
        await using var tx = await context.Database.BeginTransactionAsync();
        try
        {
            await CatalogSeed.SeedAsync(context);
            await MasterDataSeed.SeedAsync(context);

            await tx.CommitAsync();
        }
        catch
        {
            await tx.RollbackAsync();
            throw;
        }
    }
}

