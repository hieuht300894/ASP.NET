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
        public virtual ActionResult GetCode(String Prefix)
        {
            return Ok(clsFunction<T>.Instance.GetCode(Prefix));
        }

        [HttpGet()]
        [Route("GetAll")]
        public virtual ActionResult GetAll()
        {
            return Ok(clsFunction<T>.Instance.GetAll());
        }

        [HttpGet()]
        [Route("GetByID/{id}")]
        public virtual ActionResult GetByID(Int32 id)
        {
            return Ok(clsFunction<T>.Instance.GetByID(id));
        }

        [HttpPost()]
        public virtual ActionResult AddEntries(T[] Items)
        {
            Exception ex = clsFunction<T>.Instance.AddEntries(Items);

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
        public virtual ActionResult UpdateEntries(T[] Items)
        {
            Exception ex = clsFunction<T>.Instance.UpdateEntries(Items);

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
        public virtual ActionResult DeleteEntries(T[] Items)
        {
            Exception ex = clsFunction<T>.Instance.DeleteEntries(Items);

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
