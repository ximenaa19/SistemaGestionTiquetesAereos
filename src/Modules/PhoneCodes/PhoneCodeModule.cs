using GestionAerolineas.src.Modules.PhoneCodes.Application.Interfaces;
using GestionAerolineas.src.Modules.PhoneCodes.Application.Services;
using GestionAerolineas.src.Modules.PhoneCodes.Application.UseCases;
using GestionAerolineas.src.Modules.PhoneCodes.Infrastructure.Repository;
using GestionAerolineas.src.Modules.PhoneCodes.UI;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.PhoneCodes;

public static class PhoneCodeModule
{
    public static PhoneCodeMenu Build(AppDbContext context)
    {
        var repository = new PhoneCodeRepository(context);
        IPhoneCodeValidator validator = new PhoneCodeValidator(repository);

        var create = new CreatePhoneCodeUseCase(repository, validator);
        var getAll = new GetAllPhoneCodesUseCase(repository);
        var getById = new GetPhoneCodeByIdUseCase(repository);
        var getByCountryName = new GetPhoneCodeByCountryNameUseCase(repository);
        var update = new UpdatePhoneCodeUseCase(repository, validator);
        var delete = new DeletePhoneCodeUseCase(repository);

        return new PhoneCodeMenu(
            create,
            getAll,
            getById,
            getByCountryName,
            update,
            delete
        );
    }
}
