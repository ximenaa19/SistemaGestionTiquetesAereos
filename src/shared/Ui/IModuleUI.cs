namespace GestionAerolineas.src.shared.Ui;

public interface IModuleUI
{
    string Key { get; }
    string Title { get; }
    Task RunAsync(CancellationToken cancellationToken = default);
}

