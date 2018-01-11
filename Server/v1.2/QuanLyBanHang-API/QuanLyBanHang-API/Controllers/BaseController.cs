using System;
using System.Threading.Tasks;
using System.Web.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuanLyBanHang_API
{
    [Route("api/[controller]")]
    public class BaseController<T> : ApiController where T : class, new()
    {
        protected Repository<T> Instance;

        public BaseController(IRepositoryCollection Collection)
        {
            Instance = Collection.GetRepository<T>();
        }

        [HttpGet]
        public virtual async Task<IHttpActionResult> GetCode(String Prefix)
        {
            return await Instance.GetCode(Prefix);
        }

        [HttpGet]
        public virtual async Task<IHttpActionResult> GetAll()
        {
            return await Instance.GetAll();
        }

        [HttpGet]
        public virtual async Task<IHttpActionResult> GetByID(Int32? KeyID)
        {
            return await Instance.GetByID(KeyID.HasValue ? KeyID.Value : 0);
        }

        [HttpPost]
        public virtual async Task<IHttpActionResult> AddEntries(T[] Items)
        {
            return await Instance.AddEntries(Items);
        }

        [HttpPut]
        public virtual async Task<IHttpActionResult> UpdateEntries(T[] Items)
        {
            return await Instance.UpdateEntries(Items);
        }

        [HttpDelete]
        public virtual async Task<IHttpActionResult> DeleteEntries(T[] Items)
        {
            return await Instance.DeleteEntries(Items);
        }
    }
}
