using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PerspicuityTest.Database.Utilities
{
    public static class DatabaseInstaller
    {
        public static void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PerspicuityTestDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Database")));

            var container = services.BuildServiceProvider();
            var dbContext = container.GetRequiredService<PerspicuityTestDbContext>();

            ApplyMigrations(dbContext);
        }

        private static void ApplyMigrations(PerspicuityTestDbContext dbContext)
        {
            dbContext.Database.Migrate();
        }
    }
}
