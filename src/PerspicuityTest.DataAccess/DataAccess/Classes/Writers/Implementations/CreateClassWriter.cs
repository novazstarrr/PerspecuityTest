using PerspicuityTest.Database;
using PerspicuityTest.Database.Models;

namespace PerspicuityTest.Core.DataAccess.Classes.Writers.Implementations
{
    internal class CreateClassWriter : DataAccessBase, ICreateClassWriter
    {
        public CreateClassWriter(PerspicuityTestDbContext context) : base(context)
        {
        }

        public async Task<Class> Create(Class newClass)
        {
            await Context.Classes.AddAsync(newClass);
            await Context.SaveChangesAsync();

            return newClass;
        }
    }
}
