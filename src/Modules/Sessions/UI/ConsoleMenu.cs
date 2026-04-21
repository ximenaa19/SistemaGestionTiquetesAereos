namespace GestionAerolineas.src.Modules.Sessions.UI;

public class ConsoleMenu
{
    private readonly string[] _options;

    public ConsoleMenu(string[] options)
    {
        _options = options;
    }

    public int Show()
    {
        Console.Clear();
        Console.WriteLine("=== Session Menu ===");

        for (var i = 0; i < _options.Length; i++)
            Console.WriteLine($"{i}. {_options[i]}");

        Console.Write("\nSeleccione una opcion: ");

        if (!int.TryParse(Console.ReadLine(), out var option))
            return -1;

        return option;
    }
}
