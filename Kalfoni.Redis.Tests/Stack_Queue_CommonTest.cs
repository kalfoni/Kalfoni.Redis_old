using StackExchange.Redis;
using System;
using Xunit;
using Kalfoni.Redis;

namespace Kalfoni.Redis.Tests
{
    public class StackQueueCommmonTests
    {
        [Fact]
        public void ListLengthException()
        {
            var host = "wronghost";
            var port = "6379";
            var prefix = "";
            var connectionInformation = new Kalfoni.Redis.ConnectionInformation(host, port, prefix);

            var stackName = "TestStackQueueListLengthException";
            var redisKey = new RedisKey();
            redisKey = stackName;

            Assert.Throws<Exception>(() => Kalfoni.Redis.Stack_Queue_Common.ListLength(connectionInformation, redisKey));
        }

    }
}
