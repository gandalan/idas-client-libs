using System.Collections.Generic;
using Gandalan.Client.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.Contracts;

public interface IAnsprechPartnerLookup : ILookupDialog<List<PersonDTO>, IAnsprechPartnerLookupParams>
{
}

public interface IAnsprechPartnerLookupParams
{
    List<PersonDTO> Personen { get; }
    bool MultiSelect { get; }
}

public class AnsprechPartnerLookupParams : IAnsprechPartnerLookupParams
{
    public List<PersonDTO> Personen { get; set; }
    public bool MultiSelect { get; set; }

    public AnsprechPartnerLookupParams(List<PersonDTO> list, bool multiSelect)
    {
        Personen = list;
        MultiSelect = multiSelect;
    }
}