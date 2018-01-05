using Server.Extension;
using Server.Model;
using Server.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Server.BLL
{
    public class clsFunction<T> where T : class, new()
    {
        #region Variables
        protected static aModel db;
        #endregion

        #region Contructor
        protected clsFunction() { }
        public static clsFunction<T> Instance
        {
            get { return new clsFunction<T>(); }
        }
        #endregion

        #region Method
        public virtual async Task<String> GetCode(String Prefix)
        {
            String bRe = Prefix.ToUpper() + DateTime.Now.ToString("yyyyMMdd");

            try
            {
                DateTime time = DateTime.Now;

                db = new aModel();
                IEnumerable<T> lstTemp = await db.Set<T>().ToListAsync();
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
                return bRe;
            }
            catch (Exception ex) { return bRe += "0001"; }
        }

        public virtual async Task<List<T>> GetAll()
        {
            try
            {
                db = new aModel();
                IEnumerable<T> lstTemp = await db.Set<T>().ToListAsync();
                //IList<T> lstResult = lstTemp.OrderBy<T, String>("Ten").ToList();
                List<T> lstResult = lstTemp.ToList();
                return lstResult;
            }
            catch (Exception ex) { return new List<T>(); }
        }

        public virtual async Task<T> GetByID(Object id)
        {
            try
            {
                db = new aModel();
                //T item = await db.Set<T>().FindAsync(id.ConvertType<T>());
                T Item = await db.Set<T>().FindAsync(id);
                return Item ?? new T();
            }
            catch (Exception ex) { return new T(); }
        }

        public virtual async Task<Exception> AddEntry(T Item)
        {
            try
            {
                db = new aModel();
                db.BeginTransaction();
                db.Set<T>().AddOrUpdate(Item);
                await db.SaveChangesAsync();
                db.CommitTransaction();
                return null;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return ex;
            }
        }

        public virtual async Task<Exception> AddEntries(T[] Items)
        {
            try
            {
                db = new aModel();
                Items = Items ?? new T[] { };
                db.BeginTransaction();
                db.Set<T>().AddOrUpdate(Items);
                await db.SaveChangesAsync();
                db.CommitTransaction();
                return null;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return ex;
            }
        }

        public virtual async Task<Exception> UpdateEntry(T Item)
        {
            try
            {
                db = new aModel();
                db.BeginTransaction();
                db.Set<T>().AddOrUpdate(Item);
                await db.SaveChangesAsync();
                db.CommitTransaction();
                return null;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return ex;
            }
        }

        public virtual async Task<Exception> UpdateEntries(T[] Items)
        {
            try
            {
                db = new aModel();
                Items = Items ?? new T[] { };
                db.BeginTransaction();
                db.Set<T>().AddOrUpdate(Items);
                await db.SaveChangesAsync();
                db.CommitTransaction();
                return null;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return ex;
            }
        }

        public virtual async Task<Exception> DeleteEntry(Object id)
        {
            try
            {
                db = new aModel();
                db.BeginTransaction();
                T Item = await db.Set<T>().FindAsync(id);
                db.Set<T>().Remove(Item);
                await db.SaveChangesAsync();
                db.CommitTransaction();
                return null;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return ex;
            }
        }

        public virtual async Task<Exception> DeleteEntry(T Item)
        {
            try
            {
                db = new aModel();
                db.BeginTransaction();
                db.Set<T>().Attach(Item);
                db.Set<T>().Remove(Item);
                await db.SaveChangesAsync();
                db.CommitTransaction();
                return null;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return ex;
            }
        }

        public virtual async Task<Exception> DeleteEntries(Object[] ids)
        {
            try
            {
                db = new aModel();
                ids = ids ?? new object[] { };
                db.BeginTransaction();
                foreach (object id in ids)
                {
                    T Item = await db.Set<T>().FindAsync(id);
                    db.Set<T>().Remove(Item);
                }
                await db.SaveChangesAsync();
                db.CommitTransaction();
                return null;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return ex;
            }
        }

        public virtual async Task<Exception> DeleteEntries(T[] Items)
        {
            try
            {
                db = new aModel();
                Items = Items ?? new T[] { };
                db.BeginTransaction();
                foreach (T Item in Items)
                {
                    db.Set<T>().Attach(Item);
                    db.Set<T>().Remove(Item);
                }
                await db.SaveChangesAsync();
                db.CommitTransaction();
                return null;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return ex;
            }
        }
        #endregion
    }
}