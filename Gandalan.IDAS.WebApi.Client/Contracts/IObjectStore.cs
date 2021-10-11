using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.Client.Contracts
{
    public interface IObjectStore<T> where T : new()
    {
        IList<T> GetAll();
        IList<T> Get(Func<T, bool> filter);
        void Put(T item);
        void Remove(T item);
    }
}
