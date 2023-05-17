namespace PerspicuityTest.Core.DataAccess.Classes.Writers
{
    public interface IDeleteClassWriter
    {
        Task<bool> Delete(Guid classId);
    }
}
