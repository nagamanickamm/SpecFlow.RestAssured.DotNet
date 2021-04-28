using System;
using System.Collections.Generic;
using NUnit.Framework;
using RA;
using SpecFlow.RestAssure.Main.Facade;
using SpecFlow.RestAssure.Main.Utils;

namespace TestProject.Units
{
    [TestFixture]
    class Unit
    {
        [Test]
        public void CreateJsonArray()
        {
            List<Registration> registrations =
                new List<Registration>
                {
                    new Registration{email="email@gmail.com", password = "Password1" }
                };

            String expectedJSON = "[{\"email\":\"email@gmail.com\",\"password\":\"Password1\"}]";
            Assert.AreEqual(expectedJSON, registrations.ToJSON());
        }

        [Test]
        public void CreateJson()
        {
            Registration registrations =
                 new Registration { email = "email@gmail.com", password = "Password1" };
            String expectedJSON = "{\"email\":\"email@gmail.com\",\"password\":\"Password1\"}";
            Assert.AreEqual(expectedJSON, registrations.ToJSON());
        }

        [Test]
        public void postMethod()
        {
            Registration registrations =
                new Registration { email = "email@gmail.com", password = "Password1" };

            new RA.RestAssured()
                 .Given()
                     .Header("Content-Type", "application/json")
                     .Body(registrations.ToJSON())
                 .When()
                     .Post("https://reqres.in/api/register")
                 .Then()
                     .TestStatus("Success", x => x == 200);
        }
        [Test]
        public void getMethod()
        {
            Registration registrations =
                new Registration { email = "email@gmail.com", password = "Password1" };

            var id = new RestAssured()
                     .Given()
                         .Name("Retrieve an item in the document")
                     .When()
                         .Get("https://reqres.in/api/users/2")
                     .Then()
                         .Retrieve(x => x.data.id);

            Assert.AreEqual(2, id);
        }
    }
}
