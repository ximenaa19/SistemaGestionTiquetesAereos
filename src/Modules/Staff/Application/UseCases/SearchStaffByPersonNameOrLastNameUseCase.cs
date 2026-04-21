using GestionAerolineas.src.Modules.Staff.Domain.Aggregate;
using GestionAerolineas.src.Modules.Staff.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Staff.Application.UseCases;

public class SearchStaffByPersonNameOrLastNameUseCase
{
    private readonly IStaffRepository _repository;

    public SearchStaffByPersonNameOrLastNameUseCase(IStaffRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<StaffMember>> ExecuteAsync(string searchText)
    {
        return _repository.SearchByPersonNameOrLastNameAsync(searchText);
    }
}

