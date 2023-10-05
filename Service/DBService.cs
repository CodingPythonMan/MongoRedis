using MongoDB.Driver;

namespace TextQuest.Service
{
    public class DBService
    {
        MongoClient _cli = null!;

        public DBService()
        {
            string connString = "mongodb://localhost";

            _cli = new MongoClient(connString);
        }

        public IMongoDatabase? GetDatabase(string db)
        {
            var testdb = _cli.GetDatabase(db);

            return testdb;
        }
    }
}
