using PerspicuityTest.Database.Models;

namespace PerspicuityTest.Core.DataAccess.Classes.Writers
{
    public interface ICreateClassWriter
    {
        Task<Class> Create(Class newClass);
    }
}
