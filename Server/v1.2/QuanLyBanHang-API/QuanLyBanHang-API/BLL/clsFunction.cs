using Server.Extension;
using Server.Model;
using Server.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Server.BLL
{
    //public class clsFunction<T> where T : class, new()
    //{
    //    #region Variables
    //    protected static aModel db;
    //    #endregion

    //    #region Contructor
    //    private static clsFunction<T> _instance;
    //    private clsFunction() { }
    //    public static clsFunction<T> Instance
    //    {
    //        get
    //        {
    //            if (_instance == null)
    //                _instance = new clsFunction<T>();
    //            return _instance;
    //        }
    //    }
    //    #endregion

    //    #region Method
    //    public virtual async Task<String> GetCode(String Prefix)
    //    {
    //        String bRe = Prefix.ToUpper() + DateTime.Now.ToString("yyyyMMdd");

    //        try
    //        {
    //            DateTime time = DateTime.Now;

    //            db = new aModel();
    //            IEnumerable<T> lstTemp = await db.Set<T>().ToListAsync();
    //            T Item = lstTemp.OrderByDescending<T, Int32>("KeyID").FirstOrDefault();
    //            if (Item == null)
    //            {
    //                bRe += "0001";
    //            }
    //            else
    //            {
    //                String Code = Item.GetObjectByName<String>("Ma");
    //                if (Code.StartsWith(bRe))
    //                {
    //                    Int32 number = Int32.Parse(Code.Replace(bRe, String.Empty));
    //                    ++number;
    //                    bRe = String.Format("{0}{1:0000}", bRe, number);
    //                }
    //                else
    //                    bRe += "0001";
    //            }
    //            return bRe;
    //        }
    //        catch (Exception ex) { return bRe += "0001"; }
    //    }

    //    public virtual async Task<List<T>> GetAll()
    //    {
    //        try
    //        {
    //            db = new aModel();
    //            IEnumerable<T> lstTemp = await db.Set<T>().ToListAsync();
    //            //IList<T> lstResult = lstTemp.OrderBy<T, String>("Ten").ToList();
    //            List<T> lstResult = lstTemp.ToList();
    //            return lstResult;
    //        }
    //        catch (Exception ex) { return new List<T>(); }
    //    }

    //    public virtual async Task<T> GetByID(Object id)
    //    {
    //        try
    //        {
    //            db = new aModel();
    //            //T item = await db.Set<T>().FindAsync(id.ConvertType<T>());
    //            T Item = await db.Set<T>().FindAsync(id);
    //            return Item ?? new T();
    //        }
    //        catch (Exception ex) { return new T(); }
    //    }

    //    public virtual async Task<ActionResult> AddEntry(T Item)
    //    {
    //        try
    //        {
    //            db = new aModel();
    //            db.BeginTransaction();
    //            db.Set<T>().AddOrUpdate(Item);
    //            await db.SaveChangesAsync();
    //            db.CommitTransaction();
    //            return null;
    //        }
    //        catch (Exception ex)
    //        {
    //            db.RollbackTransaction();
    //            return ex;
    //        }
    //    }

    //    public virtual async Task<ActionResult> AddEntries(T[] Items)
    //    {
    //        try
    //        {
    //            db = new aModel();
    //            Items = Items ?? new T[] { };
    //            db.BeginTransaction();
    //            db.Set<T>().AddOrUpdate(Items);
    //            await db.SaveChangesAsync();
    //            db.CommitTransaction();
    //            return null;
    //        }
    //        catch (Exception ex)
    //        {
    //            db.RollbackTransaction();
    //            return ex;
    //        }
    //    }

    //    public virtual async Task<ActionResult> UpdateEntry(T Item)
    //    {
    //        try
    //        {
    //            db = new aModel();
    //            db.BeginTransaction();
    //            db.Set<T>().AddOrUpdate(Item);
    //            await db.SaveChangesAsync();
    //            db.CommitTransaction();
    //            return null;
    //        }
    //        catch (Exception ex)
    //        {
    //            db.RollbackTransaction();
    //            return ex;
    //        }
    //    }

    //    public virtual async Task<ActionResult> UpdateEntries(T[] Items)
    //    {
    //        try
    //        {
    //            db = new aModel();
    //            Items = Items ?? new T[] { };
    //            db.BeginTransaction();
    //            db.Set<T>().AddOrUpdate(Items);
    //            await db.SaveChangesAsync();
    //            db.CommitTransaction();
    //            return null;
    //        }
    //        catch (Exception ex)
    //        {
    //            db.RollbackTransaction();
    //            return ex;
    //        }
    //    }

    //    public virtual async Task<ActionResult> DeleteEntry(Object id)
    //    {
    //        try
    //        {
    //            db = new aModel();
    //            db.BeginTransaction();
    //            T Item = await db.Set<T>().FindAsync(id);
    //            db.Set<T>().Remove(Item);
    //            await db.SaveChangesAsync();
    //            db.CommitTransaction();
    //            return null;
    //        }
    //        catch (Exception ex)
    //        {
    //            db.RollbackTransaction();
    //            return ex;
    //        }
    //    }

    //    public virtual async Task<ActionResult> DeleteEntry(T Item)
    //    {
    //        try
    //        {
    //            db = new aModel();
    //            db.BeginTransaction();
    //            db.Set<T>().Attach(Item);
    //            db.Set<T>().Remove(Item);
    //            await db.SaveChangesAsync();
    //            db.CommitTransaction();
    //            return null;
    //        }
    //        catch (Exception ex)
    //        {
    //            db.RollbackTransaction();
    //            return ex;
    //        }
    //    }

    //    public virtual async Task<ActionResult> DeleteEntries(Object[] ids)
    //    {
    //        try
    //        {
    //            db = new aModel();
    //            ids = ids ?? new object[] { };
    //            db.BeginTransaction();
    //            foreach (object id in ids)
    //            {
    //                T Item = await db.Set<T>().FindAsync(id);
    //                db.Set<T>().Remove(Item);
    //            }
    //            await db.SaveChangesAsync();
    //            db.CommitTransaction();
    //            return null;
    //        }
    //        catch (Exception ex)
    //        {
    //            db.RollbackTransaction();
    //            return ex;
    //        }
    //    }

    //    public virtual async Task<ActionResult> DeleteEntries(T[] Items)
    //    {
    //        try
    //        {
    //            db = new aModel();
    //            Items = Items ?? new T[] { };
    //            db.BeginTransaction();
    //            foreach (T Item in Items)
    //            {
    //                db.Set<T>().Attach(Item);
    //                db.Set<T>().Remove(Item);
    //            }
    //            await db.SaveChangesAsync();
    //            db.CommitTransaction();
    //            return null;
    //        }
    //        catch (Exception ex)
    //        {
    //            db.RollbackTransaction();
    //            return ex;
    //        }
    //    }
    //    #endregion
    //}

    public class clsFunction<T> : IJsonResult where T : class, new()
    {
        #region JsonResult implement
        public JsonResult Ok()
        {
            return new CustomJsonResult(HttpStatusCode.OK);
        }
        public JsonResult BadRequest()
        {
            return new CustomJsonResult(HttpStatusCode.BadRequest);
        }
        public JsonResult NoContent()
        {
            return new CustomJsonResult(HttpStatusCode.NoContent);
        }

        public JsonResult Ok(String message)
        {
            return new CustomJsonResult(HttpStatusCode.OK, message);
        }
        public JsonResult BadRequest(String message)
        {
            return new CustomJsonResult(HttpStatusCode.BadRequest, message);
        }
        public JsonResult NoContent(String message)
        {
            return new CustomJsonResult(HttpStatusCode.NoContent, message);
        }

        public JsonResult Ok(Object obj)
        {
            return new CustomJsonResult(HttpStatusCode.OK, obj);
        }
        public JsonResult BadRequest(Object obj)
        {
            return new CustomJsonResult(HttpStatusCode.BadRequest, obj);
        }
        public JsonResult NoContent(Object obj)
        {
            return new CustomJsonResult(HttpStatusCode.NoContent, obj);
        }

        public JsonResult BadRequest(Exception exception)
        {
            ModelStateDictionary modelState = new ModelStateDictionary();
            modelState.AddModelError("Exception", exception);
            return new CustomJsonResult(HttpStatusCode.BadRequest, modelState);
        }
        #endregion

        #region Contructor
        private static clsFunction<T> _instance;
        protected clsFunction() { }
        public static clsFunction<T> Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new clsFunction<T>();
                return _instance;
            }
        }
        #endregion

        #region Method
        public virtual async Task<ActionResult> GetCode(String Prefix)
        {
            aModel db = new aModel();
            String bRe = Prefix.ToUpper() + DateTime.Now.ToString("yyyyMMdd");
            DateTime time = DateTime.Now;
            try
            {
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
                return Ok(bRe);
            }
            catch
            {
                return BadRequest(bRe += "0001");
            }
        }

        public virtual async Task<ActionResult> GetAll()
        {
            aModel db = new aModel();
            try
            {
                IEnumerable<T> lstTemp = await db.Set<T>().ToListAsync();
                //IList<T> lstResult = lstTemp.OrderBy<T, String>("Ten").ToList();
                List<T> lstResult = lstTemp.ToList();
                return Ok(lstResult);
            }
            catch
            {
                return BadRequest(new List<T>());
            }
        }

        public virtual async Task<ActionResult> GetByID(Object id)
        {
            aModel db = new aModel();
            try
            {
                //T item = await db.Set<T>().FindAsync(id.ConvertType<T>());
                T Item = await db.Set<T>().FindAsync(id);
                return Ok(Item ?? new T());
            }
            catch
            {
                return BadRequest(new T());
            }
        }

        public virtual async Task<ActionResult> AddEntry(T Item)
        {
            aModel db = new aModel();
            try
            {
                db.BeginTransaction();
                db.Set<T>().AddOrUpdate(Item);
                await db.SaveChangesAsync();
                db.CommitTransaction();
                return Ok(Item);
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return BadRequest(ex);
            }
        }

        public virtual async Task<ActionResult> AddEntries(T[] Items)
        {
            aModel db = new aModel();
            try
            {
                Items = Items ?? new T[] { };
                db.BeginTransaction();
                db.Set<T>().AddOrUpdate(Items);
                await db.SaveChangesAsync();
                db.CommitTransaction();
                return Ok(Items);
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return BadRequest(ex);
            }
        }

        public virtual async Task<ActionResult> UpdateEntry(T Item)
        {
            aModel db = new aModel();
            try
            {
                db.BeginTransaction();
                db.Set<T>().AddOrUpdate(Item);
                await db.SaveChangesAsync();
                db.CommitTransaction();
                return Ok(Item);
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return BadRequest(ex);
            }
        }

        public virtual async Task<ActionResult> UpdateEntries(T[] Items)
        {
            aModel db = new aModel();
            try
            {
                Items = Items ?? new T[] { };
                db.BeginTransaction();
                db.Set<T>().AddOrUpdate(Items);
                await db.SaveChangesAsync();
                db.CommitTransaction();
                return Ok(Items);
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return BadRequest(ex);
            }
        }

        public virtual async Task<ActionResult> DeleteEntry(Object id)
        {
            aModel db = new aModel();
            try
            {
                db.BeginTransaction();
                T Item = await db.Set<T>().FindAsync(id);
                db.Set<T>().Remove(Item);
                await db.SaveChangesAsync();
                db.CommitTransaction();
                return NoContent(id);
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return BadRequest(ex);
            }
        }

        public virtual async Task<ActionResult> DeleteEntry(T Item)
        {
            aModel db = new aModel();
            try
            {
                db.BeginTransaction();
                db.Set<T>().Attach(Item);
                db.Set<T>().Remove(Item);
                await db.SaveChangesAsync();
                db.CommitTransaction();
                return NoContent(Item);
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return BadRequest(ex);
            }
        }

        public virtual async Task<ActionResult> DeleteEntries(Object[] ids)
        {
            aModel db = new aModel();
            try
            {
                ids = ids ?? new object[] { };
                db.BeginTransaction();
                foreach (object id in ids)
                {
                    T Item = await db.Set<T>().FindAsync(id);
                    db.Set<T>().Remove(Item);
                }
                await db.SaveChangesAsync();
                db.CommitTransaction();
                return NoContent(ids);
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return BadRequest(ex);
            }
        }

        public virtual async Task<ActionResult> DeleteEntries(T[] Items)
        {
            aModel db = new aModel();
            try
            {
                Items = Items ?? new T[] { };
                db.BeginTransaction();
                foreach (T Item in Items)
                {
                    db.Set<T>().Attach(Item);
                    db.Set<T>().Remove(Item);
                }
                await db.SaveChangesAsync();
                db.CommitTransaction();
                return NoContent(Items);
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return BadRequest(ex);
            }
        }
        #endregion
    }
}