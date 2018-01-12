using EntityModel;
using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuanLyBanHang_API
{
    public class ModuleController : ApiController
    {
        protected Repository Instance;

        public ModuleController(IRepositoryCollection Collection)
        {
            Instance = Collection.GetRepository();
        }

        [HttpPost]
        public async Task<IHttpActionResult> DataSeed()
        {
            await InitAgency();
            await InitTienTe();
            await InitTinhThanh();
            await InitDonViTinh();
            await InitLoai();

            if (ModelState.Count == 0)
                return Ok("Success");
            return BadRequest(ModelState);
        }
        async Task InitAgency()
        {
            Instance.Context = new aModel();
            if (Instance.Context.xChiNhanh.Count() == 0)
            {
                try
                {
                    string Query = System.IO.File.ReadAllText($@"{HttpRuntime.AppDomainAppPath}\wwwroot\InitData\DATA_xChiNhanh.sql");
                    await Instance.Context.Database.ExecuteSqlCommandAsync(Query, new SqlParameter[] { });
                }
                catch (Exception ex) { ModelState.AddModelError("Exception", ex); }
            }
        }
        async Task InitTienTe()
        {
            Instance.Context = new aModel();

            if (Instance.Context.eTienTe.Count() == 0)
            {
                try
                {
                    string Query = System.IO.File.ReadAllText($@"{HttpRuntime.AppDomainAppPath}\wwwroot\InitData\DATA_eTienTe.sql");
                    await Instance.Context.Database.ExecuteSqlCommandAsync(Query, new SqlParameter[] { });
                }
                catch (Exception ex) { ModelState.AddModelError("Exception", ex); }
            }
        }
        async Task InitTinhThanh()
        {
            Instance.Context = new aModel();

            if (Instance.Context.eTinhThanh.Count() == 0)
            {
                try
                {
                    string Query = System.IO.File.ReadAllText($@"{HttpRuntime.AppDomainAppPath}\wwwroot\InitData\DATA_eTinhThanh.sql");
                    await Instance.Context.Database.ExecuteSqlCommandAsync(Query, new SqlParameter[] { });
                }
                catch (Exception ex) { ModelState.AddModelError("Exception", ex); }
            }
        }
        async Task InitDonViTinh()
        {
            Instance.Context = new aModel();

            if (Instance.Context.eDonViTinh.Count() == 0)
            {
                try
                {
                    string Query = System.IO.File.ReadAllText($@"{HttpRuntime.AppDomainAppPath}\wwwroot\InitData\DATA_eDonViTinh.sql");
                    await Instance.Context.Database.ExecuteSqlCommandAsync(Query, new SqlParameter[] { });
                }
                catch (Exception ex) { ModelState.AddModelError("Exception", ex); }
            }
        }
        async Task InitLoai()
        {
            Instance.Context = new aModel();

            if (Instance.Context.eLoai.Count() == 0)
            {
                try
                {
                    string Query = System.IO.File.ReadAllText($@"{HttpRuntime.AppDomainAppPath}\wwwroot\InitData\DATA_eLoai.sql");
                    await Instance.Context.Database.ExecuteSqlCommandAsync(Query, new SqlParameter[] { });
                }
                catch (Exception ex) { ModelState.AddModelError("Exception", ex); }
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> TimeServer()
        {
            Instance.Context = new aModel();

            try { return await Task.Factory.StartNew(() => { return Ok(DateTime.Now); }); }
            catch { return Ok(DateTime.Now); }

        }

        [HttpPost]
        public async Task<IHttpActionResult> InitUser()
        {
            Instance.Context = new aModel();
            DateTime time = DateTime.Now;

            try
            {
                Instance.BeginTransaction();

                xNhomQuyen nhomQuyen = new xNhomQuyen()
                {
                    KeyID = 0,
                    Ma = "ADMIN",
                    Ten = "ADMIN",
                    NgayTao = time
                };
                Instance.Context.xNhomQuyen.Add(nhomQuyen);
                await Instance.SaveChanges();

                xNhanVien nhanVien = new xNhanVien()
                {
                    KeyID = 0,
                    Ma = "NV0001",
                    Ten = "Nhân viên 0001",
                    NgayTao = time
                };
                Instance.Context.xNhanVien.Add(nhanVien);
                await Instance.SaveChanges();

                xTaiKhoan taiKhoan = new xTaiKhoan()
                {
                    KeyID = nhanVien.KeyID,
                    NgayTao = time,
                    MaNhanVien = nhanVien.Ma,
                    TenNhanVien = nhanVien.Ten,
                    Username = "admin",
                    Password = "admin",
                    IDNhomQuyen = nhomQuyen.KeyID,
                    MaNhomQuyen = nhomQuyen.Ma,
                    TenNhomQuyen = nhomQuyen.Ten
                };
                Instance.Context.xTaiKhoan.Add(taiKhoan);
                await Instance.SaveChanges();

                List<xQuyen> lstQuyens = await Instance.Context.xQuyen.ToListAsync();
                List<xPhanQuyen> lstPhanQuyens = new List<xPhanQuyen>();
                foreach (xQuyen quyen in lstQuyens)
                {
                    lstPhanQuyens.Add(new xPhanQuyen()
                    {
                        KeyID = 0,
                        IDNhomQuyen = nhomQuyen.KeyID,
                        MaNhomQuyen = nhomQuyen.Ma,
                        TenNhomQuyen = nhomQuyen.Ten,
                        IDQuyen = quyen.KeyID,
                        Controller = quyen.Controller,
                        Action = quyen.Action,
                        Method = quyen.Method,
                        Template = quyen.Template,
                        Path = quyen.Path,
                        NgayTao = time,
                        MacDinh = quyen.MacDinh
                    });
                }
                Instance.Context.xPhanQuyen.AddRange(lstPhanQuyens.ToArray());
                await Instance.SaveChanges();

                Instance.CommitTransaction();
                return Ok(lstPhanQuyens);
            }
            catch (Exception ex)
            {
                Instance.RollbackTransaction();
                ModelState.AddModelError("Exception", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> GetController()
        {
            List<xQuyen> lstQuyens = new List<xQuyen>();

            Assembly asm = Assembly.GetExecutingAssembly();

            var q1 = asm
                .GetExportedTypes()
                .Where(x => typeof(ApiController).IsAssignableFrom(x) && !x.Name.Equals(typeof(ApiController).Name))
                .Select(x => new
                {
                    Controller = x.Name,
                    Methods = x.GetMethods().Where(y => y.DeclaringType.IsSubclassOf(typeof(ApiController)) && y.IsPublic && !y.IsStatic).ToList()
                });

            var BaseController = q1
                .Where(x => x.Controller.Equals(typeof(BaseController<>).Name))
                .Select(x => new
                {
                    Controller = x.Controller.ToLower().Replace("controller", string.Empty),
                    Actions = x.Methods.Where(y => y.IsVirtual).Select(y => new { Action = y.Name.ToLower(), Attributes = y.GetCustomAttributes(false).ToList() })
                })
                .FirstOrDefault();

            var Controllers = q1
                .Where(x => !x.Controller.Equals(typeof(BaseController<>).Name))
                .Select(x => new
                {
                    Controller = x.Controller.ToLower().Replace("controller", string.Empty),
                    Actions = x.Methods.Where(y => !y.IsVirtual).Select(y => new { Action = y.Name.ToLower(), Attributes = y.GetCustomAttributes(false).ToList() })
                });

            DateTime time = DateTime.Now;

            if (BaseController != null)
            {
                foreach (var action in BaseController.Actions)
                {
                    xQuyen quyen = new xQuyen();

                    HttpGetAttribute attr_Get = (HttpGetAttribute)action.Attributes.FirstOrDefault(x => x.GetType() == typeof(HttpGetAttribute));
                    RouteAttribute attr_Route = (RouteAttribute)action.Attributes.FirstOrDefault(x => x.GetType() == typeof(RouteAttribute));
                    if (attr_Get != null && attr_Route != null)
                    {
                        quyen.Method = HttpMethod.Get.ToString().ToLower();
                        quyen.Template = string.IsNullOrWhiteSpace(attr_Route.Template) ? string.Empty : attr_Route.Template.ToLower();
                        lstQuyens.Add(quyen);
                    }
                    else if (attr_Get != null && attr_Route == null)
                    {
                        quyen.Method = HttpMethod.Get.ToString().ToLower();
                        lstQuyens.Add(quyen);
                    }
                    else if (attr_Get == null && attr_Route != null)
                    {
                        quyen.Method = HttpMethod.Get.ToString().ToLower();
                        quyen.Template = string.IsNullOrWhiteSpace(attr_Route.Template) ? string.Empty : attr_Route.Template.ToLower();
                        lstQuyens.Add(quyen);
                    }

                    HttpPostAttribute attr_Post = (HttpPostAttribute)action.Attributes.FirstOrDefault(x => x.GetType() == typeof(HttpPostAttribute));
                    if (attr_Post != null)
                    {
                        quyen.Method = HttpMethod.Post.ToString().ToLower();
                        lstQuyens.Add(quyen);
                    }

                    HttpPutAttribute attr_Put = (HttpPutAttribute)action.Attributes.FirstOrDefault(x => x.GetType() == typeof(HttpPutAttribute));
                    if (attr_Put != null)
                    {
                        quyen.Method = HttpMethod.Put.ToString().ToLower();
                        lstQuyens.Add(quyen);
                    }

                    HttpDeleteAttribute attr_Delete = (HttpDeleteAttribute)action.Attributes.FirstOrDefault(x => x.GetType() == typeof(HttpDeleteAttribute));
                    if (attr_Delete != null)
                    {
                        quyen.Method = HttpMethod.Delete.ToString().ToLower();
                        lstQuyens.Add(quyen);
                    }



                    quyen.KeyID = 0;
                    quyen.NgayTao = time;
                    quyen.Controller = BaseController.Controller;
                    quyen.Action = action.Action;
                    quyen.MacDinh = true;
                    quyen.Path = string.Join("/", quyen.Controller, quyen.Action, quyen.Template).TrimEnd('/');
                }
            }

            foreach (var controller in Controllers)
            {
                List<xQuyen> lstTemps = new List<xQuyen>();

                foreach (var action in controller.Actions)
                {
                    xQuyen f = new xQuyen();

                    HttpGetAttribute attr_Get = (HttpGetAttribute)action.Attributes.FirstOrDefault(x => x.GetType() == typeof(HttpGetAttribute));
                    if (attr_Get != null)
                    {
                        f.Method = HttpMethod.Get.ToString().ToLower();
                        // f.Template = string.IsNullOrWhiteSpace(attr_Get.Template) ? string.Empty : attr_Get.Template.ToLower();
                        lstTemps.Add(f);
                    }

                    HttpPostAttribute attr_Post = (HttpPostAttribute)action.Attributes.FirstOrDefault(x => x.GetType() == typeof(HttpPostAttribute));
                    if (attr_Post != null)
                    {
                        f.Method = HttpMethod.Post.ToString().ToLower();
                        //f.Template = string.IsNullOrWhiteSpace(attr_Post.Template) ? string.Empty : attr_Post.Template.ToLower();
                        lstTemps.Add(f);
                    }

                    HttpPutAttribute attr_Put = (HttpPutAttribute)action.Attributes.FirstOrDefault(x => x.GetType() == typeof(HttpPutAttribute));
                    if (attr_Put != null)
                    {
                        f.Method = HttpMethod.Put.ToString().ToLower();
                        // f.Template = string.IsNullOrWhiteSpace(attr_Put.Template) ? string.Empty : attr_Put.Template.ToLower();
                        lstTemps.Add(f);
                    }

                    HttpDeleteAttribute attr_Delete = (HttpDeleteAttribute)action.Attributes.FirstOrDefault(x => x.GetType() == typeof(HttpDeleteAttribute));
                    if (attr_Delete != null)
                    {
                        f.Method = HttpMethod.Delete.ToString().ToLower();
                        //  f.Template = string.IsNullOrWhiteSpace(attr_Delete.Template) ? string.Empty : attr_Delete.Template.ToLower();
                        lstTemps.Add(f);
                    }

                    RouteAttribute attr_Route = (RouteAttribute)action.Attributes.FirstOrDefault(x => x.GetType() == typeof(RouteAttribute));
                    if (attr_Route != null)
                    {
                        f.Method = string.IsNullOrWhiteSpace(f.Method) ? HttpMethod.Get.ToString().ToLower() : f.Method;
                        f.Template = string.IsNullOrWhiteSpace(attr_Route.Template) ? string.Empty : attr_Route.Template.ToLower();
                        lstTemps.Add(f);
                    }

                    f.KeyID = 0;
                    f.NgayTao = time;
                    f.Controller = controller.Controller;
                    f.Action = action.Action;
                    f.Path = string.Join("/", f.Controller, f.Action, f.Template).TrimEnd('/');
                }

                lstQuyens.AddRange(lstTemps);
            }

            return await SaveData(lstQuyens.ToArray());
        }
        async Task<IHttpActionResult> SaveData(xQuyen[] features)
        {
            Instance.Context = new aModel();
            try
            {
                Instance.BeginTransaction();
                IEnumerable<xQuyen> lstRemoves = await Instance.Context.xQuyen.ToListAsync();
                Instance.Context.xQuyen.RemoveRange(lstRemoves.ToArray());
                Instance.Context.xQuyen.AddRange(features.ToArray());
                await Instance.SaveChanges();
                Instance.CommitTransaction();
                return Ok(features);
            }
            catch (Exception ex)
            {
                Instance.RollbackTransaction();
                ModelState.AddModelError("Exception", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> Login()
        {
            Instance.Context = new aModel();
            try
            {
                string Username = Request.Headers.GetValues("Username").FirstOrDefault();
                string Password = Request.Headers.GetValues("Password").FirstOrDefault();

                if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
                    throw new Exception("Username hoặc Password không hợp lệ");

                xTaiKhoan account = await Instance.Context.xTaiKhoan.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(Username.ToLower()) && x.Password.ToLower().Equals(Password.ToLower()));
                if (account == null)
                    throw new Exception("Tài khoản không tồn tại");

                xNhanVien personnel = await Instance.Context.xNhanVien.FindAsync(account.KeyID);
                if (personnel == null)
                    throw new Exception("Nhân viên không tồn tại");

                ThongTinNguoiDung user = new ThongTinNguoiDung()
                {
                    xPersonnel = personnel,
                    xAccount = account
                };

                return Ok(user);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
