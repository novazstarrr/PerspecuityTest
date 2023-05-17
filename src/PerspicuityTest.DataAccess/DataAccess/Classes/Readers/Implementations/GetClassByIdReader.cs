using Microsoft.EntityFrameworkCore;
using PerspicuityTest.Database;
using PerspicuityTest.Database.Models;

namespace PerspicuityTest.Core.DataAccess.Classes.Readers.Implementations
{
    internal class GetClassByIdReader : DataAccessBase, IGetClassByIdReader
    {
        public GetClassByIdReader(PerspicuityTestDbContext context) : base(context)
        {
        }

        public async Task<Class?> GetById(Guid classId)
        {
            return await Context.Classes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == classId);
        }
    }
}
