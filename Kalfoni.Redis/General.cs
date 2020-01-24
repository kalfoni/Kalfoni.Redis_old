using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kalfoni.Redis
{
    public static class General
    {
        private static TimeSpan ConvertTimeUnit(TimeUnit timeUnit, int value)
        {
            var result = new TimeSpan();
            switch (timeUnit)
            {
                case TimeUnit.Hours:
                    result = TimeSpan.FromHours(value);
                    break;
                case TimeUnit.Minutes:
                    result = TimeSpan.FromMinutes(value);
                    break;
                case TimeUnit.Seconds:
                    result = TimeSpan.FromSeconds(value);
                    break;
                case TimeUnit.Milliseconds:
                    result = TimeSpan.FromMilliseconds(value);
                    break;
            }
            return result;
        }



        public static Boolean StringSet(ConnectionInformation connectionInformation, RedisValue redisValue, RedisKey redisKey, int timeoutTime = 0, TimeUnit timeUnit = TimeUnit.Minutes)
        {
            var result = false;
            try
            {
                IDatabase db = connectionInformation.LazyConnection.Value.GetDatabase();
                db.StringSet(redisKey, redisValue, ConvertTimeUnit(timeUnit, timeoutTime));
                result = true;
            }
            catch (Exception e)
            {
                throw new Exception("Kalfoni.Redis: ", e);
            }
            return result;
        }

        public static Boolean StringSet(ConnectionInformation connectionInformation, string redisValue, string redisKey, int timeoutTime = 0, TimeUnit timeUnit = TimeUnit.Minutes)
        {
            var result = false;
            try
            {
                IDatabase db = connectionInformation.LazyConnection.Value.GetDatabase();
                db.StringSet(redisKey, redisValue, ConvertTimeUnit(timeUnit, timeoutTime));
                result = true;
            }
            catch (Exception e)
            {
                throw new Exception("Kalfoni.Redis: ", e);
            }
            return result;
        }

        public static async Task<Boolean> StringSetAsync(ConnectionInformation connectionInformation, RedisValue redisValue, RedisKey redisKey, int timeoutTime = 0, TimeUnit timeUnit = TimeUnit.Minutes)
        {
            var result = false;
            try
            {
                IDatabase db = connectionInformation.LazyConnection.Value.GetDatabase();
                await db.StringSetAsync(redisKey, redisValue, ConvertTimeUnit(timeUnit, timeoutTime));
                result = true;
            }
            catch (Exception e)
            {
                throw new Exception("Kalfoni.Redis: ", e);
            }
            return result;
        }

        public static RedisValue StringGet(ConnectionInformation connectionInformation, RedisKey redisKey)
        {
            var redisValue = new RedisValue();
            try
            {
                IDatabase db = connectionInformation.LazyConnection.Value.GetDatabase();
                redisValue = db.StringGet(redisKey);
            }
            catch (Exception e)
            {
                throw new Exception("Kalfoni.Redis: ", e);
            }
            return redisValue;
        }
        public static RedisValue StringGet(ConnectionInformation connectionInformation, string redisKey)
        {
            var redisValue = new RedisValue();
            try
            {
                IDatabase db = connectionInformation.LazyConnection.Value.GetDatabase();
                redisValue = db.StringGet(redisKey);
            }
            catch (Exception e)
            {
                throw new Exception("Kalfoni.Redis: ", e);
            }
            return redisValue;
        }

        public static async Task<RedisValue> StringGetAsync(ConnectionInformation connectionInformation, RedisKey redisKey)
        {
            var redisValue = new RedisValue();
            try
            {
                IDatabase db = connectionInformation.LazyConnection.Value.GetDatabase();
                redisValue = await db.StringGetAsync(redisKey);
            }
            catch (Exception e)
            {
                throw new Exception("Kalfoni.Redis: ", e);
            }
            return redisValue;
        }

        public static Boolean Delete(ConnectionInformation connectionInformation, string redisKey)
        {
            var result = false;
            try
            {
                IDatabase db = connectionInformation.LazyConnection.Value.GetDatabase();
                db.KeyDelete(redisKey);
                result = true;
            }
            catch (Exception e)
            {
                throw new Exception("Kalfoni.Redis: ", e);
            }
            return result;
        }

        public static async Task<bool> DeleteAsync(ConnectionInformation connectionInformation, string redisKey)
        {
            var result = false;
            try
            {
                IDatabase db = connectionInformation.LazyConnection.Value.GetDatabase();
                await db.KeyDeleteAsync(redisKey);
                result = true;
            }
            catch (Exception e)
            {
                throw new Exception("Kalfoni.Redis: ", e);
            }
            return result;
        }

        public static async Task<Boolean> FireandForgetAsync(ConnectionInformation connectionInformation, RedisValue redisValue, RedisKey redisKey, int timeoutTime = 0, TimeUnit timeUnit = TimeUnit.Minutes)
        {
            var result = false;
            try
            {
                IDatabase db = connectionInformation.LazyConnection.Value.GetDatabase();
                await db.StringSetAsync(redisKey, redisValue, ConvertTimeUnit(timeUnit, timeoutTime), When.Always, CommandFlags.FireAndForget);
                result = true;
            }
            catch (Exception e)
            {
                throw new Exception("Kalfoni.Redis: ", e);
            }
            return result;
        }

        public enum TimeUnit
        {
            Minutes,
            Seconds,
            Milliseconds,
            Hours
        }

    }
}
