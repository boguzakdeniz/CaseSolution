using CaseSolution.BLL.Interface;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseSolution.BLL.Service
{
    public class CacheOperation : ICacheOperation
    {
        readonly IDatabase _redisDb;
        public CacheOperation(IDatabase redisDb)
        {
            this._redisDb= redisDb;
        }

        public void Append<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        public List<T> GetCache<T>(string key)
        {
            throw new NotImplementedException();
        }

        public void Set<T>(string key, T value)
        {
            throw new NotImplementedException();
        }
    }
}
