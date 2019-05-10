using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client;
using Gandalan.IDAS.WebApi.Client.Settings;

namespace Gandalan.IDAS.WebApi.Client
{
    public class TypedWebRoutinenBase<T> : WebRoutinenBase where T : new()
    {
        private Func<T, Guid> _getGuid;
        private string _endPoint;

        public TypedWebRoutinenBase(string endPoint, Func<T, Guid> getGuid, WebApiSettings settings) : base(settings)
        {
            _endPoint = endPoint;
            _getGuid = getGuid;
        }
        
        public T[] GetAll()
        {
            if (Login())
            {
                return Get<T[]>(_endPoint);
            }
            return null;
        }

        public T Get(Guid guid)
        {
            if (Login())
            {
                return Get<T>(_endPoint + "/" + guid);
            }
            return default(T);
        }


        public string Save(T dto)
        {
            if (Login())
            {
                return Put(_endPoint + "/" + _getGuid(dto), dto);
            }
            return null;
        }

        public void Delete(Guid guid)
        {
            if (Login())
            {
                Delete(_endPoint + "/" + guid);
            }
        }


        public async Task<T[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }
        public async Task SaveAsync(T dto)
        {
            await Task.Run(() => Save(dto));
        }
        public async Task DeleteAsync(Guid guid)
        {
            await Task.Run(() => Delete(guid));
        }
        public async Task<T> GetAsync(Guid guid)
        {
            return await Task.Run(() => Get(guid));
        }
    }
}
