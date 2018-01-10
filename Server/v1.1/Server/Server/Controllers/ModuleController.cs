using EntityModel;
using EntityModel.DataModel;
using Server.Extension;
using Server.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("[controller]")]
    public class ModuleController : CustomController
    {
        [HttpPost]
        public async Task<ActionResult> DataSeed()
        {
            IList<ActionResult> lstResult = new List<ActionResult>();

            lstResult.Add(await InitAgency());
            lstResult.Add(await InitTienTe());
            lstResult.Add(await InitTinhThanh());
            lstResult.Add(await InitDonViTinh());

            return Ok(lstResult);
        }
        async Task<ActionResult> InitAgency()
        {
            aModel db = new aModel();

            if (db.xChiNhanh.Count() == 0)
            {
                try
                {
                    string Query = System.IO.File.ReadAllText($@"{HttpRuntime.AppDomainAppPath}\wwwroot\InitData\DATA_xChiNhanh.sql");
                    await db.Database.ExecuteSqlCommandAsync(Query, new SqlParameter[] { });
                    return Ok($"Init data {(typeof(xChiNhanh).Name)} success.");
                }
                catch (Exception ex) { return BadRequest($"Init data {(typeof(xChiNhanh).Name)} fail: {ex}"); }
            }

            return Ok($"No init {(typeof(xChiNhanh).Name)} data");
        }
        async Task<ActionResult> InitTienTe()
        {
            aModel db = new aModel();

            if (db.eTienTe.Count() == 0)
            {
                try
                {
                    string Query = System.IO.File.ReadAllText($@"{HttpRuntime.AppDomainAppPath}\wwwroot\InitData\DATA_eTienTe.sql");
                    await db.Database.ExecuteSqlCommandAsync(Query, new SqlParameter[] { });
                    return Ok($"Init data {(typeof(eTienTe).Name)} success.");
                }
                catch (Exception ex) { return BadRequest($"Init data {(typeof(eTienTe).Name)} fail: {ex}"); }
            }
            return Ok($"No init {(typeof(eTienTe).Name)} data");
        }
        async Task<ActionResult> InitTinhThanh()
        {
            aModel db = new aModel();

            if (db.eTinhThanh.Count() == 0)
            {
                try
                {
                    string Query = System.IO.File.ReadAllText($@"{HttpRuntime.AppDomainAppPath}\wwwroot\InitData\DATA_eTinhThanh.sql");
                    await db.Database.ExecuteSqlCommandAsync(Query, new SqlParameter[] { });
                    return Ok($"Init data {(typeof(eTinhThanh).Name)} success.");
                }
                catch (Exception ex) { return BadRequest($"Init data {(typeof(eTinhThanh).Name)} fail: {ex}"); }
            }
            return Ok($"No init {(typeof(eTinhThanh).Name)} data");
        }
        async Task<ActionResult> InitDonViTinh()
        {
            aModel db = new aModel();

            if (db.eDonViTinh.Count() == 0)
            {
                try
                {
                    string Query = System.IO.File.ReadAllText($@"{HttpRuntime.AppDomainAppPath}\wwwroot\InitData\DATA_eDonViTinh.sql");
                    await db.Database.ExecuteSqlCommandAsync(Query, new SqlParameter[] { });
                    return Ok($"Init data {(typeof(eDonViTinh).Name)} success.");
                }
                catch (Exception ex) { return BadRequest($"Init data {(typeof(eDonViTinh).Name)} fail: {ex}"); }
            }
            return Ok($"No init {(typeof(eDonViTinh).Name)} data");
        }

        [HttpGet]
        public async Task<ActionResult> TimeServer()
        {
            try { return await Task.Factory.StartNew(() => { return Ok(DateTime.Now); }); }
            catch { return Ok(DateTime.Now); }

        }

        [HttpPost]
        public async Task<ActionResult> InitUser()
        {
            aModel db = new aModel();
            DateTime time = DateTime.Now;

            try
            {
                db.BeginTransaction();

                xNhomQuyen nhomQuyen = new xNhomQuyen()
                {
                    KeyID = 0,
                    Ma = "ADMIN",
                    Ten = "ADMIN",
                    NgayTao = time
                };
                db.xNhomQuyen.Add(nhomQuyen);
                await db.SaveChangesAsync();

                xNhanVien nhanVien = new xNhanVien()
                {
                    KeyID = 0,
                    Ma = "NV0001",
                    Ten = "Nhân viên 0001",
                    NgayTao = time
                };
                db.xNhanVien.Add(nhanVien);
                await db.SaveChangesAsync();

                xTaiKhoan taiKhoan = new xTaiKhoan()
                {
                    KeyID = nhanVien.KeyID,
                    NgayTao = time,
                    MaNhanVien=nhanVien.Ma,
                    TenNhanVien = nhanVien.Ten,
                    Username = "admin",
                    Password = "admin",
                    IDNhomQuyen = nhomQuyen.KeyID,
                    MaNhomQuyen=nhomQuyen.Ma,
                    TenNhomQuyen = nhomQuyen.Ten
                };
                db.xTaiKhoan.Add(taiKhoan);
                await db.SaveChangesAsync();

                List<xQuyen> lstQuyens = await db.xQuyen.ToListAsync();
                List<xPhanQuyen> lstPhanQuyens = new List<xPhanQuyen>();
                foreach (xQuyen quyen in lstQuyens)
                {
                    lstPhanQuyens.Add(new xPhanQuyen()
                    {
                        KeyID = 0,
                        IDNhomQuyen = nhomQuyen.KeyID,
                        MaNhomQuyen=nhomQuyen.Ma,
                        TenNhomQuyen = nhomQuyen.Ten,
                        IDQuyen = quyen.KeyID, 
                        Controller = quyen.Controller,
                        Action = quyen.Action,
                        Method = quyen.Method,
                        Template = quyen.Template,
                        Path = quyen.Path,
                        NgayTao = time
                    });
                }
                db.xPhanQuyen.AddRange(lstPhanQuyens.ToArray());
                await db.SaveChangesAsync();

                db.CommitTransaction();
                return Ok(lstPhanQuyens);
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                ModelState.AddModelError("Exception_Message", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public async Task<ActionResult> GetController()
        {
            List<xQuyen> lstQuyens = new List<xQuyen>();

            Assembly asm = Assembly.GetExecutingAssembly();

            var q1 = asm
                .GetExportedTypes()
                .Where(x => typeof(CustomController).IsAssignableFrom(x) && !x.Name.Equals(typeof(CustomController).Name))
                .Select(x => new
                {
                    Controller = x.Name,
                    Methods = x.GetMethods().Where(y => y.DeclaringType.IsSubclassOf(typeof(CustomController)) && y.IsPublic && !y.IsStatic).ToList()
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
                        quyen.Method = HttpVerbs.Get.ToString().ToLower();
                        quyen.Template = string.IsNullOrWhiteSpace(attr_Route.Template) ? string.Empty : attr_Route.Template.ToLower();
                        lstQuyens.Add(quyen);
                    }
                    else if (attr_Get != null && attr_Route == null)
                    {
                        quyen.Method = HttpVerbs.Get.ToString().ToLower();
                        lstQuyens.Add(quyen);
                    }
                    else if (attr_Get == null && attr_Route != null)
                    {
                        quyen.Method = HttpVerbs.Get.ToString().ToLower();
                        quyen.Template = string.IsNullOrWhiteSpace(attr_Route.Template) ? string.Empty : attr_Route.Template.ToLower();
                        lstQuyens.Add(quyen);
                    }

                    HttpPostAttribute attr_Post = (HttpPostAttribute)action.Attributes.FirstOrDefault(x => x.GetType() == typeof(HttpPostAttribute));
                    if (attr_Post != null)
                    {
                        quyen.Method = HttpVerbs.Post.ToString().ToLower();
                        lstQuyens.Add(quyen);
                    }

                    HttpPutAttribute attr_Put = (HttpPutAttribute)action.Attributes.FirstOrDefault(x => x.GetType() == typeof(HttpPutAttribute));
                    if (attr_Put != null)
                    {
                        quyen.Method = HttpVerbs.Put.ToString().ToLower();
                        lstQuyens.Add(quyen);
                    }

                    HttpDeleteAttribute attr_Delete = (HttpDeleteAttribute)action.Attributes.FirstOrDefault(x => x.GetType() == typeof(HttpDeleteAttribute));
                    if (attr_Delete != null)
                    {
                        quyen.Method = HttpVerbs.Delete.ToString().ToLower();
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
                        f.Method = HttpVerbs.Get.ToString().ToLower();
                        // f.Template = string.IsNullOrWhiteSpace(attr_Get.Template) ? string.Empty : attr_Get.Template.ToLower();
                        lstTemps.Add(f);
                    }

                    HttpPostAttribute attr_Post = (HttpPostAttribute)action.Attributes.FirstOrDefault(x => x.GetType() == typeof(HttpPostAttribute));
                    if (attr_Post != null)
                    {
                        f.Method = HttpVerbs.Post.ToString().ToLower();
                        //f.Template = string.IsNullOrWhiteSpace(attr_Post.Template) ? string.Empty : attr_Post.Template.ToLower();
                        lstTemps.Add(f);
                    }

                    HttpPutAttribute attr_Put = (HttpPutAttribute)action.Attributes.FirstOrDefault(x => x.GetType() == typeof(HttpPutAttribute));
                    if (attr_Put != null)
                    {
                        f.Method = HttpVerbs.Put.ToString().ToLower();
                        // f.Template = string.IsNullOrWhiteSpace(attr_Put.Template) ? string.Empty : attr_Put.Template.ToLower();
                        lstTemps.Add(f);
                    }

                    HttpDeleteAttribute attr_Delete = (HttpDeleteAttribute)action.Attributes.FirstOrDefault(x => x.GetType() == typeof(HttpDeleteAttribute));
                    if (attr_Delete != null)
                    {
                        f.Method = HttpVerbs.Delete.ToString().ToLower();
                        //  f.Template = string.IsNullOrWhiteSpace(attr_Delete.Template) ? string.Empty : attr_Delete.Template.ToLower();
                        lstTemps.Add(f);
                    }

                    RouteAttribute attr_Route = (RouteAttribute)action.Attributes.FirstOrDefault(x => x.GetType() == typeof(RouteAttribute));
                    if (attr_Route != null)
                    {
                        f.Method = string.IsNullOrWhiteSpace(f.Method) ? HttpVerbs.Get.ToString().ToLower() : f.Method;
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
        async Task<ActionResult> SaveData(xQuyen[] features)
        {
            aModel db = new aModel();
            try
            {
                db.BeginTransaction();
                IEnumerable<xQuyen> lstRemoves = await db.xQuyen.ToListAsync();
                db.xQuyen.RemoveRange(lstRemoves.ToArray());
                db.xQuyen.AddRange(features.ToArray());
                await db.SaveChangesAsync();
                db.CommitTransaction();
                return Ok(features);
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                ModelState.AddModelError("Exception_Message", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Login()
        {
            aModel db = new aModel();
            try
            {
                string Username = Request.Headers["Username"];
                string Password = Request.Headers["Password"];

                if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
                    throw new Exception("Username hoặc Password không hợp lệ");

                xTaiKhoan account = await db.xTaiKhoan.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(Username.ToLower()) && x.Password.ToLower().Equals(Password.ToLower()));
                if (account == null)
                    throw new Exception("Tài khoản không tồn tại");

                xNhanVien personnel = await db.xNhanVien.FindAsync(account.KeyID);
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
                ModelState.AddModelError("Exception_Message", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
