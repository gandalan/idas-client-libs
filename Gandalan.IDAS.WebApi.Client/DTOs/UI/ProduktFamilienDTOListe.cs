using System;
using System.Collections.ObjectModel;
using System.Linq;
using Gandalan.IDAS.WebApi.Util;

namespace Gandalan.IDAS.WebApi.DTO;

public class ProduktFamilienDTOListe : ObservableCollection<ProduktFamilieDTO>
{
    public VarianteDTOListe GetVariantenListe()
    {
        return new VarianteDTOListe(this.SelectMany(p => p.Varianten).OrderBy(v => v, new VarianteComparerByNeherName()));
    }

    public VarianteDTOListe GetVariantenListe(DateTime stichtag)
    {
        return new VarianteDTOListe(GetVariantenListe().Where(v => (v.GueltigAb == null || v.GueltigAb <= stichtag) && (v.GueltigBis == null || v.GueltigBis >= stichtag)));
    }

    public ProduktFamilieDTO GetProduktfamilieZuVariante(Guid guid)
    {
        return this.FirstOrDefault(p => p.Varianten.FirstOrDefault(v => v.VarianteGuid.Equals(guid)) != null);
    }

    public ProduktFamilieDTO GetProduktfamilieZuWarenGruppe(Guid guid)
    {
        return this.FirstOrDefault(p => p.WarengruppenGuid.Equals(guid));
    }
}