using ApiApplication.Model;
using System;
using TechTalk.SpecFlow;

namespace ApiTestingBDD.StepDefinitions
{
    [Binding]
    public class TestDeleteApiResponseStepDefinitions
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
            Name = "Jaffar"
        };
        [Given(@"i have api url and end points\.")]
        public void GivenIHaveApiUrlAndEndPoints_()
        {
            apiUrl = "https://localhost:7295/api";
            endPoint = "user";
        }

        [When(@"I call user from api and save it into the variable\.")]
        public async Task WhenICallUserFromApiAndSaveItIntoTheVariable_()
        {
            apiHandler = new ApiHandler<User>(apiUrl, endPoint);
            var response = await apiHandler.GetByIdAsync(userDataForPost.Id);
            saveId = response.Id;
        }

        [Then(@"i delete the data")]
        public async Task ThenIDeleteTheData()
        {
            apiHandler = new ApiHandler<User>(apiUrl, endPoint);
            await apiHandler.DeleteAsync(saveId);
        }

        [Then(@"Then i check the data by fetching\.")]
        public async Task ThenThenICheckTheDataByFetching_()
        {
            apiHandler = new ApiHandler<User>(apiUrl, endPoint);
            var response = await apiHandler.GetByIdAsync(saveId);
            if(response == null)
            {
                Assert.AreEqual("NULL", "NULL");
            }
        }
    }
}
