using Microsoft.EntityFrameworkCore;
using PerspicuityTest.Database.Models;

namespace PerspicuityTest.Database
{
    public class PerspicuityTestDbContext : DbContext
    {
        public PerspicuityTestDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Class> Classes { get; set; }
    }
}
