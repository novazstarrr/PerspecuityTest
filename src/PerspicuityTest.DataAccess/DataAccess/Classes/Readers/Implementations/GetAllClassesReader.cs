using Microsoft.EntityFrameworkCore;
using PerspicuityTest.Database;
using PerspicuityTest.Database.Models;

namespace PerspicuityTest.Core.DataAccess.Classes.Readers.Implementations
{
    internal class GetAllClassesReader : DataAccessBase, IGetAllClassesReader
    {
        public GetAllClassesReader(PerspicuityTestDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Class>> GetAll()
        {
            return await Context.Classes.AsNoTracking().OrderByDescending(c => c.Start).ToListAsync();
        }
    }
}
