using MongoDB.Bson;

namespace TextQuest.Model
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; } = null!;

        public int Age { get; set; }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
