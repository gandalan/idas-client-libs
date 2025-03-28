using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.DTOs.UI;

namespace Gandalan.Client.Common.Data;

public interface ITagInfoService
{
    Task<IList<TagInfoDTO>> GetAllAsync(DateTime? changedSince);
}
