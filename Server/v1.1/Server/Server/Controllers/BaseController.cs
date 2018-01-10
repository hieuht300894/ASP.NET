using Server.BLL;
using Server.Extension;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("[controller]")]
    public class BaseController<T> : CustomController where T : class, new()
    {
        [HttpGet]
        public virtual async Task<ActionResult> GetCode(String Prefix)
        {
            return await clsFunction<T>.Instance.GetCode(Prefix);
        }

        [HttpGet]
        public virtual async Task<ActionResult> GetAll()
        {
            return await clsFunction<T>.Instance.GetAll();
        }

        [HttpGet]
        public virtual async Task<ActionResult> GetByID(Int32? KeyID)
        {
            return await clsFunction<T>.Instance.GetByID(KeyID.HasValue ? KeyID.Value : 0);
        }

        [HttpPost]
        public virtual async Task<ActionResult> AddEntries(T[] Items)
        {
            return await clsFunction<T>.Instance.AddEntries(Items);
        }

        [HttpPut]
        public virtual async Task<ActionResult> UpdateEntries(T[] Items)
        {
            return await clsFunction<T>.Instance.UpdateEntries(Items);
        }

        [HttpDelete]
        public virtual async Task<ActionResult> DeleteEntries(T[] Items)
        {
            return await clsFunction<T>.Instance.DeleteEntries(Items);
        }
    }
}
