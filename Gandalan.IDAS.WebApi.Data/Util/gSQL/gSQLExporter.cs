using Gandalan.IDAS.WebApi.DTO;
using System;
using System.IO;
using System.Linq;

namespace Gandalan.IDAS.WebApi.Util.gSQL
{
    public class gSQLExporter
    {
        public static void ExportToFile(string fileName, VorgangDTO vorgang, BelegDTO beleg)
        {
            gSQLInhalt result = Beleg2GSQL(vorgang, beleg);
            File.WriteAllText(fileName, result.ToString());
        }

        public static gSQLInhalt Beleg2GSQL(VorgangDTO vorgang, BelegDTO beleg)
        {
            gSQLInhalt result = new gSQLInhalt();

            gSQLSektion aktuelleSektion = new gSQLSektion("Achtung");
            aktuelleSektion.Items.Add(new gSQLItem("!!!", "Dieses Dateiformat ist nur für interne Abläufe von Gandalan gedacht."));
            aktuelleSektion.Items.Add(new gSQLItem("!!!", "Es unterliegt ständigen Änderungen und wird nicht supported."));
            aktuelleSektion.Items.Add(new gSQLItem("!!!", "Für Anbindungen an kundenspezifische Software verwenden Sie bitte "));
            aktuelleSektion.Items.Add(new gSQLItem("!!!", "die Neher Cloud API."));
            result.Sektionen.Add(aktuelleSektion);

            aktuelleSektion = new gSQLSektion("Dateikopf");
            aktuelleSektion.Items.Add(new gSQLItem("DatenFormat", "gSQL70"));
            aktuelleSektion.Items.Add(new gSQLItem("letzterZugriff", vorgang.AenderungsDatum.ToUniversalTime().ToString("O")));
            aktuelleSektion.Items.Add(new gSQLItem("ErstellDatum", vorgang.ErstellDatum.ToUniversalTime().ToString("O")));
            aktuelleSektion.Items.Add(new gSQLItem("AenderungsDatum", vorgang.AenderungsDatum.ToUniversalTime().ToString("O")));
            aktuelleSektion.Items.Add(new gSQLItem("Bestellfix_Version", "01.10.2017"));
            aktuelleSektion.Items.Add(new gSQLItem("DatenQuelle", "NeherApp"));
            aktuelleSektion.Items.Add(new gSQLItem("DateiTyp", "Beleg"));
            result.Sektionen.Add(aktuelleSektion);

            aktuelleSektion = new gSQLSektion("IndexDaten");
            aktuelleSektion.Items.Add(new gSQLItem("BelegNummer", beleg.BelegNummer.ToString()));
            aktuelleSektion.Items.Add(new gSQLItem("VorgangsNummer", vorgang.VorgangsNummer.ToString()));
            aktuelleSektion.Items.Add(new gSQLItem("BelegJahr", beleg.BelegDatum.Year.ToString()));
            aktuelleSektion.Items.Add(new gSQLItem("Beleg_ID_Nummer", beleg.BelegGuid.ToString()));
            result.Sektionen.Add(aktuelleSektion);

            aktuelleSektion = new gSQLSektion("KopfDaten");
            aktuelleSektion.Items.Add(new gSQLItem("Beleg_Liefertermin", beleg.AusfuehrungsDatum));
            aktuelleSektion.Items.Add(new gSQLItem("Beleg_Kommission", vorgang.Kommission));
            aktuelleSektion.Items.Add(new gSQLItem("Beleg_Bemerkungen_FussZeile_1_Bestellschein", "???"));
            aktuelleSektion.Items.Add(new gSQLItem("Beleg_Bemerkungen_FussZeile_2_Bestellschein", "???"));
            //aktuelleSektion.Items.Add(new gSQLItem("Kundennummer", vorgang.Kontakt?.KundenNummer));
            //aktuelleSektion.Items.Add(new gSQLItem("HaendlerMandantGuid", vorgang.Kontakt.KontaktMandantGuid.ToString()));
            aktuelleSektion.Items.Add(new gSQLItem("VorgangGuid", vorgang.VorgangGuid.ToString()));
            //aktuelleSektion.Items.Add(new gSQLItem("OriginalVorgangGuid", vorgang.OriginalVorgangGuid.ToString()));
            //aktuelleSektion.Items.Add(new gSQLItem("OriginalVorgangsNummer", vorgang.OriginalVorgangsNummer?.ToString() ?? String.Empty));
            aktuelleSektion.Items.Add(new gSQLItem("Beleg_IstTestBeleg", vorgang.IstTestbeleg.ToString()));
            result.Sektionen.Add(aktuelleSektion);

            if (beleg.BelegAdresse != null)
            {
                aktuelleSektion = new gSQLSektion("Adresse");
                aktuelleSektion.Items.Add(new gSQLItem("Adresse_Anrede", beleg.BelegAdresse.Anrede));
                aktuelleSektion.Items.Add(new gSQLItem("Adresse_Firmenname", beleg.BelegAdresse.Firmenname));
                aktuelleSektion.Items.Add(new gSQLItem("Adresse_Vorname", beleg.BelegAdresse.Vorname));
                aktuelleSektion.Items.Add(new gSQLItem("Adresse_Name", beleg.BelegAdresse.Nachname));
                aktuelleSektion.Items.Add(new gSQLItem("Adresse_AdressZusatz1", beleg.BelegAdresse.AdressZusatz1));
                aktuelleSektion.Items.Add(new gSQLItem("Adresse_AdressZusatz2", beleg.BelegAdresse.AdressZusatz2));
                aktuelleSektion.Items.Add(new gSQLItem("Adresse_Strasse", beleg.BelegAdresse.Strasse));
                aktuelleSektion.Items.Add(new gSQLItem("Adresse_Hausnummer", beleg.BelegAdresse.Hausnummer));
                aktuelleSektion.Items.Add(new gSQLItem("Adresse_Land", beleg.BelegAdresse.Land));
                aktuelleSektion.Items.Add(new gSQLItem("Adresse_PLZ", beleg.BelegAdresse.Postleitzahl));
                aktuelleSektion.Items.Add(new gSQLItem("Adresse_Ort", beleg.BelegAdresse.Ort));
                aktuelleSektion.Items.Add(new gSQLItem("Adresse_VersandAdresseGleichBelegAdresse", beleg.VersandAdresseGleichBelegAdresse.ToString()));
                result.Sektionen.Add(aktuelleSektion);
            }

            if (beleg.VersandAdresse != null)
            {
                aktuelleSektion = new gSQLSektion("VersandAdresse");
                aktuelleSektion.Items.Add(new gSQLItem("VersandAdresse_Anrede", beleg.VersandAdresse.Anrede));
                aktuelleSektion.Items.Add(new gSQLItem("VersandAdresse_Firmenname", beleg.VersandAdresse.Firmenname));
                aktuelleSektion.Items.Add(new gSQLItem("VersandAdresse_Vorname", beleg.VersandAdresse.Vorname));
                aktuelleSektion.Items.Add(new gSQLItem("VersandAdresse_Name", beleg.VersandAdresse.Nachname));
                aktuelleSektion.Items.Add(new gSQLItem("VersandAdresse_AdressZusatz1", beleg.VersandAdresse.AdressZusatz1));
                aktuelleSektion.Items.Add(new gSQLItem("VersandAdresse_AdressZusatz2", beleg.VersandAdresse.AdressZusatz2));
                aktuelleSektion.Items.Add(new gSQLItem("VersandAdresse_Strasse", beleg.VersandAdresse.Strasse));
                aktuelleSektion.Items.Add(new gSQLItem("VersandAdresse_Hausnummer", beleg.VersandAdresse.Hausnummer));
                aktuelleSektion.Items.Add(new gSQLItem("VersandAdresse_Land", beleg.VersandAdresse.Land));
                aktuelleSektion.Items.Add(new gSQLItem("VersandAdresse_PLZ", beleg.VersandAdresse.Postleitzahl));
                aktuelleSektion.Items.Add(new gSQLItem("VersandAdresse_Ort", beleg.VersandAdresse.Ort));
                result.Sektionen.Add(aktuelleSektion);
            }

            aktuelleSektion = new gSQLSektion("OnlineDaten");
            aktuelleSektion.Items.Add(new gSQLItem("OnlineBestellung_DateiName", beleg.BelegGuid.ToString()));
            aktuelleSektion.Items.Add(new gSQLItem("OnlineBestellung_Datum", beleg.BelegDatum.ToUniversalTime().ToShortDateString()));
            result.Sektionen.Add(aktuelleSektion);

            aktuelleSektion = new gSQLSektion("FussZeilen");
            aktuelleSektion.Items.Add(new gSQLItem("AnzahlFussZeilen", beleg.Salden.Count().ToString()));
            int counter = 1;
            foreach (BelegSaldoDTO saldo in beleg.Salden)
            {
                aktuelleSektion.Items.Add(new gSQLItem("FussZeilenNummer", counter.ToString()));
                aktuelleSektion.Items.Add(new gSQLItem("FussZeile_Text1", saldo.Text));
                aktuelleSektion.Items.Add(new gSQLItem("FussZeile_Text1_Grundwert", ""));
                aktuelleSektion.Items.Add(new gSQLItem("FussZeile_Betrag2", saldo.Betrag.ToString()));
                aktuelleSektion.Items.Add(new gSQLItem("FussZeile_AktionText2", ""));
                aktuelleSektion.Items.Add(new gSQLItem("FussZeile_Prozent", saldo.Wert.ToString()));
                aktuelleSektion.Items.Add(new gSQLItem("FussZeile_passiv", ""));
                counter++;
            }
            result.Sektionen.Add(aktuelleSektion);

            aktuelleSektion = new gSQLSektion("Positionen");
            foreach (Guid posGuid in beleg.Positionen)
            {
                var pos = vorgang.Positionen.FirstOrDefault(p => p.BelegPositionGuid.Equals(posGuid));

                aktuelleSektion.Items.Add(new gSQLItem()); // Leerzeile
                aktuelleSektion.Items.Add(new gSQLItem("Position_PositionsNummer", pos.PositionsNummer));
                aktuelleSektion.Items.Add(new gSQLItem("Position_LaufendeNummer", pos.LaufendeNummer.ToString()));
                aktuelleSektion.Items.Add(new gSQLItem("Position_Nummer", pos.PositionsNummer));
                aktuelleSektion.Items.Add(new gSQLItem("Position_PositionsGuid", pos.BelegPositionGuid.ToString()));

                if (pos.Variante != null)
                {
                    aktuelleSektion.Items.Add(new gSQLItem("SystemTyp", "Insektenschutz"));
                    aktuelleSektion.Items.Add(new gSQLItem("Position_Variante", pos.Variante));
                }
                else if (pos.ArtikelNummer != null)
                {
                    aktuelleSektion.Items.Add(new gSQLItem("SystemTyp", "Katalogartikel"));
                    aktuelleSektion.Items.Add(new gSQLItem("Position_KatalogArtikel", pos.ArtikelNummer));
                }
                else
                {
                    aktuelleSektion.Items.Add(new gSQLItem("SystemTyp", "Sonderposition"));
                }

                aktuelleSektion.Items.Add(new gSQLItem("Position_Menge", pos.Menge.ToString()));
                aktuelleSektion.Items.Add(new gSQLItem("Position_MengenEinheit", pos.MengenEinheit));
                aktuelleSektion.Items.Add(new gSQLItem("Position_Besonderheiten", SanitizeString(pos.Besonderheiten)));
                aktuelleSektion.Items.Add(new gSQLItem("Position_Einbauort", SanitizeString(pos.Einbauort)));
                aktuelleSektion.Items.Add(new gSQLItem("Position_IstAktiv", pos.IstAktiv.ToString()));
                aktuelleSektion.Items.Add(new gSQLItem("Position_IstAlternativPosition", pos.IstAlternativPosition.ToString()));
                aktuelleSektion.Items.Add(new gSQLItem("Position_PositionsKommission", pos.PositionsKommission));
                aktuelleSektion.Items.Add(new gSQLItem("Position_Text", SanitizeString(pos.Text)));
                aktuelleSektion.Items.Add(new gSQLItem("Position_AngebotsText", SanitizeString(pos.AngebotsText)));
                aktuelleSektion.Items.Add(new gSQLItem("Position_SonderwunschText", SanitizeString(pos.SonderwunschText)));
                aktuelleSektion.Items.Add(new gSQLItem("Position_SonderwunschAngebotsText", SanitizeString(pos.SonderwunschAngebotsText)));

                foreach (var konfig in pos.Daten.Where(u => u.UnterkomponenteName == "Variante"))
                {
                    var key = konfig.KonfigName.Replace("Konfig.", "");
                    if (konfig.Wert == null ||
                        konfig.Wert.Contains("object Object") ||
                        konfig.Wert.Trim().StartsWith("{"))
                    {
                        continue;
                    }
                    aktuelleSektion.Items.Add(new gSQLItem("Position_" + key, konfig.Wert));
                }

                foreach (var konfig in pos.Daten.Where(u => u.UnterkomponenteName == "Artikel"))
                {
                    var key = konfig.KonfigName.Replace("Konfig.", "");
                    if (konfig.Wert == null ||
                        konfig.Wert == "object Object" ||
                        konfig.Wert.Trim().StartsWith("{"))
                    {
                        continue;
                    }
                    aktuelleSektion.Items.Add(new gSQLItem("Position_" + key, konfig.Wert));
                }

                if (pos.Sonderwuensche == null)
                {
                    continue;
                }

                foreach (var sw in pos.Sonderwuensche)
                {
                    var swBezeichnung = sw.Bezeichnung.Replace("Ä", "Ae").Replace("Ü", "Ue").Replace("Ö", "Oe");
                    swBezeichnung = swBezeichnung.Replace("ä", "ae").Replace("ü", "ue").Replace("ö", "oe");
                    swBezeichnung = swBezeichnung.Replace("ß", "ss");
                    swBezeichnung = swBezeichnung.Replace(" ", "_");

                    aktuelleSektion.Items.Add(new gSQLItem("Sonder_" + swBezeichnung, sw.Wert));

                    if (sw.Laenge > 0)
                    {
                        aktuelleSektion.Items.Add(new gSQLItem("Sonder_" + swBezeichnung + "_Laenge", sw.Laenge.ToString()));
                    }
                    if (sw.Hoehe > 0)
                    {
                        aktuelleSektion.Items.Add(new gSQLItem("Sonder_" + swBezeichnung + "_Hoehe", sw.Hoehe.ToString()));
                    }
                    if (!String.IsNullOrEmpty(sw.Farbe))
                    {
                        aktuelleSektion.Items.Add(new gSQLItem("Sonder_" + swBezeichnung + "_Farbe", sw.Farbe));
                    }
                }

            }

            result.Sektionen.Add(aktuelleSektion);

            return result;
        }

        private static string SanitizeString(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            return text.Replace("\r", "||").Replace("\n", "");
        }
    }
}
