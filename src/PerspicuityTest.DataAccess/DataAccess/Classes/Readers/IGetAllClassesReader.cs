using PerspicuityTest.Database.Models;

namespace PerspicuityTest.Core.DataAccess.Classes.Readers
{
    public interface IGetAllClassesReader
    {
        Task<IEnumerable<Class>> GetAll();
    }
}
