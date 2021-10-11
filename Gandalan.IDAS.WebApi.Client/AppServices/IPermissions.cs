using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.AppServices
{
    public enum PermissionLevel
    {
        Kein = 0, Lesen = 1, LesenUndSchreiben = 2
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
        AppAdmin
    }

    public interface IPermissions
    {
        bool HasPermission(Permission permission, PermissionLevel minlevel);
    }
}
