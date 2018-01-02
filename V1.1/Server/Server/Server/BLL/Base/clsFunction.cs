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
        public virtual String GetCode(String Prefix)
        {
            String bRe = Prefix + DateTime.Now.ToString("yyyyMMdd");

            try
            {
                DateTime time = DateTime.Now;

                IEnumerable<T> lstTemp = db.Set<T>().ToList();
                T Item = lstTemp.OrderByDescending<T, T>("KeyID").FirstOrDefault();
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
            catch { return bRe += "0001"; }
        }

        public virtual List<T> GetAll()
        {
            try
            {
                db = new aModel();
                IEnumerable<T> lstTemp = db.Set<T>().ToList();
                //IList<T> lstResult = lstTemp.OrderBy<T, String>("Ten").ToList();
                List<T> lstResult = lstTemp.ToList();
                return lstResult;
            }
            catch { return new List<T>(); }
        }

        public virtual T GetByID(Object id)
        {
            try
            {
                db = new aModel();
                //T item =  db.Set<T>().Find(id.ConvertType<T>());
                T Item = db.Set<T>().Find(id);
                return Item ?? new T();
            }
            catch { return new T(); }
        }

        public virtual Exception AddEntry(T Item)
        {
            try
            {
                db = new aModel();
                db.BeginTransaction();
                db.Set<T>().Add(Item);
                db.SaveChanges();
                db.CommitTransaction();
                return null;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return ex;
            }
        }

        public virtual Exception AddEntries(T[] Items)
        {
            try
            {
                db = new aModel();
                Items = Items ?? new T[] { };
                db.BeginTransaction();
                db.Set<T>().AddRange(Items);
                db.SaveChanges();
                db.CommitTransaction();
                return null;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return ex;
            }
        }

        public virtual Exception UpdateEntry(T Item)
        {
            try
            {
                db = new aModel();
                db.BeginTransaction();
                db.Set<T>().AddOrUpdate(Item);
                db.SaveChanges();
                db.CommitTransaction();
                return null;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return ex;
            }
        }

        public virtual Exception UpdateEntries(T[] Items)
        {
            try
            {
                db = new aModel();
                Items = Items ?? new T[] { };
                db.BeginTransaction();
                db.Set<T>().AddOrUpdate(Items);
                db.SaveChanges();
                db.CommitTransaction();
                return null;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return ex;
            }
        }

        public virtual Exception DeleteEntry(Object id)
        {
            try
            {
                db = new aModel();
                db.BeginTransaction();
                T Item = db.Set<T>().Find(id);
                db.Set<T>().Remove(Item);
                db.SaveChanges();
                db.CommitTransaction();
                return null;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return ex;
            }
        }

        public virtual Exception DeleteEntry(T Item)
        {
            try
            {
                db = new aModel();
                db.BeginTransaction();
                db.Set<T>().Attach(Item);
                db.Set<T>().Remove(Item);
                db.SaveChanges();
                db.CommitTransaction();
                return null;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return ex;
            }
        }

        public virtual Exception DeleteEntries(Object[] ids)
        {
            try
            {
                db = new aModel();
                ids = ids ?? new object[] { };
                db.BeginTransaction();
                foreach (object id in ids)
                {
                    T Item = db.Set<T>().Find(id);
                    db.Set<T>().Remove(Item);
                }
                db.SaveChanges();
                db.CommitTransaction();
                return null;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return ex;
            }
        }

        public virtual Exception DeleteEntries(T[] Items)
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
                db.SaveChanges();
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