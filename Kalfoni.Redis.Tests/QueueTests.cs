using StackExchange.Redis;
using System;
using Xunit;
using Kalfoni.Redis;

namespace Kalfoni.Redis.Tests
{
    public class QueueTests
    {
        [Fact]
        public void EnqueueDequeueTest1()
        {
            var host = "localhost";
            var port = "6379";
            var prefix = "";
            var connectionInformation = new Kalfoni.Redis.ConnectionInformation(host, port, prefix);

            var redisValue = new RedisValue();
            var stackName = "TestQueue1";
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

            var count = Queue.ListLength(connectionInformation, redisKey);
            Assert.Equal(0, Convert.ToInt32(count));

            var result = Queue.Enqueue(connectionInformation, redisValue, redisKey);
            Assert.True(result);

            count = Queue.ListLength(connectionInformation, redisKey);
            Assert.Equal(1, Convert.ToInt32(count));

            var queueResult = Queue.Dequeue(connectionInformation, (RedisKey)stackName);
            Assert.Equal(redisValue, queueResult);



        }

        [Fact]
        public void EnqueueDequeueTest2()
        {
            var host = "localhost";
            var port = "6379";
            var prefix = "";
            var connectionInformation = new Kalfoni.Redis.ConnectionInformation(host, port, prefix);

            var redisValue = new RedisValue();
            var stackName = "TestQueue2";

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

            var result = Queue.Enqueue(connectionInformation, json, stackName);
            Assert.True(result);

            count = Queue.ListLength(connectionInformation, stackName);
            Assert.Equal(1, Convert.ToInt32(count));

            var queueRresult = Queue.Dequeue(connectionInformation, stackName);
            Assert.True(result);
        }

        [Fact]
        public void EnqueueException()
        {
            var host = "wronghost";
            var port = "6379";
            var prefix = "";
            var connectionInformation = new Kalfoni.Redis.ConnectionInformation(host, port, prefix);

            var redisValue = new RedisValue();
            var stackName = "TestQueueEnqueueException";
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

            Assert.Throws<Exception>(() => Kalfoni.Redis.Queue.Enqueue(connectionInformation, redisValue, redisKey));
        }


        [Fact]
        public void DequeueException()
        {
            var host = "wronghost";
            var port = "6379";
            var prefix = "";
            var connectionInformation = new Kalfoni.Redis.ConnectionInformation(host, port, prefix);

            var redisValue = new RedisValue();
            var stackName = "TestQueueDequeueException";
            var redisKey = new RedisKey();


            string json = @"{
                            'Name': 'Bad Boys',
                            'ReleaseDate': '1995-4-7T00:00:00',
                            'Genres': [
                                'Action',
                                'Comedy'
                                 ]
                           }";
            redisKey = stackName;

            Assert.Throws<Exception>(() => Kalfoni.Redis.Queue.Dequeue(connectionInformation, redisKey));
        }


    }
}
