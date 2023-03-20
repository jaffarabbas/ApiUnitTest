using ApiApplication.Model;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace ApiTestingBDD.StepDefinitions
{

    [Binding]
    public class TestApiSingleResponceStepDefinitions
    {
        private string apiUrl;
        private string endPoint;
        ApiHandler<User> apiHandler;
        User result;
        [Given(@"I have api url and end points")]
        public void GivenIHaveApiUrlAndEndPoints()
        {
            apiUrl = "https://jsonplaceholder.typicode.com";
            endPoint = "users";
        }

        [When(@"I call all user from api and save it into the variable")]
        public async Task WhenICallAllUserFromApiAndSaveItIntoTheVariable()
        {
            apiHandler = new ApiHandler<User>(apiUrl, endPoint);
            result = await apiHandler.GetByIdAsync(1);
        }

        [Then(@"i compare user name with user object name")]
        public void ThenICompareUserNameWithUserObjectName()
        {
            Assert.AreEqual("Leanne Graham", result.Name);
        }
    }
}
