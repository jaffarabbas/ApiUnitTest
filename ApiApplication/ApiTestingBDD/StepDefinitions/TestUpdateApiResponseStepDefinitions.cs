using ApiApplication.Model;
using System;
using TechTalk.SpecFlow;

namespace ApiTestingBDD.StepDefinitions
{
    [Binding]
    public class TestUpdateApiResponseStepDefinitions
    {
        private string apiUrl;
        private string endPoint;
        ApiHandler<User> apiHandler;
        private int saveId;
        User result;
        private User userDataForPost = new User()
        {
            Id = 5,
            Email = "abb@test.com",
            Name = "Jaffar"
        };

        [Given(@"I have api url and end points\.")]
        public void GivenIHaveApiUrlAndEndPoints_()
        {
            apiUrl = "https://localhost:7295/api";
            endPoint = "user";
        }

        [When(@"i call user from api and save it into the variable\.")]
        public async Task WhenICallUserFromApiAndSaveItIntoTheVariable_()
        {
            apiHandler = new ApiHandler<User>(apiUrl, endPoint);
            var response = await apiHandler.GetByIdAsync(userDataForPost.Id);
            saveId = response.Id;
        }

        [Then(@"i override the data i want to update\.")]
        public async Task ThenIOverrideTheDataIWantToUpdate_()
        {
            var r = new User()
            {
                Id = saveId,
                Name = userDataForPost.Name,
                Email = userDataForPost.Email,
            };

            await apiHandler.UpdateAsync(saveId,r);
        }

        [Then(@"i compare the data\.")]
        public async Task ThenICompareTheData_()
        {
            apiHandler = new ApiHandler<User>(apiUrl, endPoint);
            var response = await apiHandler.GetByIdAsync(saveId);
            Assert.AreEqual("Jaffar", response.Name.ToString());
        }
    }
}
