using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.Client.Contracts
{
    public interface IObjectStore<T> where T : new()
    {
        T GetAll();
        T Get(Func<bool, T> filter);
        T Put(T item);
        void Remove(T item);
    }
}
