using System.Net;
using ApiApplication;
using ApiApplication.Model;
namespace TestProject1
{
    public class Tests
    {
        private const string apiUrl = "https://jsonplaceholder.typicode.com";
        private const string endPoint = "users";
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Program obj = new Program();
            var result = obj.runner();
            Assert.AreEqual(2, result.Result[0].Id,"Id is not matching");
        }
        
        [Test]
        public void TestSingleModel()
        {
            Program obj = new Program();
            var result = obj.getUserById(1);
            Assert.AreEqual("Leanne Graham", result.Result.Name,"Name is not matching");
        }
    }
}