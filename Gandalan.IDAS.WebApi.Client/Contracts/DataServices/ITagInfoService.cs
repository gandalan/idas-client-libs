using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.DTOs.UI;

namespace Gandalan.Client.Contracts.DataServices;

public interface ITagInfoService
{
    Task<IList<TagInfoDTO>> GetAllAsync(DateTime? changedSince = null);
    Task<IList<TagInfoDTO>> GetTagInfoSuggestionsAsync(DateTime? changedSince = null);
    Task<IList<TagInfoDTO>> GetTagInfoAsync(Guid objectGuid);
    Task<IDictionary<Guid, IEnumerable<TagInfoDTO>>> GetTagInfoAsync(IEnumerable<Guid> guidList);
    Task<IDictionary<Guid, IEnumerable<TagInfoDTO>>> GetTagInfoFremdfertigungAsync(IEnumerable<Guid> guidList);
    Task AddOrUpdateTagInfoAsync(TagInfoDTO dto);
    Task DeleteTagInfoAsync(TagInfoDTO dto);
}
