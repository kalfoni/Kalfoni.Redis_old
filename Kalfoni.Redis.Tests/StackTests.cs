using StackExchange.Redis;
using System;
using Xunit;
using Kalfoni.Redis;

namespace Kalfoni.Redis.Tests
{
    public class StackTests
    {
        [Fact]
        public void PushPopTest1()
        {
            var host = "localhost";
            var port = "6379";
            var prefix = "";
            var connectionInformation = new Kalfoni.Redis.ConnectionInformation(host, port, prefix);

            var redisValue = new RedisValue();
            var stackName = "TestStack1";
            var redisKey = new RedisKey();


            string json = @"{
                            'Name': 'Bad Boys',
                            'ReleaseDate': '1995-4-7T00:00:00',
                            'Genres': [
                                'Action',
                                'Comedy'
                                 ]
                           }";
            redisValue = json;
            redisKey = stackName;


            var count = Queue.ListLength(connectionInformation, stackName);
            Assert.Equal(0, Convert.ToInt32(count));

            var result = Stack.Push(connectionInformation, redisValue, redisKey);
            Assert.True(result);

            count = Queue.ListLength(connectionInformation, stackName);
            Assert.Equal(1, Convert.ToInt32(count));


            var stackResult = Stack.Pop(connectionInformation, (RedisKey)stackName);
            Assert.True(result);
        }

        [Fact]

        public void PushPopTest2()
        {
            var host = "localhost";
            var port = "6379";
            var prefix = "";
            var connectionInformation = new Kalfoni.Redis.ConnectionInformation(host, port, prefix);

            var redisValue = new RedisValue();
            var stackName = "TestStack2";

            string json = @"{
                            'Name': 'Bad Boys',
                            'ReleaseDate': '1995-4-7T00:00:00',
                            'Genres': [
                                'Action',
                                'Comedy'
                                 ]
                           }";
            redisValue = json;


            var count = Queue.ListLength(connectionInformation, stackName);
            Assert.Equal(0, Convert.ToInt32(count));

            var result = Stack.Push(connectionInformation, json, stackName);
            Assert.True(result);


            count = Queue.ListLength(connectionInformation, stackName);
            Assert.Equal(1, Convert.ToInt32(count));

            var StackResult = Stack.Pop(connectionInformation, stackName);
            Assert.True(result);
        }

        [Fact]
        public void RedisValuePushException()
        {
            var host = "wronghost";
            var port = "6379";
            var prefix = "";
            var connectionInformation = new Kalfoni.Redis.ConnectionInformation(host, port, prefix);

            var redisValue = new RedisValue();
            var stackName = "TestStackPushException";
            var redisKey = new RedisKey();


            string json = @"{
                            'Name': 'Bad Boys',
                            'ReleaseDate': '1995-4-7T00:00:00',
                            'Genres': [
                                'Action',
                                'Comedy'
                                 ]
                           }";
            redisValue = json;
            redisKey = stackName;

            Assert.Throws<Exception>(() => Kalfoni.Redis.Stack.Push(connectionInformation, redisValue, redisKey));
        }


        [Fact]
        public void RedisValuePopException()
        {
            var host = "wronghost";
            var port = "6379";
            var prefix = "";
            var connectionInformation = new Kalfoni.Redis.ConnectionInformation(host, port, prefix);

            var stackName = "TestStackPopException";
            var redisKey = new RedisKey();


            redisKey = stackName;

            Assert.Throws<Exception>(() => Kalfoni.Redis.Stack.Pop(connectionInformation, redisKey));
        }

    }
}
