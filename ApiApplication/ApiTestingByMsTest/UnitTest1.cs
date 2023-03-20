using ApiApplication.Model;

namespace ApiTestingByMsTest;

//in ms test we are directly testing api handler responses
[TestClass]
public class ApiTesting
{
    private const string apiUrl = "https://jsonplaceholder.typicode.com";
    private const string endPoint = "users";
    [TestMethod]
    public void TestingApiList()
    {
        var apiHandler = new ApiHandler<User>(apiUrl, endPoint);
        var result = apiHandler.GetAllAsync();
        Assert.AreEqual(1,result.Result[0].Id);
    }
    [TestMethod]
    public async Task TestingSingleApiResponse()
    {
        var apiHandler = new ApiHandler<User>(apiUrl, endPoint);
        var result = apiHandler.GetByIdAsync(1);
        Assert.AreEqual(1,result.Result.Id);
    }
}