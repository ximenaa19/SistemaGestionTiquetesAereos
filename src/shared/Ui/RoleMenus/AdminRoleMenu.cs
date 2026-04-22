namespace GestionAerolineas.src.shared.Ui.RoleMenus;

public sealed class AdminRoleMenu
{
    private readonly RoleMenu _menu;

    public AdminRoleMenu(IReadOnlyList<RoleMenuOption> options)
    {
        _menu = new RoleMenu("MENU ADMIN", options);
    }

    public Task StartAsync() => _menu.StartAsync();
}

