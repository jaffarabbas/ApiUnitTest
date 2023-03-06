using System.Net;
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
            //var apiHandler = new ApiHandler<>(apiUrl, endPoint);
            Assert.Pass();
        }
    }
}