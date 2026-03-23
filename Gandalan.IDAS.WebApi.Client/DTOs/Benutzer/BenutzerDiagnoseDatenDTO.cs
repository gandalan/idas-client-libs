using System;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Benutzer;

public class BenutzerDiagnoseDatenDTO
{
    public DateTime LastSuccessfulLogin { get; set; }
    public DateTime LastFailedLogin { get; set; }
    public DateTime LastPasswordReset { get; set; }
    public int FailedLoginCount { get; set; }
    public int PasswordResetCount { get; set; }
    public bool BenutzerAktiv { get; set; }
    public bool IstSicSynchronized { get; set; }
    public string LastSicMesssage { get; set; }
    public bool IstVariantenListeSynchronized { get; set; }
    public int AnzahlBenutzerMandant { get; set; }
    public int AnzahlMandantMitGuid { get; set; }
    public bool MandantIstAktiv { get; set; }
    public bool MandantIstProduzent { get; set; }
    public string MandantName { get; set; }
    public string MandantBeschreibung { get; set; }
    public bool KontaktVorhanden { get; set; }
    public bool KontaktIstAktiv { get; set; }
    public bool KontaktIstGesperrt { get; set; }

    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();

        sb.AppendLine("=== Benutzer ===");
        sb.AppendLine($"Aktiv:              {(BenutzerAktiv ? "Ja" : "Nein")}");
        sb.AppendLine($"SIC synchronisiert: {(IstSicSynchronized ? "Ja" : "Nein")}");
        sb.AppendLine($"Letzte SIC-Meldung: {LastSicMesssage ?? "-"}");
        sb.AppendLine($"Varianten synchr.:  {(IstVariantenListeSynchronized ? "Ja" : "Nein")}");
        sb.AppendLine();

        sb.AppendLine("=== Login ===");
        sb.AppendLine($"Letzter erfolgreicher Login: {(LastSuccessfulLogin == DateTime.MinValue ? "-" : LastSuccessfulLogin.ToLocalTime().ToString("dd.MM.yyyy HH:mm:ss"))}");
        sb.AppendLine($"Letzter fehlgeschl. Login:   {(LastFailedLogin == DateTime.MinValue ? "-" : LastFailedLogin.ToLocalTime().ToString("dd.MM.yyyy HH:mm:ss"))}");
        sb.AppendLine($"Fehlgeschlagene Logins:      {FailedLoginCount}");
        sb.AppendLine();

        sb.AppendLine("=== Passwort ===");
        sb.AppendLine($"Letzter Passwort-Reset: {(LastPasswordReset == DateTime.MinValue ? "-" : LastPasswordReset.ToLocalTime().ToString("dd.MM.yyyy HH:mm:ss"))}");
        sb.AppendLine($"Anzahl Passwort-Resets: {PasswordResetCount}");
        sb.AppendLine();

        sb.AppendLine("=== Mandant ===");
        sb.AppendLine($"Name:                   {MandantName ?? "-"}");
        sb.AppendLine($"Beschreibung:           {MandantBeschreibung ?? "-"}");
        sb.AppendLine($"Anzahl Mandanten:       {AnzahlBenutzerMandant}");
        sb.AppendLine($"Mandanten mit Guid:     {AnzahlMandantMitGuid}");
        sb.AppendLine($"Mandant aktiv:          {(MandantIstAktiv ? "Ja" : "Nein")}");
        sb.AppendLine($"Mandant ist Produzent:  {(MandantIstProduzent ? "Ja" : "Nein")}");
        sb.AppendLine();

        sb.AppendLine("=== Kontakt ===");
        sb.AppendLine($"Kontakt vorhanden:      {(KontaktVorhanden ? "Ja" : "Nein")}");
        sb.AppendLine($"Kontakt aktiv:          {(KontaktVorhanden ? (KontaktIstAktiv ? "Ja" : "Nein") : "-")}");
        sb.AppendLine($"Kontakt gesperrt:       {(KontaktVorhanden ? (KontaktIstGesperrt ? "Ja" : "Nein") : "-")}");

        return sb.ToString();
    }
}
