using GestionAerolineas.src.Modules.Auth.Application.UseCases;
using GestionAerolineas.src.Modules.SystemRoles.Application.UseCases;
using GestionAerolineas.src.Modules.SystemRoles.Domain.Aggregate;

namespace GestionAerolineas.src.Modules.Auth.UI;

public class AuthMenu
{
    private readonly RegisterAuthUserUseCase _register;
    private readonly LoginUserUseCase _login;
    private readonly GetAllSystemRolesUseCase _getAllRolesUseCase;

    public AuthMenu(
        RegisterAuthUserUseCase register,
        LoginUserUseCase login,
        GetAllSystemRolesUseCase getAllRolesUseCase)
    {
        _register = register;
        _login = login;
        _getAllRolesUseCase = getAllRolesUseCase;
    }

    public async Task<bool> StartAsync()
    {
        var menu = new ConsoleMenu(new[]
        {
            "Register user",
            "Login",
            "Exit"
        });

        while (true)
        {
            var option = menu.Show();

            try
            {
                switch (option)
                {
                    case 0:
                        await HandleRegisterAsync();
                        break;

                    case 1:
                        Console.Write("Ingrese nombre (username): ");
                        var loginUsername = Console.ReadLine() ?? string.Empty;
                        var loginPassword = ReadHiddenRequired("Ingrese contrasenia: ");

                        var result = await _login.ExecuteAsync(loginUsername, loginPassword);
                        Console.WriteLine($"✔ Login exitoso - userId={result.UserId} - roleId={result.RoleId}");
                        return true;

                    case 2:
                        return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.GetBaseException().Message}");
            }

            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
        }
    }

    private async Task HandleRegisterAsync()
    {
        while (true)
        {
            Console.Write("Ingrese nombre (username): ");
            var username = (Console.ReadLine() ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("El nombre es obligatorio");

            var password = ReadValidPasswordWithConfirmation();
            var selectedRole = await SelectRoleAsync();

            Console.WriteLine("\n=== Confirmar registro ===");
            Console.WriteLine($"Nombre: {username}");
            Console.WriteLine($"Rol: {selectedRole.Name.Value}");
            var decision = ReadConfirmChoice();

            if (decision == 1)
            {
                await _register.ExecuteAsync(username, password, selectedRole.Id.Value);
                Console.WriteLine("✔ Registro completado");
                return;
            }

            if (decision == 2)
                continue;

            Console.WriteLine("Registro cancelado.");
            return;
        }
    }

    private async Task<SystemRole> SelectRoleAsync()
    {
        var roles = (await _getAllRolesUseCase.ExecuteAsync()).ToList();
        if (roles.Count == 0)
            throw new Exception("No hay roles del sistema configurados.");

        Console.WriteLine("\nRoles disponibles:");
        foreach (var role in roles.OrderBy(r => r.Id.Value))
            Console.WriteLine($"{role.Id.Value} - {role.Name.Value}");

        while (true)
        {
            Console.Write("Ingrese rol_id: ");
            var raw = Console.ReadLine();
            if (!int.TryParse(raw, out var roleId))
            {
                Console.WriteLine("❌ Debes ingresar un numero valido.");
                continue;
            }

            var selected = roles.FirstOrDefault(r => r.Id.Value == roleId);
            if (selected is null)
            {
                Console.WriteLine("❌ El rol no existe en la lista. Intenta de nuevo.");
                continue;
            }

            return selected;
        }
    }

    private static string ReadValidPasswordWithConfirmation()
    {
        while (true)
        {
            var password = ReadHiddenRequired("Ingrese contrasenia (minimo 8 caracteres): ");
            if (password.Length < 8)
            {
                Console.WriteLine("❌ La contrasenia debe tener minimo 8 caracteres.");
                continue;
            }

            var confirm = ReadHiddenRequired("Confirmar contrasenia: ");
            if (password != confirm)
            {
                Console.WriteLine("❌ Las contrasenias no coinciden.");
                continue;
            }

            return password;
        }
    }

    private static int ReadConfirmChoice()
    {
        while (true)
        {
            Console.WriteLine("1. Confirmar");
            Console.WriteLine("2. Editar");
            Console.WriteLine("3. Cancelar");
            Console.Write("Seleccione opcion (1-3): ");
            var raw = Console.ReadLine();
            if (raw is "1" or "2" or "3")
                return int.Parse(raw);

            Console.WriteLine("❌ Opcion invalida. Debes ingresar 1, 2 o 3.");
        }
    }

    private static string ReadHiddenRequired(string prompt)
    {
        var value = ReadHiddenLine(prompt);
        if (string.IsNullOrWhiteSpace(value))
            throw new Exception("El valor es obligatorio");
        return value;
    }

    private static string ReadHiddenLine(string prompt)
    {
        Console.Write(prompt);

        var buffer = new List<char>();
        while (true)
        {
            var key = Console.ReadKey(intercept: true);

            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                break;
            }

            if (key.Key == ConsoleKey.Backspace)
            {
                if (buffer.Count == 0)
                    continue;
                buffer.RemoveAt(buffer.Count - 1);
                Console.Write("\b \b");
                continue;
            }

            if (!char.IsControl(key.KeyChar))
            {
                buffer.Add(key.KeyChar);
                Console.Write("*");
            }
        }

        return new string(buffer.ToArray());
    }
}
