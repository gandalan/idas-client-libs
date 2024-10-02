namespace Gandalan.Client.Contracts.AppServices;

public enum PermissionLevel
{
    Kein = 0,
    Lesen = 1,
    LesenUndSchreiben = 2,
}

public enum Permission
{
    Adressverwaltung,
    Belege,
    BelegeStamm,
    ProduktionAV,
    ProduktionStamm,
    ProduktionSLK,
    Lager,
    Statistik,
    Zeit,
    ZeitStamm,
    Touren,
    TourenStamm,
    Verteter,
    Bestellfix,
    AdminTool,
    UserAdmin,
    AlleBelegeEinsehen,
    AppAdmin,
    SettingsSchreiben,
}

public interface IPermissions
{
    bool HasPermission(Permission permission, PermissionLevel minLevel);
}
