using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.UI;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class TagInfoWebRoutinen : WebRoutinenBase
{
    public TagInfoWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<IList<TagInfoDTO>> GetAllTagInfoAsync(DateTime? changedSince = null)
    {
        if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
        {
            return await GetAsync<List<TagInfoDTO>>($"GetAllTagInfo?changedSince={changedSince.Value:o}");
        }

        return await GetAsync<List<TagInfoDTO>>("GetAllTagInfo");
    }

    public async Task<IList<TagInfoDTO>> GetTagInfoSuggestionsAsync(DateTime? changedSince = null)
    {
        if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
        {
            return await GetAsync<List<TagInfoDTO>>($"GetTagInfoSuggestions?changedSince={changedSince.Value:o}");
        }

        return await GetAsync<List<TagInfoDTO>>("GetTagInfoSuggestions");
    }

    public async Task<IList<TagInfoDTO>> GetTagInfoAsync(Guid objectGuid)
        => await GetAsync<List<TagInfoDTO>>($"GetTagInfo?objectGuid={objectGuid}");

    public async Task<IDictionary<Guid, IEnumerable<TagInfoDTO>>> GetTagInfoAsync(IEnumerable<Guid> guidList)
        => await PutAsync<Dictionary<Guid, IEnumerable<TagInfoDTO>>>("GetTagInfoForGuidList", guidList);

    public async Task<IDictionary<Guid, IEnumerable<TagInfoDTO>>> GetTagInfoFremdfertigungAsync(IEnumerable<Guid> guidList)
        => await PutAsync<Dictionary<Guid, IEnumerable<TagInfoDTO>>>("GetTagInfoForFremdfertigungGuidList", guidList);

    public async Task AddOrUpdateTagInfoAsync(TagInfoDTO dto)
        => await PostAsync("TagInfo", dto);

    public async Task DeleteTagInfoAsync(TagInfoDTO dto)
        => await DeleteAsync("TagInfo", dto);

    public async Task<IList<TagVorlageDTO>> GetTagVorlagenAsync()
        => await GetAsync<List<TagVorlageDTO>>($"TagVorlagen/GetTagVorlagen");

    public async Task AddOrUpdateTagVorlageAsync(TagVorlageDTO dto)
        => await PostAsync("TagVorlagen/AddOrUpdateTagVorlagen", dto);

    public async Task DeleteTagVorlageAsync(Guid tagVorlageGuid)
        => await DeleteAsync($"TagVorlagen/DeleteTagVorlage?tagVorlageGuid={tagVorlageGuid}");

    public async Task<IList<TagInfoDTO>> GetTagInfoForFunctionAsync(Guid objectGuid, long mandantID)
        => await GetAsync<List<TagInfoDTO>>($"GetTagInfoForFunction?objectGuid={objectGuid}&mandantID={mandantID}");

    public async Task<IDictionary<Guid, IEnumerable<TagInfoDTO>>> GetTagInfoListForFunctionAsync(IEnumerable<Guid> guidList, long mandantID)
        => await PutAsync<Dictionary<Guid, IEnumerable<TagInfoDTO>>>($"GetTagInfoListForFunction?mandantID={mandantID}", guidList);

    public async Task AddTagInfoForFunctionAsync(TagInfoDTO dto, long mandantID)
        => await PostAsync($"AddTagInfoForFunction?mandantID={mandantID}", dto);

    public async Task DeleteTagInfoForFunctionAsync(TagInfoDTO dto, long mandantID)
        => await DeleteAsync($"DeleteTagInfoForFunction?mandantID={mandantID}", dto);
}
