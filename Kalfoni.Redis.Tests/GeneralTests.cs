using StackExchange.Redis;
using System;
using Xunit;
using Kalfoni.Redis;

namespace Kalfoni.Redis.Tests
{
    public class GeneralTests
    {
        [Fact]
        public void StringSet_StringGetTest1()
        {
            var host = "localhost";
            var port = "6379";
            var prefix = "";
            var connectionInformation = new Kalfoni.Redis.ConnectionInformation(host, port, prefix);

            var redisValue = new RedisValue();
            var keyName = "StringSet_StringGetTest1";
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
            redisKey = keyName;

            var result = Kalfoni.Redis.General.StringSet(connectionInformation, redisValue, redisKey, 1);
            Assert.True(result);

            var result2 = Kalfoni.Redis.General.StringGet(connectionInformation, redisKey);
            Assert.Equal(json, result2);
        }

        [Fact]
        public void StringSet_StringGetTest2()
        {
            var host = "localhost";
            var port = "6379";
            var prefix = "";
            var connectionInformation = new Kalfoni.Redis.ConnectionInformation(host, port, prefix);

            var keyName = "StringSet_StringGetTest2";



            string json = @"{
                            'Name': 'Bad Boys',
                            'ReleaseDate': '1995-4-7T00:00:00',
                            'Genres': [
                                'Action',
                                'Comedy'
                                 ]
                           }";

            var result = Kalfoni.Redis.General.StringSet(connectionInformation, json, keyName, 1);
            Assert.True(result);

            var result2 = Kalfoni.Redis.General.StringGet(connectionInformation, keyName);
            Assert.Equal(json, result2);
        }

        [Fact]
        public void StringSet_StringGetTest3()
        {
            var host = "localhost";
            var port = "6379";
            var prefix = "";
            var connectionInformation = new Kalfoni.Redis.ConnectionInformation(host, port, prefix);

            var keyName = "StringSet_StringGetTest2";



            string json = @"{
                            'Name': 'Bad Boys',
                            'ReleaseDate': '1995-4-7T00:00:00',
                            'Genres': [
                                'Action',
                                'Comedy'
                                 ]
                           }";

            var result = Kalfoni.Redis.General.StringSet(connectionInformation, json, keyName, 3000, General.TimeUnit.Milliseconds);
            Assert.True(result);

            var result2 = Kalfoni.Redis.General.StringGet(connectionInformation, keyName);
            Assert.Equal(json, result2);
        }



        [Fact]
        public void DeleteTest1()
        {
            var host = "localhost";
            var port = "6379";
            var prefix = "";
            var connectionInformation = new Kalfoni.Redis.ConnectionInformation(host, port, prefix);

            var redisValue = new RedisValue();
            var keyName = "StringSet_StringGetTest1";
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
            redisKey = keyName;

            var result = Kalfoni.Redis.General.StringSet(connectionInformation, redisValue, redisKey, 1);
            Assert.True(result);

            var result2 = Kalfoni.Redis.General.StringGet(connectionInformation, redisKey);
            Assert.Equal(json, result2);

            var result3 = Kalfoni.Redis.General.Delete(connectionInformation, redisKey);
            Assert.True(result3);
        }
        
        [Fact]
        public void StringSet_ExceptionTest1()
        {
            var host = "wronghost";
            var port = "6379";
            var prefix = "";
            var connectionInformation = new Kalfoni.Redis.ConnectionInformation(host, port, prefix);

            var redisValue = new RedisValue();
            var keyName = "StringSet_StringGetTest1";
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
            redisKey = keyName;

            Assert.Throws<Exception>(() => Kalfoni.Redis.General.StringSet(connectionInformation, redisValue, redisKey, 1));
        }
        [Fact]
        public void StringSet_ExceptionTest2()
        {
            var host = "wronghost";
            var port = "6379";
            var prefix = "";
            var connectionInformation = new Kalfoni.Redis.ConnectionInformation(host, port, prefix);
            var keyName = "StringSet_StringGetTest2";



            string json = @"{
                            'Name': 'Bad Boys',
                            'ReleaseDate': '1995-4-7T00:00:00',
                            'Genres': [
                                'Action',
                                'Comedy'
                                 ]
                           }";

            Assert.Throws<Exception>(() => Kalfoni.Redis.General.StringSet(connectionInformation, json, keyName, 1));
        }

        [Fact]
        public void StringSet_ExceptionTest3()
        {
            var host = "wronghost";
            var port = "6379";
            var prefix = "";
            var connectionInformation = new Kalfoni.Redis.ConnectionInformation(host, port, prefix);
            var keyName = "StringSet_StringGetTest2";

            Assert.Throws<Exception>(() => Kalfoni.Redis.General.StringGet(connectionInformation, keyName));            
        }


        [Fact]
        public void StringSet_ExceptionTest4()
        {
            var host = "wronghost";
            var port = "6379";
            var prefix = "";
            var connectionInformation = new Kalfoni.Redis.ConnectionInformation(host, port, prefix);

            var redisValue = new RedisValue();
            var keyName = "StringSet_StringGetTest1";
            var redisKey = new RedisKey();

            Assert.Throws<Exception>(() => Kalfoni.Redis.General.StringGet(connectionInformation, redisKey));
        }
    }
}