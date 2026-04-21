using GestionAerolineas.src.Modules.Staff.Domain.Repositories;
using GestionAerolineas.src.Modules.Staff.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Staff.Application.UseCases;

public class DeleteStaffUseCase
{
    private readonly IStaffRepository _repository;

    public DeleteStaffUseCase(IStaffRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(StaffId.Create(id));
        if (entity is null)
            return;

        await _repository.DeleteAsync(entity);
    }
}

