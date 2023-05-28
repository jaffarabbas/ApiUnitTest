using ApiApplication.Model;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;

namespace ApiTestingBDD.StepDefinitions
{
    [Binding]
    public class TestApiPostResponseStepDefinitions
    {
        private string apiUrl;
        private string endPoint;
        ApiHandler<User> apiHandler;
        private int saveId;
        User result;
        private User userDataForPost = new User()
        {
            Id = 5,
            Email = "test@test.com",
            Name = "Jaffar Abbas"
        };

        [Given(@"i have api url and end point")]
        public void GivenIHaveApiUrlAndEndPoint()
        {
            apiUrl = "https://localhost:7295/api";
            endPoint = "user";
        }

        [When(@"I Post User in the api")]
        public async Task WhenIPostUserInTheApi()
        {
            apiHandler = new ApiHandler<User>(apiUrl, endPoint);
            var response = await apiHandler.CreateAsync(userDataForPost);
            saveId = response.Id;
        }

        [Then(@"I call that user by id")]
        public async Task ThenICallThatUserById()
        {
            apiHandler = new ApiHandler<User>(apiUrl, endPoint);
            var responce = await apiHandler.GetByIdAsync(saveId);
            if(responce != null)
            {
                result = responce;
            }
        }

        [Then(@"compare it responce")]
        public void ThenCompareItResponce()
        {
            Assert.AreEqual("Jaffar Abbas", result.Name.ToString());
        }
    }
}
