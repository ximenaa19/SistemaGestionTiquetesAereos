using GestionAerolineas.src.Modules.DocumentTypes.Application.UseCases;

namespace GestionAerolineas.src.Modules.DocumentTypes.UI;

public class DocumentTypeMenu
{
    private readonly CreateDocumentTypeUseCase _create;
    private readonly GetAllDocumentTypesUseCase _getAll;
    private readonly GetDocumentTypeByIdUseCase _getById;
    private readonly GetDocumentTypeByCodeUseCase _getByCode;
    private readonly UpdateDocumentTypeUseCase _update;
    private readonly DeleteDocumentTypeUseCase _delete;

    public DocumentTypeMenu(
        CreateDocumentTypeUseCase create,
        GetAllDocumentTypesUseCase getAll,
        GetDocumentTypeByIdUseCase getById,
        GetDocumentTypeByCodeUseCase getByCode,
        UpdateDocumentTypeUseCase update,
        DeleteDocumentTypeUseCase delete)
    {
        _create = create;
        _getAll = getAll;
        _getById = getById;
        _getByCode = getByCode;
        _update = update;
        _delete = delete;
    }

    public async Task StartAsync()
    {
        var menu = new ConsoleMenu(new[]
        {
            "Create a new document type",
            "List all document types",
            "Get document type by ID",
            "Get document type by code",
            "Update a document type",
            "Delete a document type",
            "Exit"
        });

        while (true)
        {
            int option = menu.Show();

            try
            {
                switch (option)
                {
                    case 0:
                        Console.Write("Ingrese el nombre: ");
                        string name = Console.ReadLine()!;

                        Console.Write("Ingrese el codigo: ");
                        string code = Console.ReadLine()!;

                        await _create.ExecuteAsync(name, code);
                        Console.WriteLine("Creado");
                        break;

                    case 1:
                        var list = await _getAll.ExecuteAsync();

                        foreach (var item in list)
                        {
                            Console.WriteLine($"{item.Id.Value} - {item.Name.Value} - {item.Code.Value}");
                        }
                        break;

                    case 2:
                        Console.Write("Ingrese el ID: ");
                        int searchId = int.Parse(Console.ReadLine()!);

                        var result = await _getById.ExecuteAsync(searchId);

                        Console.WriteLine(result is null
                            ? "No encontrado"
                            : $"{result.Id.Value} - {result.Name.Value} - {result.Code.Value}");
                        break;

                    case 3:
                        Console.Write("Ingrese el codigo: ");
                        string searchCode = Console.ReadLine()!;

                        var resultByCode = await _getByCode.ExecuteAsync(searchCode);

                        Console.WriteLine(resultByCode is null
                            ? "No encontrado"
                            : $"{resultByCode.Id.Value} - {resultByCode.Name.Value} - {resultByCode.Code.Value}");
                        break;

                    case 4:
                        Console.Write("Ingrese el ID: ");
                        int updateId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese el nuevo nombre: ");
                        string newName = Console.ReadLine()!;

                        Console.Write("Ingrese el nuevo codigo: ");
                        string newCode = Console.ReadLine()!;

                        await _update.ExecuteAsync(updateId, newName, newCode);
                        Console.WriteLine("Actualizado");
                        break;

                    case 5:
                        Console.Write("Ingrese el ID: ");
                        int deleteId = int.Parse(Console.ReadLine()!);

                        await _delete.ExecuteAsync(deleteId);
                        Console.WriteLine("Eliminado");
                        break;

                    case 6:
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
