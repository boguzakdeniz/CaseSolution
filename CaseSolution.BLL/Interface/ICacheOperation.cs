using System;
using System.Collections.Generic;
using System.Text;

namespace CaseSolution.BLL.Interface
{
    public interface ICacheOperation
    {
        List<T> GetCache<T>(string key);
        void Set<T>(string key, T value);
        void Append<T>(string key, T value);

    }
}
