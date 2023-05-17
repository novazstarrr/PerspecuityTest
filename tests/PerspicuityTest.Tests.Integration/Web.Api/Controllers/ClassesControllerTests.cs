using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using PerspicuityTest.Core.Dtos;
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
    }
}
