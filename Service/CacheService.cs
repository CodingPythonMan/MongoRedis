using MongoDB.Bson;
using StackExchange.Redis;
using TextQuest.Model;

namespace TextQuest.Service
{
    public sealed class CacheService
    {
        private static readonly CacheService instance = new CacheService();
        private IDatabase _db;
        private ObjectId _latestObjectId;

        static CacheService()
        {

        }

        private CacheService()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            _db = redis.GetDatabase();
        }

        public static CacheService Instance
        {
            get { return instance; }
        }

        public void RegisterSearchUser(User user)
        {
            _latestObjectId = user.Id;
            _db.StringSet(_latestObjectId.ToString(), user.ToString());
        }

        public string LatestSearchUser()
        {
            return _db.StringGet(_latestObjectId.ToString())!;
        }
    }
}
