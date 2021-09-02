using ServiceStack.Redis;
using System;

namespace RedisAppDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var manager = new RedisManagerPool("localhost:6379");
            //using (var client = manager.GetClient())
            //{
            //    client.Set("foo", "bar");
            //    Console.WriteLine("foo={0}", client.Get<string>("foo"));
            //}

            SaveData("localhost:8001", "Testkey", "12345");
            string result = ReadData("s2-angstrom-redis.i3ry7r.0001.euw2.cache.amazonaws.com", "Testkey");
            Console.WriteLine("REDIS RESULT : " + result);
            Console.ReadKey();
        }

        private static void SaveData(string host, string key, string value)
        {
            using (RedisClient client = new RedisClient(host))
            {
                if (client.Get<string>(key) == null)
                {
                    client.Set(key, value);
                }
            }
        }

        private static string ReadData(string host, string key)
        {
            using (RedisClient client = new RedisClient(host))
            {
                return client.Get<string>(key);
            }
        }
    }
}