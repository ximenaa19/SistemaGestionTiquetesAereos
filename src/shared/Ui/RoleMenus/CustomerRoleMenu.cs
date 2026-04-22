namespace GestionAerolineas.src.shared.Ui.RoleMenus;

public sealed class CustomerRoleMenu
{
    private readonly RoleMenu _menu;

    public CustomerRoleMenu(IReadOnlyList<RoleMenuOption> options)
    {
        _menu = new RoleMenu("MENU CLIENTE", options);
    }

    public Task StartAsync() => _menu.StartAsync();
}

