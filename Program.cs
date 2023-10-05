using MongoDB.Driver;
using MongoDB.Bson;

string connString = "mongodb://localhost";

MongoClient cli = new MongoClient(connString);

// testdb 라는 데이터 베이스 가져오기
var testdb = cli.GetDatabase("testdb");

var customers = testdb.GetCollection<Customer>("Customers");

Customer cust1 = new Customer { Name = "Kim", Age = 30 };
customers.InsertOne(cust1);
ObjectId id = cust1.Id;

// Select - ID 로 검색
var result = customers.Find( x => x.Id == id).FirstOrDefault();

if(result is not null)
{
    Console.WriteLine(result.ToString());
}

class Customer
{
    public ObjectId Id { get; set; }
    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public override string ToString()
    {
        return Name + " " + Age;
    }
}