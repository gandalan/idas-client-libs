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

        public void AddOrUpdateTagInfoForWebJob(TagInfoDTO dto, bool isVorgang, bool isBelegPos)
        {
            if (Login())
            {
                Post($"AddTagInfoForWebJob?isVorgang={isVorgang}&isBelegPos={isBelegPos}", dto);
            }
        }
    }
}
