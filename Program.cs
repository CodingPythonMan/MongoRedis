using MongoDB.Bson;
using TextQuest.Model;
using TextQuest.Service;

UserService userService = new UserService();
CacheService cacheService = CacheService.Instance;

User me = new User { Name = "Kim", Age = 20 };
userService.AddUser(me);

ObjectId id = me.Id;
// Select - ID 로 검색
var result = userService.FindById(id);

// 최신 검색한 id 를 저장 후, 해당 값 찾아오기
//var latestSearchUser = cacheService.LatestUser();

if(result is not null)
{
    Console.WriteLine(result.ToString());
}