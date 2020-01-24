using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kalfoni.Redis
{
    public class ConnectionInformation
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string KeyPrefix { get; set; }
        public int? ConnectionTimeoutValue { get; set; }
        public int? SyncTimeoutValue { get; set; }
        public Boolean? AbortOnConnectFailValue { get; set; }

        public Lazy<ConnectionMultiplexer> LazyConnection { get; set; }

        public ConnectionInformation() { }

        public void CreateConnection()
        {
            if (string.IsNullOrEmpty(Host))
            {
                throw new Exception("Host cannot be Null Or Empty");
            }
            if (string.IsNullOrEmpty(Port))
            {
                throw new Exception("Port cannot be Null Or Empty");
            }
            try
            {
                var tempint = Convert.ToInt32(Port);
            }
            catch (Exception)
            {
                throw new Exception("Port has to be a number");
            }
            if (!ConnectionTimeoutValue.HasValue)
            {
                ConnectionTimeoutValue = 5;
            }
            if (!SyncTimeoutValue.HasValue)
            {
                SyncTimeoutValue = 1;
            }
            if (!AbortOnConnectFailValue.HasValue)
            {
                AbortOnConnectFailValue = true;
            }

            LazyConnection = GenerateLazyConnection();
        }

        public ConnectionInformation(string Host, string Port, string KeyPrefix)
        {
            this.Host = Host;
            this.Port = Port;
            this.KeyPrefix = KeyPrefix;
            CreateConnection();
        }


        private Lazy<ConnectionMultiplexer> GenerateLazyConnection()
        {
            var redisConnection = GenerateRedisConnection();
            var configurationOptions = new ConfigurationOptions();
            configurationOptions.EndPoints.Add(redisConnection);
            configurationOptions.ClientName = redisConnection + ":RedisConnection";
            configurationOptions.ConnectTimeout = Convert.ToInt32(TimeSpan.FromSeconds(ConnectionTimeoutValue.Value).TotalMilliseconds);
            configurationOptions.SyncTimeout = Convert.ToInt32(TimeSpan.FromSeconds(SyncTimeoutValue.Value).TotalMilliseconds);
            configurationOptions.AbortOnConnectFail = AbortOnConnectFailValue.Value;

            return new Lazy<ConnectionMultiplexer>(() => { return ConnectionMultiplexer.Connect(configurationOptions); });
        }

        private string GenerateRedisConnection()
        {
            var stringbuilder = new StringBuilder();
            stringbuilder.Append(Host);
            stringbuilder.Append(":");
            stringbuilder.Append(this.Port);
            return stringbuilder.ToString();
        }



    }
}
