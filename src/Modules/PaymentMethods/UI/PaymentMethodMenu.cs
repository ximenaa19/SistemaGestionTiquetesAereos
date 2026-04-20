using GestionAerolineas.src.Modules.CardIssuers.Application.UseCases;
using GestionAerolineas.src.Modules.CardTypes.Application.UseCases;
using GestionAerolineas.src.Modules.PaymentMethods.Application.UseCases;
using GestionAerolineas.src.Modules.PaymentMethodTypes.Application.UseCases;

namespace GestionAerolineas.src.Modules.PaymentMethods.UI;

public class PaymentMethodMenu
{
    private readonly CreatePaymentMethodUseCase _create;
    private readonly GetAllPaymentMethodsUseCase _getAll;
    private readonly GetPaymentMethodByIdUseCase _getById;
    private readonly GetPaymentMethodByCommercialNameUseCase _getByCommercialName;
    private readonly UpdatePaymentMethodUseCase _update;
    private readonly DeletePaymentMethodUseCase _delete;

    private readonly GetAllPaymentMethodTypesUseCase _getAllPaymentMethodTypes;
    private readonly GetAllCardTypesUseCase _getAllCardTypes;
    private readonly GetAllCardIssuersUseCase _getAllCardIssuers;

    public PaymentMethodMenu(
        CreatePaymentMethodUseCase create,
        GetAllPaymentMethodsUseCase getAll,
        GetPaymentMethodByIdUseCase getById,
        GetPaymentMethodByCommercialNameUseCase getByCommercialName,
        UpdatePaymentMethodUseCase update,
        DeletePaymentMethodUseCase delete,
        GetAllPaymentMethodTypesUseCase getAllPaymentMethodTypes,
        GetAllCardTypesUseCase getAllCardTypes,
        GetAllCardIssuersUseCase getAllCardIssuers)
    {
        _create = create;
        _getAll = getAll;
        _getById = getById;
        _getByCommercialName = getByCommercialName;
        _update = update;
        _delete = delete;
        _getAllPaymentMethodTypes = getAllPaymentMethodTypes;
        _getAllCardTypes = getAllCardTypes;
        _getAllCardIssuers = getAllCardIssuers;
    }

    public async Task StartAsync()
    {
        var menu = new ConsoleMenu(new[]
        {
            "Create a new payment method",
            "List all payment methods",
            "Get payment method by ID",
            "Get payment method by commercial name",
            "Update a payment method",
            "Delete a payment method",
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
                        await PrintDependenciesAsync();

                        Console.Write("\nIngrese tipo_medio_pago_id: ");
                        int paymentMethodTypeId = int.Parse(Console.ReadLine()!);

                        int? cardTypeId = ReadNullableInt("Ingrese tipo_tarjeta_id (opcional): ");
                        int? cardIssuerId = ReadNullableInt("Ingrese emisor_tarjeta_id (opcional): ");

                        Console.Write("Ingrese nombre_comercial: ");
                        string commercialName = Console.ReadLine()!;

                        await _create.ExecuteAsync(paymentMethodTypeId, cardTypeId, cardIssuerId, commercialName);
                        Console.WriteLine("✔ Creado");
                        break;

                    case 1:
                        var list = await _getAll.ExecuteAsync();
                        foreach (var item in list)
                            Console.WriteLine($"{item.Id.Value} - tipo_medio_pago_id={item.PaymentMethodTypeId.Value} - tipo_tarjeta_id={item.CardTypeId?.Value.ToString() ?? "null"} - emisor_tarjeta_id={item.CardIssuerId?.Value.ToString() ?? "null"} - nombre_comercial={item.CommercialName.Value}");
                        break;

                    case 2:
                        Console.Write("Ingrese el ID: ");
                        int searchId = int.Parse(Console.ReadLine()!);

                        var result = await _getById.ExecuteAsync(searchId);
                        Console.WriteLine(result == null
                            ? "No encontrado"
                            : $"{result.Id.Value} - tipo_medio_pago_id={result.PaymentMethodTypeId.Value} - tipo_tarjeta_id={result.CardTypeId?.Value.ToString() ?? "null"} - emisor_tarjeta_id={result.CardIssuerId?.Value.ToString() ?? "null"} - nombre_comercial={result.CommercialName.Value}");
                        break;

                    case 3:
                        Console.Write("Ingrese nombre_comercial: ");
                        string searchName = Console.ReadLine()!;

                        var resultByName = await _getByCommercialName.ExecuteAsync(searchName);
                        Console.WriteLine(resultByName == null
                            ? "No encontrado"
                            : $"{resultByName.Id.Value} - tipo_medio_pago_id={resultByName.PaymentMethodTypeId.Value} - tipo_tarjeta_id={resultByName.CardTypeId?.Value.ToString() ?? "null"} - emisor_tarjeta_id={resultByName.CardIssuerId?.Value.ToString() ?? "null"} - nombre_comercial={resultByName.CommercialName.Value}");
                        break;

                    case 4:
                        await PrintDependenciesAsync();

                        Console.Write("\nIngrese el ID: ");
                        int updateId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese nuevo tipo_medio_pago_id: ");
                        int newPaymentMethodTypeId = int.Parse(Console.ReadLine()!);

                        int? newCardTypeId = ReadNullableInt("Ingrese nuevo tipo_tarjeta_id (opcional): ");
                        int? newCardIssuerId = ReadNullableInt("Ingrese nuevo emisor_tarjeta_id (opcional): ");

                        Console.Write("Ingrese nuevo nombre_comercial: ");
                        string newCommercialName = Console.ReadLine()!;

                        await _update.ExecuteAsync(updateId, newPaymentMethodTypeId, newCardTypeId, newCardIssuerId, newCommercialName);
                        Console.WriteLine("✔ Actualizado");
                        break;

                    case 5:
                        Console.Write("Ingrese el ID: ");
                        int deleteId = int.Parse(Console.ReadLine()!);

                        await _delete.ExecuteAsync(deleteId);
                        Console.WriteLine("✔ Eliminado");
                        break;

                    case 6:
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.GetBaseException().Message}");
            }

            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    private async Task PrintDependenciesAsync()
    {
        Console.WriteLine("PaymentMethodTypes disponibles:");
        var methodTypes = await _getAllPaymentMethodTypes.ExecuteAsync();
        foreach (var item in methodTypes)
            Console.WriteLine($"{item.Id.Value} - {item.Name.Value}");

        Console.WriteLine("\nCardTypes disponibles:");
        var cardTypes = await _getAllCardTypes.ExecuteAsync();
        foreach (var item in cardTypes)
            Console.WriteLine($"{item.Id.Value} - {item.Name.Value}");

        Console.WriteLine("\nCardIssuers disponibles:");
        var issuers = await _getAllCardIssuers.ExecuteAsync();
        foreach (var item in issuers)
            Console.WriteLine($"{item.Id.Value} - {item.Name.Value}");
    }

    private static int? ReadNullableInt(string prompt)
    {
        Console.Write(prompt);
        var input = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(input))
            return null;

        if (!int.TryParse(input, out var value))
            throw new Exception("Valor inválido");

        return value;
    }
}

