using QuanLyBanHang_API.Extension;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuanLyBanHang_API
{
    [Filter]
    public class BaseController<T> : ApiController where T : class, new()
    {
        protected Repository Instance;

        public BaseController(IRepositoryCollection Collection)
        {
            Instance = Collection.GetRepository();
        }

        [HttpGet]
        public virtual async Task<IHttpActionResult> GetCode(String Prefix)
        {
            String bRe = Prefix.ToUpper() + DateTime.Now.ToString("yyyyMMdd");
            DateTime time = DateTime.Now;
            try
            {
                Instance.Context = new aModel();
                IEnumerable<T> lstTemp = await Instance.Context.Set<T>().ToListAsync();
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

        [HttpGet]
        public virtual async Task<IHttpActionResult> GetAll()
        {
            try
            {
                Instance.Context = new aModel();
                IEnumerable<T> lstTemp = await Instance.Context.Set<T>().ToListAsync();
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

        [HttpGet]
        public virtual async Task<IHttpActionResult> GetByID(Int32? KeyID)
        {
            try
            {
                Instance.Context = new aModel();
                //T item = await Instance.Context.Set<T>().FindAsync(id.ConvertType<T>());
                T Item = await Instance.Context.Set<T>().FindAsync(KeyID.HasValue ? KeyID.Value : 0);
                return Ok(Item ?? new T());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public virtual async Task<IHttpActionResult> AddEntries(T[] Items)
        {
            try
            {
                Instance.Context = new aModel();
                Items = Items ?? new T[] { };
                Instance.BeginTransaction();
                Instance.Context.Set<T>().AddOrUpdate(Items);
                await Instance.Context.SaveChangesAsync();
                Instance.CommitTransaction();
                return Ok(Items);
            }
            catch (Exception ex)
            {
                Instance.RollbackTransaction();
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public virtual async Task<IHttpActionResult> UpdateEntries(T[] Items)
        {
            try
            {
                Instance.Context = new aModel();
                Items = Items ?? new T[] { };
                Instance.BeginTransaction();
                Instance.Context.Set<T>().AddOrUpdate(Items);
                await Instance.Context.SaveChangesAsync();
                Instance.CommitTransaction();
                return Ok(Items);
            }
            catch (Exception ex)
            {
                Instance.RollbackTransaction();
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        public virtual async Task<IHttpActionResult> DeleteEntries(T[] Items)
        {
            try
            {
                Instance.Context = new aModel();
                Items = Items ?? new T[] { };
                Instance.BeginTransaction();
                foreach (T Item in Items)
                {
                    Instance.Context.Set<T>().Attach(Item);
                    Instance.Context.Set<T>().Remove(Item);
                }
                await Instance.Context.SaveChangesAsync();
                Instance.CommitTransaction();
                return NotFound();
            }
            catch (Exception ex)
            {
                Instance.RollbackTransaction();
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }
    }
}
