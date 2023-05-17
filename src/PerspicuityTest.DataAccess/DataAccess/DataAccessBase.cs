using PerspicuityTest.Database;

namespace PerspicuityTest.Core.DataAccess
{
    internal class DataAccessBase
    {
        protected internal PerspicuityTestDbContext Context { get; }

        public DataAccessBase(PerspicuityTestDbContext context)
        {
            Context = context;
        }
    }
}
