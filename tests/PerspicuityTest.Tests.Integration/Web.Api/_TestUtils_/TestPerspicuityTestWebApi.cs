using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace PerspicuityTest.Tests.Integration.Web.Api._TestUtils_
{
    public class TestPerspicuityTestWebApi : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((context, config) =>
            {
                var assembly = typeof(TestPerspicuityTestWebApi).Assembly;
                var basePath = Path.GetDirectoryName(assembly.Location);

                config.AddJsonFile(Path.Combine(basePath!, "Web.Api/appsettings.test.json"));
            });
        }
    }
}
