/**
 * Kontext-Schlüssel für Ansichten mit Reitern (z. B. in m3 Lager, Stammdaten): Der Host
 * zeigt EINEN Seitenkopf mit dem Titel der Ansicht als ersten Block und setzt
 * diesen Kontext; der Seitenkopf im Inhalt eines Reiters lässt dann den Titel
 * weg und behält Meta-Zeile, Aktionen und Filter (Vorbild Warenkorb: Seitenkopf
 * zuerst, Reiter darunter).
 */
export const PAGE_HEADER_WITHOUT_TITLE = Symbol.for("weblibs-ui:page-header-without-title");
