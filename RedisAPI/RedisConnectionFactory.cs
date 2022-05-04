using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
 
namespace RedisAPI
{
    public class RedisConnectionFactory
    {
        private static readonly Lazy<ConnectionMultiplexer> Connection;
        private static readonly string REDIS_CONNECTIONSTRING = "ConnectionStrings:Redis";
        private static IConfiguration _config;
        static RedisConnectionFactory()
        {
            Connection = new Lazy<ConnectionMultiplexer>(() => Connect());
        }
        private static ConnectionMultiplexer Connect() 
        {
            var connectionString = _config.GetValue<string>(REDIS_CONNECTIONSTRING);

            if (connectionString == null)
            {
                throw new KeyNotFoundException($"Environment variable for {REDIS_CONNECTIONSTRING} was not found.");
            }
 
            var options = ConfigurationOptions.Parse(connectionString);

            return ConnectionMultiplexer.Connect(options);
        }
 
        public static ConnectionMultiplexer GetConnection(IConfiguration config) 
        {
            _config = config;
            return Connection.Value;
        }
    }
}