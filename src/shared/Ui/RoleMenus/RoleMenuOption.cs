namespace GestionAerolineas.src.shared.Ui.RoleMenus;

public sealed record RoleMenuOption(
    string Label,
    Func<Task> Action
);

