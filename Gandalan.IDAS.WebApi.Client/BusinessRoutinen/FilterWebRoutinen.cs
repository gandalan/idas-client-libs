using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;
using Gandalan.IDAS.WebApi.DTO.DTOs.Filter;
namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class FilterWebRoutinen : WebRoutinenBase
    {
        public FilterWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }
        public FilterItemDTO[] GetAll()
        {
            if (Login())
            {
                return Get<FilterItemDTO[]>("Filter");
            }
            return null;
        }
        public FilterItemDTO GetFilterItem(Guid id)
        {
            if (Login())
            {
                return Get<FilterItemDTO>("Filter?id=" + id.ToString());
            }
            return null;
        }
        public FilterItemDTO[] GetFilterItemsByContext(string context)
        {
            if (Login())
            {
                return Get<FilterItemDTO[]>("Filter?context=" + context);
            }
            return null;
        }

        public string Save(FilterItemDTO dto)
        {
            if (Login())
            {
                return Put("Filter", dto);
            }
            return null;
        }       

        public async Task<FilterItemDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }
        public async Task<FilterItemDTO> GetFilterItemAsync(Guid id)
        {
            return await Task.Run(() => GetFilterItem(id));
        }
        public async Task<FilterItemDTO[]> GetFilterItemsByContextAsync(string context)
        {
            return await Task.Run(() => GetFilterItemsByContext(context));
        }
        public async Task SaveAsync(FilterItemDTO dto)
        {
            await Task.Run(() => Save(dto));
        }
    }
}