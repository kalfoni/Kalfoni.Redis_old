using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kalfoni.Redis
{
    public class Stack_Queue_Common
    {
        public static RedisValue ListLength(ConnectionInformation connectionInformation, RedisKey stackName)
        {
            var result = new RedisValue();
            try
            {
                result = connectionInformation.LazyConnection.Value.GetDatabase().ListLength(stackName);
            }
            catch (Exception e)
            {
                throw new Exception("Kalfoni.Redis: ", e);
            }
            return result;
        }

        public static int ListLength(ConnectionInformation connectionInformation, String stackName)
        {
            var tempStackName = new RedisKey();
            tempStackName = stackName;
            return Convert.ToInt32(ListLength(connectionInformation, tempStackName).ToString());
        }
    }
}
