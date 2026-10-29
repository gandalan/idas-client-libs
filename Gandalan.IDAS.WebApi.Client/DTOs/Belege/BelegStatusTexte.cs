namespace Gandalan.IDAS.WebApi.Client.DTOs.Belege;

public static class BelegStatusTexte
{
    /// <summary>
    /// Statustext der AB nach der Produktionsfreigabe. Der Client erkennt daran eine freigegebene AB, der Server setzt ihn
    /// zurück, wenn die AB nach dem Löschen eines Belegs keinen Nachfolger mehr hat. Beide Seiten müssen deshalb denselben
    /// Text verwenden.
    /// </summary>
    public const string ZurProduktionKopiert = "Beleg zur Produktion kopiert";
}
