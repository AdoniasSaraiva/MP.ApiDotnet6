using Microsoft.EntityFrameworkCore.Storage;
using MP.ApiDotnet6.Infra.Data.Context;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotnet6.Infra.Data.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly ApplicationContextDb _db;
        private IDbContextTransaction _transaction;

        public UnityOfWork(ApplicationContextDb db)
        {
            _db= db;
        }

        public async Task BeginTransaction()
        {
            _transaction = await _db.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _db.Database.CommitTransactionAsync();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
        }

        public async Task Rollback()
        {
            await _db.Database.RollbackTransactionAsync();
        }
    }
}
