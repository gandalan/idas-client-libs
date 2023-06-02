using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client
{
    public class TypedWebRoutinenBase<T> : WebRoutinenBase where T : new()
    {
        private Func<T, Guid> _getGuid;
        private string _endPoint;

        public TypedWebRoutinenBase(string endPoint, Func<T, Guid> getGuid, IWebApiConfig settings) : base(settings)
        {
            _endPoint = endPoint;
            _getGuid = getGuid;
        }

        public async Task<T[]> GetAllAsync() 
            => await GetAsync<T[]>(_endPoint);

        public async Task<T> GetAsync(Guid guid) 
            => await GetAsync<T>(_endPoint + "/" + guid);

        public async Task SaveAsync(T dto) 
            => await PutAsync(_endPoint + "/" + _getGuid(dto), dto);

        public async Task DeleteAsync(Guid guid) 
            => await DeleteAsync(_endPoint + "/" + guid);




    }
}
