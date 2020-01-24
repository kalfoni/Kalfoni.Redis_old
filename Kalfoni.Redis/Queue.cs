using StackExchange.Redis;
using System;

namespace Kalfoni.Redis
{
    public class Queue : Stack_Queue_Common
    {
        public static Boolean Enqueue(ConnectionInformation connectionInformation, RedisValue redisValue, RedisKey stackName)
        {
            var result = false;
            try
            {
                connectionInformation.LazyConnection.Value.GetDatabase().ListRightPush(stackName, redisValue);
                result = true;
            }
            catch (Exception e)
            {
                throw new Exception("Kalfoni.Redis: ", e);
            }
            return result;
        }

        public static RedisValue Dequeue(ConnectionInformation connectionInformation, RedisKey stackName)
        {
            var result = new RedisValue();
            try
            {
                result = connectionInformation.LazyConnection.Value.GetDatabase().ListLeftPop(stackName);
            }
            catch (Exception e)
            {
                throw new Exception("Kalfoni.Redis: ", e);
            }
            return result;
        }

        public static Boolean Enqueue(ConnectionInformation connectionInformation, string redisValue, string stackName)
        {
            var tempValue = new RedisValue();
            tempValue = redisValue;
            var tempStackName = new RedisKey();
            tempStackName = stackName;
            return Enqueue(connectionInformation, tempValue, tempStackName);
        }

        public static string Dequeue(ConnectionInformation connectionInformation, string stackName)
        {
            var tempStackName = new RedisKey();
            tempStackName = stackName;
            return Dequeue(connectionInformation, tempStackName);
        }
    }
}
