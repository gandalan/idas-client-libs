﻿using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO.DTOs.Filter;
using System;
using System.Threading.Tasks;
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
                return Get<FilterItemDTO[]>("Filter/GetAll");
            }
            return null;
        }
        public FilterItemDTO GetFilterItem(Guid id)
        {
            if (Login())
            {
                return Get<FilterItemDTO>("Filter/GetByGuid?id=" + id.ToString());
            }
            return null;
        }
        public FilterItemDTO[] GetFilterItemsByContext(string context)
        {
            if (Login())
            {
                return Get<FilterItemDTO[]>("Filter/GetByContext?context=" + context);
            }
            return null;
        }

        public string Save(FilterItemDTO dto)
        {
            if (Login())
            {
                return Put("Filter/Put", dto);
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