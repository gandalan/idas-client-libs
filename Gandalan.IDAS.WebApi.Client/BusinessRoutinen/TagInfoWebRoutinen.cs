using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.UI;
using Gandalan.IDAS.WebApi.DTO;
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

        public List<TagInfoDTO> GetAllTagInfo(DateTime? changedSince = null)
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
        public async Task<List<TagInfoDTO>> GetAllTagInfoAsync(DateTime? changedSince = null)
        {
            return await Task.Run(() => { return GetAllTagInfo(changedSince); });
        }

        public List<TagInfoDTO> GetTagInfo(Guid objectGuid)
        {
            if (Login())
            {
                return Get<List<TagInfoDTO>>($"GetTagInfo?objectGuid={objectGuid}");
            }
            return null;
        }
        public async Task<List<TagInfoDTO>> GetTagInfoAsync(Guid objectGuid)
        {
            return await Task.Run(() => { return GetTagInfo(objectGuid); });
        }

        public List<TagInfoDTO> GetTagInfo(GuidListDTO guidList)
        {
            if (Login())
            {
                return Put<List<TagInfoDTO>>($"GetTagInfoForGuidList", guidList);
            }
            return null;
        }

        public async Task<List<TagInfoDTO>> GetTagInfoAsync(GuidListDTO guidList)
        {
            return await Task.Run(() => { return GetTagInfo(guidList); });
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

        public List<TagInfoDTO> GetTagInfoForFunction(Guid objectGuid, long mandantID)
        {
            if (Login())
            {
                return Get<List<TagInfoDTO>>($"GetTagInfoForFunction?objectGuid={objectGuid}&mandantID={mandantID}");
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
