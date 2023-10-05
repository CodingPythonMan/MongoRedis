using StackExchange.Redis;

namespace TextQuest.Service
{
    public sealed class CacheService
    {
        private static readonly CacheService instance = new CacheService();

        static CacheService()
        {

        }

        private CacheService()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            var db = redis.GetDatabase();
        }

        public static CacheService Instance
        {
            get { return instance; }
        }
    }
}
