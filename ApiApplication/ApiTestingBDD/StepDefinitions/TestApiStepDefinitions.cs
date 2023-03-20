using ApiApplication.Model;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;

namespace ApiTestingBDD.StepDefinitions
{
    [Binding]
    public class TestApiStepDefinitions
    {
        private string apiUrl;
        private string endPoint;
        ApiHandler<User> apiHandler;
        List<User> resultList;
        [Given(@"I have api url and end point")]
        public void GivenIHaveApiUrlAndEndPoint()
        {
            apiUrl = "https://jsonplaceholder.typicode.com";
            endPoint = "users";
        }

        [When(@"I call all user from api and save it into the list")]
        public async Task WhenICallAllUserFromApiAndSaveItIntoTheList()
        {
            apiHandler = new ApiHandler<User>(apiUrl, endPoint);
            resultList = await apiHandler.GetAllAsync();
        }

        [Then(@"i compare first user name with list first user object")]
        public void ThenICompareFirstUserNameWithListFirstUserObject()
        {
            Assert.AreEqual("Leanne Graham", resultList[0].Name);
        }
    }
}
