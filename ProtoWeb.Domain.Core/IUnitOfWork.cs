using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProtoWeb.Domain.Core
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
        Task CommitTransactionAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
        IDbContextTransaction BeginTransaction();
    }
}
