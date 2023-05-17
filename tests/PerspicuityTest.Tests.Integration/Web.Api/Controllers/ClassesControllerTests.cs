using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using PerspicuityTest.Core.Dtos;
using PerspicuityTest.Tests.Integration.Database._TestUtils_;
using PerspicuityTest.Tests.Integration.Web.Api._TestUtils_;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace PerspicuityTest.Tests.Integration.Web.Api.Controllers
{
    public class ClassesControllerTests : IClassFixture<TestPerspicuityTestWebApi>
    {
        private readonly HttpClient _client;

        public ClassesControllerTests(TestPerspicuityTestWebApi factory)
        {
            DatabaseTestUtils.ResetDatabase().Wait();
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Post_creates_a_new_Class()
        {
            var newClass = new Class(null, "Name", DateTime.Now, DateTime.Now.AddHours(1));
            var response = await _client.PostAsJsonAsync("/api/classes", newClass);

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var serialisedData = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Class>(serialisedData);

            Assert.NotNull(data);
            Assert.Equal(data.Name, newClass.Name);
            Assert.Equal(data.Start, newClass.Start);
            Assert.Equal(data.End, newClass.End);
            Assert.NotNull(data.Id);
        }

        [Fact]
        public async Task Get_returns_all_classes()
        {
            var class1 = new Class(null, "Class1", new DateTime(2023, 5, 17, 9, 0, 0), new DateTime(2023, 5, 17, 10, 0, 0));
            var class2 = new Class(null, "Class2", new DateTime(2023, 5, 20, 11, 0, 0), new DateTime(2023, 5, 20, 12, 0, 0));

            await _client.PostAsJsonAsync("/api/classes", class1);
            await _client.PostAsJsonAsync("/api/classes", class2);

            var classesResponse = await _client.GetFromJsonAsync<List<Class>>("/api/classes");

            Assert.NotNull(classesResponse);
            Assert.Equal(2, classesResponse.Count);

            var class1Response = classesResponse.Single(c => c.Name == class1.Name);
            Assert.Equal(class1Response.Name, class1.Name);
            Assert.Equal(class1Response.Start, class1.Start);
            Assert.Equal(class1Response.End, class1.End);
            Assert.NotNull(class1Response.Id);

            var class2Response = classesResponse.Single(c => c.Name == class2.Name);
            Assert.Equal(class2Response.Name, class2.Name);
            Assert.Equal(class2Response.Start, class2.Start);
            Assert.Equal(class2Response.End, class2.End);
            Assert.NotNull(class2Response.Id);
        }
    }
}
