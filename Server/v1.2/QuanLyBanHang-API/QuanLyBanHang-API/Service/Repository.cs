using QuanLyBanHang_API.Extension;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace QuanLyBanHang_API
{
    public class Repository :  IRepository
    {
        public aModel Context { get; set; }

        public Repository(aModel db)
        {
            Context = db;
        }

        public void BeginTransaction()
        {
            Context.Database.BeginTransaction();
        }

        public async Task<int> SaveChanges()
        {
            return await Context.SaveChangesAsync();
        }

        public void CommitTransaction()
        {
            if (Context.Database.CurrentTransaction != null)
                Context.Database.CurrentTransaction.Commit();
        }

        public void RollbackTransaction()
        {
            if (Context.Database.CurrentTransaction != null)
                Context.Database.CurrentTransaction.Rollback();
        }
    }

    public class RepositoryCollection : IRepositoryCollection
    {
        private aModel db;

        public RepositoryCollection(aModel db)
        {
            this.db = db;
        }

        public Repository GetRepository()
        {
            return new Repository(db);
        }
    }
}
