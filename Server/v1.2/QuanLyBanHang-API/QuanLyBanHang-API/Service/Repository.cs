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
    public class Repository<T> : ApiController, IRepository<T> where T : class, new()
    {
        public aModel Context { get; set; }

        public Repository(aModel db)
        {
            Context = db;
        }

        public async Task<IHttpActionResult> GetCode(String Prefix)
        {
            String bRe = Prefix.ToUpper() + DateTime.Now.ToString("yyyyMMdd");
            DateTime time = DateTime.Now;
            try
            {
                Context = new aModel();
                IEnumerable<T> lstTemp = await Context.Set<T>().ToListAsync();
                T Item = lstTemp.OrderByDescending<T, Int32>("KeyID").FirstOrDefault();
                if (Item == null)
                {
                    bRe += "0001";
                }
                else
                {
                    String Code = Item.GetObjectByName<String>("Ma");
                    if (Code.StartsWith(bRe))
                    {
                        Int32 number = Int32.Parse(Code.Replace(bRe, String.Empty));
                        ++number;
                        bRe = String.Format("{0}{1:0000}", bRe, number);
                    }
                    else
                        bRe += "0001";
                }
                return Ok(bRe);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }

        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                Context = new aModel();
                IEnumerable<T> lstTemp = await Context.Set<T>().ToListAsync();
                //IList<T> lstResult = lstTemp.OrderBy<T, String>("Ten").ToList();
                List<T> lstResult = lstTemp.ToList();
                return Ok(lstResult);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }

        public async Task<IHttpActionResult> GetByID(Object id)
        {
            try
            {
                Context = new aModel();
                //T item = await Context.Set<T>().FindAsync(id.ConvertType<T>());
                T Item = await Context.Set<T>().FindAsync(id);
                return Ok(Item ?? new T());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }

        public async Task<IHttpActionResult> AddEntry(T Item)
        {
            try
            {
                Context = new aModel();
                BeginTransaction();
                Context.Set<T>().AddOrUpdate(Item);
                await SaveChanges();
                CommitTransaction();
                return Ok(Item);
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }

        public async Task<IHttpActionResult> AddEntries(T[] Items)
        {
            try
            {
                Context = new aModel();
                Items = Items ?? new T[] { };
                BeginTransaction();
                Context.Set<T>().AddOrUpdate(Items);
                await Context.SaveChangesAsync();
                CommitTransaction();
                return Ok(Items);
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }

        public async Task<IHttpActionResult> UpdateEntry(T Item)
        {
            try
            {
                Context = new aModel();
                BeginTransaction();
                Context.Set<T>().AddOrUpdate(Item);
                await Context.SaveChangesAsync();
                CommitTransaction();
                return Ok(Item);
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }

        public async Task<IHttpActionResult> UpdateEntries(T[] Items)
        {
            try
            {
                Context = new aModel();
                Items = Items ?? new T[] { };
                BeginTransaction();
                Context.Set<T>().AddOrUpdate(Items);
                await Context.SaveChangesAsync();
                CommitTransaction();
                return Ok(Items);
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }

        public async Task<IHttpActionResult> DeleteEntry(Object id)
        {
            try
            {
                Context = new aModel();
                BeginTransaction();
                T Item = await Context.Set<T>().FindAsync(id);
                Context.Set<T>().Remove(Item);
                await Context.SaveChangesAsync();
                CommitTransaction();
                return NotFound();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }

        public async Task<IHttpActionResult> DeleteEntry(T Item)
        {
            try
            {
                Context = new aModel();
                BeginTransaction();
                Context.Set<T>().Attach(Item);
                Context.Set<T>().Remove(Item);
                await Context.SaveChangesAsync();
                CommitTransaction();
                return NotFound();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }

        public async Task<IHttpActionResult> DeleteEntries(Object[] ids)
        {
            try
            {
                Context = new aModel();
                ids = ids ?? new object[] { };
                BeginTransaction();
                foreach (object id in ids)
                {
                    T Item = await Context.Set<T>().FindAsync(id);
                    Context.Set<T>().Remove(Item);
                }
                await Context.SaveChangesAsync();
                CommitTransaction();
                return NotFound();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }

        public async Task<IHttpActionResult> DeleteEntries(T[] Items)
        {
            try
            {
                Context = new aModel();
                Items = Items ?? new T[] { };
                BeginTransaction();
                foreach (T Item in Items)
                {
                    Context.Set<T>().Attach(Item);
                    Context.Set<T>().Remove(Item);
                }
                await Context.SaveChangesAsync();
                CommitTransaction();
                return NotFound();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
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

        public Repository<T> GetRepository<T>() where T : class, new()
        {
            return new Repository<T>(db);
        }

        public Repository GetRepository()
        {
            return new Repository(db);
        }
    }
}
