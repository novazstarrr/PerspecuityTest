using PerspicuityTest.Database.Models;

namespace PerspicuityTest.Core.DataAccess.Classes.Readers
{
    public interface IGetClassByIdReader
    {
        Task<Class?> GetById(Guid classId);
    }
}
