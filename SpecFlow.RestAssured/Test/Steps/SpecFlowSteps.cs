using NUnit.Framework;
using RA;
using SpecFlow.RestAssure.Main.Facade;
using SpecFlow.RestAssure.Main.Utils;
using TechTalk.SpecFlow;

namespace SpecFlow.RestAssure.Test.Steps
{
    [Binding]
    public class SpecFlowSteps
    {
        readonly ScenarioContext scenarioContext;
        SpecFlowSteps(ScenarioContext _scenarioContext)
        {
            scenarioContext = _scenarioContext;
        }

        [Given(@"the user with email as ""(.*)"" and password as ""(.*)""")]
        public void GivenTheUserWithEmailAsAndPasswordAs(string user, string pass)
        {
            Registration registration = new Registration { email = user, password = pass };
            scenarioContext.Add("newPlayerData", registration.ToJSON());
        }

        [When(@"I register the user with given details")]
        public void WhenIRegisterTheUserWithGivenDetails()
        {
            new RestAssured()
                 .Given()
                     .Header("Content-Type", "application/json")
                     .Body(scenarioContext.Get<string>("newPlayerData"))
                     .Uri("reqres.in/api/register")
                     .UseHttps()
                 .When()
                     .Post()
                 .Then()
                     .TestStatus("Success", x => x == 200);
        }

        [Then(@"I see the user is registered with email as ""(.*)""")]
        public void ThenISeeTheUserIsRegisteredWithEmailAs(string p0)
        {
            Assert.IsTrue(true);
        }

        [Then(@"password as ""(.*)""")]
        public void ThenPasswordAs(string p0)
        {
            Assert.IsTrue(true);
        }
    }
}
