namespace MP.ApiDotNet6.Domain.Repositories
{
    public interface IUnityOfWork : IDisposable
    {
        Task BeginTransaction();
        Task Commit();
        Task Rollback();
    }
}
