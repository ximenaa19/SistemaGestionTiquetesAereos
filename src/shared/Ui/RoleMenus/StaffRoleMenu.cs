namespace GestionAerolineas.src.shared.Ui.RoleMenus;

public sealed class StaffRoleMenu
{
    private readonly RoleMenu _menu;

    public StaffRoleMenu(IReadOnlyList<RoleMenuOption> options)
    {
        _menu = new RoleMenu("MENU STAFF", options);
    }

    public Task StartAsync() => _menu.StartAsync();
}

