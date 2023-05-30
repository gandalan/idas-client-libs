using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.UI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class TagInfoWebRoutinen : WebRoutinenBase
    {
        public TagInfoWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<IList<TagInfoDTO>> GetAllTagInfoAsync(DateTime? changedSince = null)
        {
            if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
            {
                return await GetAsync<List<TagInfoDTO>>("GetAllTagInfo?changedSince=" + changedSince.Value.ToString("o"));
            }
            else
            {
                return await GetAsync<List<TagInfoDTO>>("GetAllTagInfo");
            }
        }

        public async Task<IList<TagInfoDTO>> GetTagInfoSuggestionsAsync(DateTime? changedSince = null)
        {
            if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
            {
                return await GetAsync<List<TagInfoDTO>>("GetTagInfoSuggestions?changedSince=" + changedSince.Value.ToString("o"));
            }
            else
            {
                return await GetAsync<List<TagInfoDTO>>("GetTagInfoSuggestions");
            }
        }

        public async Task<IList<TagInfoDTO>> GetTagInfoAsync(Guid objectGuid)
            => await GetAsync<List<TagInfoDTO>>($"GetTagInfo?objectGuid={objectGuid}");

        public async Task<IDictionary<Guid, IEnumerable<TagInfoDTO>>> GetTagInfoAsync(IEnumerable<Guid> guidList)
            => await PutAsync<Dictionary<Guid, IEnumerable<TagInfoDTO>>>($"GetTagInfoForGuidList", guidList);

        public async Task AddOrUpdateTagInfoAsync(TagInfoDTO dto)
            => await PostAsync($"TagInfo", dto);

        public async Task DeleteTagInfoAsync(TagInfoDTO dto) 
            => await DeleteAsync($"TagInfo", dto);

        public async Task<IList<TagInfoDTO>> GetTagInfoForFunction(Guid objectGuid, long mandantID) 
            => await GetAsync<List<TagInfoDTO>>($"GetTagInfoForFunction?objectGuid={objectGuid}&mandantID={mandantID}");

        public async Task<IDictionary<Guid, IEnumerable<TagInfoDTO>>> GetTagInfoListForFunction(IEnumerable<Guid> guidList, long mandantID) 
            => await PutAsync<Dictionary<Guid, IEnumerable<TagInfoDTO>>>($"GetTagInfoListForFunction?mandantID={mandantID}", guidList);

        public async Task AddTagInfoForFunction(TagInfoDTO dto, long mandantID) 
            => await PostAsync($"AddTagInfoForFunction?mandantID={mandantID}", dto);

        public async Task DeleteTagInfoForFunction(TagInfoDTO dto, long mandantID) 
            => await DeleteAsync($"DeleteTagInfoForFunction?mandantID={mandantID}", dto);
    }
}
