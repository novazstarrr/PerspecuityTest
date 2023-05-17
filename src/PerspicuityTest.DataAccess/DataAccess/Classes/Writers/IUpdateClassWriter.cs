using PerspicuityTest.Database.Models;

namespace PerspicuityTest.Core.DataAccess.Classes.Writers
{
    public interface IUpdateClassWriter
    {
        Task<Class> Update(Class @class);
    }
}
