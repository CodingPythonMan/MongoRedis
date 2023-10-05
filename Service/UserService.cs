using MongoDB.Bson;
using MongoDB.Driver;
using TextQuest.Model;

namespace TextQuest.Service
{
    public class UserService
    {
        private DBService _dbService;
        private IMongoDatabase? _db;
        private IMongoCollection<User>? _users;
        private CacheService _cache = null!;

        public UserService()
        {
            _dbService  = new DBService();
            _db = _dbService.GetDatabase("testdb");

            if (_db is null)
                return;

            _users = _db.GetCollection<User>("Users");
            _cache = CacheService.Instance;
        }

        public void AddUser(User user)
        {
            if (_users is null)
                return;

            _users.InsertOne(user);
        }

        public User FindById(ObjectId id)
        {
            var result = _users.Find(x => x.Id == id).FirstOrDefault();

            _cache.RegisterSearchUser(result);

            return result;
        }
    }
}
