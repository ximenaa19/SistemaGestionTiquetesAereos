using System;
using GestionAerolineas.src.Modules.Continents.Application.Services;
using GestionAerolineas.src.Modules.Continents.Infrastructure.Repository;
using GestionAerolineas.src.Modules.Continents.UI;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.Continents;

public class ContinentModule
{
        public static ContinentConsoleUI Build(AppDbContext context)
    {
        var repository = new ContinentRepository(context);
        var unitOfWork = new UnitOfWork(context);
        var service = new ContinentService(repository, unitOfWork);
        return new ContinentConsoleUI(service);
    }


}
