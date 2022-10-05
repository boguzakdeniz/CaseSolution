using CaseSolution.BLL.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;

namespace CaseSolution.BLL.Service
{
    public class CacheOperation : ICacheOperation
    {
        static ConnectionMultiplexer _redisClient;

        readonly IDatabase _redisDb;

        public CacheOperation(IConfiguration configuration)
        {
            if (_redisClient is null)
            {
                _redisClient = ConnectionMultiplexer.Connect(configuration["RedisHostPort"]);
            }

            _redisClient.ConnectionFailed += delegate (object sender, ConnectionFailedEventArgs e)
            {
                _redisClient = ConnectionMultiplexer.Connect(configuration["RedisHostPort"]);
            };

            _redisDb = _redisClient.GetDatabase(0);
        }

           
        public void Clear(string key) => _redisDb.KeyDelete(key);

        public T Get<T>(string key)
        {
            var result = _redisDb.StringGet(key);

            if (result.IsNullOrEmpty)
                return default(T);

            var resultData = JsonConvert.DeserializeObject<T>(result.ToString());

            return resultData;
        }
        public void Set<T>(string key, T value)
        {
            try
            {
                string dataString = JsonConvert.SerializeObject(value);
                _redisDb.StringSet(key, dataString);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, "value");
            }
        }
    }
}
