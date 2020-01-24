using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;

namespace Kalfoni.Redis
{
    public class Stack : Stack_Queue_Common
    {
        public static Boolean Push(ConnectionInformation connectionInformation, RedisValue redisValue, RedisKey stackName)
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

        public static RedisValue Pop(ConnectionInformation connectionInformation, RedisKey stackName)
        {
            var result = new RedisValue();
            try
            {
                result = connectionInformation.LazyConnection.Value.GetDatabase().ListRightPop(stackName);
            }
            catch (Exception e)
            {
                throw new Exception("Kalfoni.Redis: ", e);
            }
            return result;
        }

        public static Boolean Push(ConnectionInformation connectionInformation, string redisValue, string stackName)
        {
            var tempValue = new RedisValue();
            tempValue = redisValue;
            var tempStackName = new RedisKey();
            tempStackName = stackName;
            return Push(connectionInformation, tempValue, tempStackName);
        }

        public static string Pop(ConnectionInformation connectionInformation, string stackName)
        {
            var tempStackName = new RedisKey();
            tempStackName = stackName;
            return Pop(connectionInformation, tempStackName);
        }

    }
}
