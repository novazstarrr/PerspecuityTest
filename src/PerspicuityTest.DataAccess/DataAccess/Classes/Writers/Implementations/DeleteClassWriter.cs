using Microsoft.EntityFrameworkCore;
using PerspicuityTest.Database;

namespace PerspicuityTest.Core.DataAccess.Classes.Writers.Implementations
{
    internal class DeleteClassWriter : DataAccessBase, IDeleteClassWriter
    {
        public DeleteClassWriter(PerspicuityTestDbContext context) : base(context)
        {
        }

        public async Task<bool> Delete(Guid classId)
        {
            var @class = await Context.Classes.FirstOrDefaultAsync(c => c.Id == classId);
            if (@class == null) return false;

            Context.Classes.Remove(@class);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
