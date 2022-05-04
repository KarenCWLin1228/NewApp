using System.Net.NetworkInformation;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
 
namespace RedisAPI
{
    public class RedisDataAgent
    {
        private static IDatabase _database;
        public RedisDataAgent(IConfiguration config, int db = 0)
        {
            var connection = RedisConnectionFactory.GetConnection(config);
 
            _database = connection.GetDatabase(db);
        }
 
        public string GetStringValue(string key)
        {
            return _database.StringGet(key);
        }
        public T GetListValue<T>(string key)
        {
            string str = _database.StringGet(key);
            if(!string.IsNullOrEmpty(str))
            {
                return JsonConvert.DeserializeObject<T>(str);
            }
            else{
                return default(T);
            }
        }
 
        public bool SetStringValue(string key, string value)
        {
            return _database.StringSet(key, value);
        }
        public bool SetListValue(string key, object value)
        {
            var json = JsonConvert.SerializeObject(value);
            return _database.StringSet(key, json);
        }
 
        public void DeleteValue(string key)
        {
            _database.KeyDelete(key);
        }
    }
}