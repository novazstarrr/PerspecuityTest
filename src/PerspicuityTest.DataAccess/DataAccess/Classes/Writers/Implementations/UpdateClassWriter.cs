using PerspicuityTest.Database;
using PerspicuityTest.Database.Models;

namespace PerspicuityTest.Core.DataAccess.Classes.Writers.Implementations
{
    internal class UpdateClassWriter : DataAccessBase, IUpdateClassWriter
    {
        public UpdateClassWriter(PerspicuityTestDbContext context) : base(context)
        {
        }

        public async Task<Class> Update(Class @class)
        {
            Context.Classes.Update(@class);
            await Context.SaveChangesAsync();

            return @class;
        }
    }
}
