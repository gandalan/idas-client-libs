using System;

namespace Gandalan.IDAS.Contracts.Belege;

public class BelegHistorieBase
{
    public Guid BelegHistorieGuid { get; set; }
    public virtual string Text { get; set; }
    public virtual DateTime Zeitstempel { get; set; }
    public virtual string Benutzer { get; set; }

    public BelegHistorieBase()
    {
        BelegHistorieGuid = Guid.NewGuid();
        Zeitstempel = DateTime.UtcNow;
    }
}
