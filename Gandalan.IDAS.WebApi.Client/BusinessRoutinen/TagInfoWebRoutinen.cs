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

        public IList<TagInfoDTO> GetAllTagInfo(DateTime? changedSince = null)
        {
            if (Login())
            {
                if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
                {
                    return Get<List<TagInfoDTO>>("GetAllTagInfo?changedSince=" + changedSince.Value.ToString("o"));
                }
                else
                {
                    return Get<List<TagInfoDTO>>("GetAllTagInfo");
                }
            }
            return null;
        }

        public async Task<IList<TagInfoDTO>> GetAllTagInfoAsync(DateTime? changedSince = null)
        {
            return await Task.Run(() => GetAllTagInfo(changedSince));
        }

        public IList<TagInfoDTO> GetTagInfoSuggestions(DateTime? changedSince = null)
        {
            if (Login())
            {
                if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
                {
                    return Get<List<TagInfoDTO>>("GetTagInfoSuggestions?changedSince=" + changedSince.Value.ToString("o"));
                }
                else
                {
                    return Get<List<TagInfoDTO>>("GetTagInfoSuggestions");
                }
            }
            return null;
        }

        public async Task<IList<TagInfoDTO>> GetTagInfoSuggestionsAsync(DateTime? changedSince = null)
        {
            return await Task.Run(() => GetTagInfoSuggestions(changedSince));
        }

        public IList<TagInfoDTO> GetTagInfo(Guid objectGuid)
        {
            if (Login())
            {
                return Get<List<TagInfoDTO>>($"GetTagInfo?objectGuid={objectGuid}");
            }
            return null;
        }

        public async Task<IList<TagInfoDTO>> GetTagInfoAsync(Guid objectGuid)
        {
            return await Task.Run(() => GetTagInfo(objectGuid));
        }

        public IDictionary<Guid, IEnumerable<TagInfoDTO>> GetTagInfo(IEnumerable<Guid> guidList)
        {
            if (Login())
            {
                return Put<Dictionary<Guid, IEnumerable<TagInfoDTO>>>($"GetTagInfoForGuidList", guidList);
            }
            return null;
        }

        public async Task<IDictionary<Guid, IEnumerable<TagInfoDTO>>> GetTagInfoAsync(IEnumerable<Guid> guidList)
        {
            return await Task.Run(() => GetTagInfo(guidList));
        }

        public void AddOrUpdateTagInfo(TagInfoDTO dto)
        {
            if (Login())
            {
                Post($"TagInfo", dto);
            }
        }

        public async Task AddOrUpdateTagInfoAsync(TagInfoDTO dto)
        {
            await Task.Run(() => AddOrUpdateTagInfo(dto));
        }

        public void DeleteTagInfo(TagInfoDTO dto)
        {
            if (Login())
            {
                Delete<TagInfoDTO>($"TagInfo", dto);
            }
        }

        public async Task DeleteTagInfoAsync(TagInfoDTO dto)
        {
            await Task.Run(() => DeleteTagInfo(dto));
        }

        public IList<TagInfoDTO> GetTagInfoForFunction(Guid objectGuid, long mandantID)
        {
            if (Login())
            {
                return Get<List<TagInfoDTO>>($"GetTagInfoForFunction?objectGuid={objectGuid}&mandantID={mandantID}");
            }
            return null;
        }

        public IDictionary<Guid, IEnumerable<TagInfoDTO>> GetTagInfoListForFunction(IEnumerable<Guid> guidList, long mandantID)
        {
            if (Login())
            {
                return Put<Dictionary<Guid, IEnumerable<TagInfoDTO>>>($"GetTagInfoListForFunction?mandantID={mandantID}", guidList);
            }
            return null;
        }

        public void AddTagInfoForFunction(TagInfoDTO dto, long mandantID)
        {
            if (Login())
            {
                Post($"AddTagInfoForFunction?mandantID={mandantID}", dto);
            }
        }

        public void DeleteTagInfoForFunction(TagInfoDTO dto, long mandantID)
        {
            if (Login())
            {
                Delete<TagInfoDTO>($"DeleteTagInfoForFunction?mandantID={mandantID}", dto);
            }
        }
    }
}
