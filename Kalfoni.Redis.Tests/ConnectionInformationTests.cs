using System;
using Xunit;
using Kalfoni.Redis;

namespace Kalfoni.Redis.Tests
{
    public class ConnectionInformationTests
    {
        [Fact]
        public void ConnectionInformationTest1()
        {
            var host = "localhost";
            var port = "6379";
            var prefix = "";
            var connectionInformation = new Kalfoni.Redis.ConnectionInformation(host, port, prefix);
            Assert.Equal(connectionInformation.Host, host);
            Assert.Equal(connectionInformation.Port, port);
            Assert.Equal(connectionInformation.KeyPrefix, prefix);

        }

        [Fact]
        public void ConnectionInformationTest2()
        {
            var host = "";
            var port = "6379";
            var prefix = "";
            Assert.Throws<Exception>(() => new Kalfoni.Redis.ConnectionInformation(host, port, prefix));
        }

        [Fact]
        public void ConnectionInformationTest3()
        {
            var host = "localhost";
            var port = "";
            var prefix = "";
            Assert.Throws<Exception>(() => new Kalfoni.Redis.ConnectionInformation(host, port, prefix));
        }
        [Fact]
        public void ConnectionInformationTest4()
        {
            var host = "localhost";
            var port = "localhost";
            var prefix = "";
            Assert.Throws<Exception>(() => new Kalfoni.Redis.ConnectionInformation(host, port, prefix));
        }

        [Fact]
        public async void ConnectionInformationTest5Async()
        {            
            var RedisConnectionInformation = new Kalfoni.Redis.ConnectionInformation("localhost", "6379", "Lumen_" + "Test");
            RedisConnectionInformation.AbortOnConnectFailValue = true;
            RedisConnectionInformation.ConnectionTimeoutValue = 5;
            RedisConnectionInformation.SyncTimeoutValue = 1;

            Assert.NotNull(RedisConnectionInformation.LazyConnection);
            Assert.Equal("localhost", RedisConnectionInformation.Host);
            Assert.Equal("6379", RedisConnectionInformation.Port);
            Assert.Equal("Lumen_Test", RedisConnectionInformation.KeyPrefix);
            Assert.Equal(5, RedisConnectionInformation.ConnectionTimeoutValue);
            Assert.Equal(1, RedisConnectionInformation.SyncTimeoutValue);
            Assert.True(RedisConnectionInformation.AbortOnConnectFailValue);

        }

        [Fact]
        public void ConnectionInformationTest6()
        {
            var redisConnectionInformation = new Kalfoni.Redis.ConnectionInformation();
            redisConnectionInformation.Host = "localhost";
            redisConnectionInformation.Port = "6379";
            redisConnectionInformation.KeyPrefix = "Lumen_Test";
            redisConnectionInformation.ConnectionTimeoutValue = 6;
            redisConnectionInformation.SyncTimeoutValue = 4;
            redisConnectionInformation.AbortOnConnectFailValue = true;

            redisConnectionInformation.CreateConnection();

            Assert.NotNull(redisConnectionInformation.LazyConnection);
            Assert.Equal("localhost", redisConnectionInformation.Host);
            Assert.Equal("6379", redisConnectionInformation.Port);
            Assert.Equal("Lumen_Test", redisConnectionInformation.KeyPrefix);
            Assert.Equal(6, redisConnectionInformation.ConnectionTimeoutValue);
            Assert.Equal(4, redisConnectionInformation.SyncTimeoutValue);
            Assert.True(redisConnectionInformation.AbortOnConnectFailValue);

        }
    }
}
