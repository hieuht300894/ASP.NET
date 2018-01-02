using Server.Attribute;
using Server.BLL;
using Server.Extension;
using Server.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [AllowJsonGet]
    [Route("[controller]")]
    public class BaseController<T> : CustomController where T : class, new()
    {
        [HttpGet()]
        [Route("GetCode/{Prefix}")]
        public virtual async Task<ActionResult> GetCode(String Prefix)
        {
            String Code = await clsFunction<T>.Instance.GetCode(Prefix);
            return Ok(Code);
        }

        [HttpGet()]
        [Route("GetAll")]
        public virtual async Task<ActionResult> GetAll()
        {
            IEnumerable<T> Items = await clsFunction<T>.Instance.GetAll();
            return Ok(Items);
        }

        [HttpGet()]
        [Route("GetByID/{id}")]
        public virtual async Task<ActionResult> GetByID(Int32 id)
        {
            T Item = await clsFunction<T>.Instance.GetByID(id);
            return Ok(Item);
        }

        [HttpPost()]   
        public virtual async Task<ActionResult> AddEntries(T[] Items)
        {
            Exception ex = await clsFunction<T>.Instance.AddEntries(Items);

            if (ex == null)
            {
                return Ok(Items);
            }
            else
            {
                ModelState.AddModelError("Exception_Message", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPut()]
        public virtual async Task<ActionResult> UpdateEntries(T[] Items)
        {
            Exception ex = await clsFunction<T>.Instance.UpdateEntries(Items);

            if (ex == null)
            {
                return Ok(Items);
            }
            else
            {
                ModelState.AddModelError("Exception_Message", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpDelete()]
        public virtual async Task<ActionResult> DeleteEntries(T[] Items)
        {
            Exception ex = await clsFunction<T>.Instance.DeleteEntries(Items);

            if (ex == null)
            {
                return NoContent();
            }
            else
            {
                ModelState.AddModelError("Exception_Message", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
