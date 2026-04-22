namespace GestionAerolineas.src.Modules.Invoices.UI;

public class ConsoleMenu
{
    private readonly string[] _options;

    public ConsoleMenu(string[] options)
    {
        _options = options;
    }

    public int Show()
    {
        int selected = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== MENU ===\n");

            for (int i = 0; i < _options.Length; i++)
            {
                if (i == selected)
                    Console.WriteLine($"> {_options[i]}");
                else
                    Console.WriteLine($"  {_options[i]}");
            }

            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
                selected = (selected - 1 + _options.Length) % _options.Length;
            else if (key == ConsoleKey.DownArrow)
                selected = (selected + 1) % _options.Length;
            else if (key == ConsoleKey.Enter)
                return selected;
        }
    }
}

