using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace QuanLyBanHang_API
{
    public interface IRepository<T> where T : class, new()
    {
        Task<IHttpActionResult> GetCode(String Prefix);
        Task<IHttpActionResult> GetAll();
        Task<IHttpActionResult> GetByID(object id);
        Task<IHttpActionResult> AddEntry(T item);
        Task<IHttpActionResult> AddEntries(T[] items);
        Task<IHttpActionResult> UpdateEntry(T item);
        Task<IHttpActionResult> UpdateEntries(T[] items);
        Task<IHttpActionResult> DeleteEntry(object id);
        Task<IHttpActionResult> DeleteEntry(T item);
        Task<IHttpActionResult> DeleteEntries(object[] ids);
        Task<IHttpActionResult> DeleteEntries(T[] items);
        void BeginTransaction();
        Task<int> SaveChanges();
        void CommitTransaction();
        void RollbackTransaction();
    }
    public interface IRepository
    {
        void BeginTransaction();
        Task<int> SaveChanges();
        void CommitTransaction();
        void RollbackTransaction();
    }
    public interface IRepositoryCollection
    {
        Repository<T> GetRepository<T>() where T : class, new();
        Repository GetRepository();
    }
}
