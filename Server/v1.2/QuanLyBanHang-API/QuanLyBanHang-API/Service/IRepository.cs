using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace QuanLyBanHang_API
{
    public interface IRepository
    {
        void BeginTransaction();
        Task<int> SaveChanges();
        void CommitTransaction();
        void RollbackTransaction();
    }
    public interface IRepositoryCollection
    {
        Repository GetRepository();
    }
}
