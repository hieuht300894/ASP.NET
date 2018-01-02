using EntityModel.DataModel;
using EntityModel.Model;
using Server.Attribute;
using Server.Extension;
using Server.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [AllowJsonGet]
    [Route("[controller]")]
    public class ModuleController : CustomController
    {
        [HttpPost]
        [Route("DataSeed")]
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

            if (db.xAgency.Count() == 0)
            {
                try
                {
                    string Query = System.IO.File.ReadAllText($@"{HttpRuntime.AppDomainAppPath}\wwwroot\InitData\DATA_xAgency.sql");
                    await db.Database.ExecuteSqlCommandAsync(Query, new SqlParameter[] { });
                    return Ok($"Init data {(typeof(xAgency).Name)} success.");
                }
                catch (Exception ex) { return BadRequest($"Init data {(typeof(xAgency).Name)} fail: {ex}"); }
            }

            return Ok($"No init {(typeof(xAgency).Name)} data");
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
        [Route("TimeServer")]
        public async Task<ActionResult> TimeServer()
        {
            try { return await Task.Factory.StartNew(() => { return Ok(DateTime.Now); }); }
            catch { return Ok(DateTime.Now); }

        }

        [HttpPost]
        [Route("InitUser")]
        public async Task<ActionResult> InitUser()
        {
            aModel db = new aModel();
            DateTime time = DateTime.Now;

            try
            {
                db.BeginTransaction();

                xPermission permission = new xPermission()
                {
                    KeyID = 0,
                    Ma = "ADMIN",
                    Ten = "ADMIN",
                    NgayTao = time
                };
                db.xPermission.Add(permission);
                await db.SaveChangesAsync();

                xPersonnel personnel = new xPersonnel()
                {
                    KeyID = 0,
                    Ma = "NV0001",
                    Ten = "Nhân viên 0001",
                    NgayTao = time
                };
                db.xPersonnel.Add(personnel);
                await db.SaveChangesAsync();

                xAccount account = new xAccount()
                {
                    KeyID = personnel.KeyID,
                    NgayTao = time,
                    PersonelName = personnel.Ten,
                    UserName = "admin",
                    Password = "admin",
                    IDPermission = permission.KeyID,
                    PermissionName = permission.Ten
                };
                db.xAccount.Add(account);
                await db.SaveChangesAsync();

                List<xFeature> features = await db.xFeature.ToListAsync();
                List<xUserFeature> userFeatures = new List<xUserFeature>();
                foreach (xFeature f in features)
                {
                    userFeatures.Add(new xUserFeature()
                    {
                        KeyID = 0,
                        IDPermission = permission.KeyID,
                        PermissionName = permission.Ten,
                        IDFeature = f.KeyID,
                        Controller = f.Controller,
                        Action = f.Action,
                        Method = f.Method,
                        Template = f.Template,
                        Path = f.Path,
                        NgayTao = time
                    });
                }
                db.xUserFeature.AddRange(userFeatures.ToArray());
                await db.SaveChangesAsync();

                db.CommitTransaction();
                return Ok(userFeatures);
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                ModelState.AddModelError("Exception_Message", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("GetController")]
        public async Task<ActionResult> GetController()
        {
            List<xFeature> lstFeatures = new List<xFeature>();

            Assembly asm = Assembly.GetExecutingAssembly();

            var Controllers = asm.GetExportedTypes()
                .Where(x => typeof(ControllerBase).IsAssignableFrom(x) && !x.Name.Equals(typeof(BaseController<>).Name))
                .Select(x => new
                {
                    Controller = x.Name,
                    Methods = x.GetMethods().Where(y => y.DeclaringType.IsSubclassOf(typeof(ControllerBase)) && y.IsPublic && !y.IsStatic).ToList()
                })
                .Select(x => new
                {
                    Controller = x.Controller.ToLower().Replace("controller", string.Empty),
                    Actions = x.Methods.Select(y => new { Action = y.Name.ToLower(), Attributes = y.GetCustomAttributes(true).ToList() })
                });

            DateTime time = DateTime.Now;

            foreach (var controller in Controllers)
            {
                List<xFeature> lstTemps = new List<xFeature>();

                foreach (var action in controller.Actions)
                {
                    xFeature f = new xFeature();

                    //HttpGetAttribute attr_Get = (HttpGetAttribute)action.Attributes.FirstOrDefault(x => x.GetType() == typeof(HttpGetAttribute));
                    //if (attr_Get != null)
                    //{
                    //    f.Method = HttpMethods.Get.ToLower();
                    //    f.Template = string.IsNullOrWhiteSpace(attr_Get.Template) ? string.Empty : attr_Get.Template.ToLower();
                    //    lstTemps.Add(f);
                    //}

                    //HttpPostAttribute attr_Post = (HttpPostAttribute)action.Attributes.FirstOrDefault(x => x.GetType() == typeof(HttpPostAttribute));
                    //if (attr_Post != null)
                    //{
                    //    f.Method = HttpMethods.Post.ToLower();
                    //    f.Template = string.IsNullOrWhiteSpace(attr_Post.Template) ? string.Empty : attr_Post.Template.ToLower();
                    //    lstTemps.Add(f);
                    //}

                    //HttpPutAttribute attr_Put = (HttpPutAttribute)action.Attributes.FirstOrDefault(x => x.GetType() == typeof(HttpPutAttribute));
                    //if (attr_Put != null)
                    //{
                    //    f.Method = HttpMethods.Put.ToLower();
                    //    f.Template = string.IsNullOrWhiteSpace(attr_Put.Template) ? string.Empty : attr_Put.Template.ToLower();
                    //    lstTemps.Add(f);
                    //}

                    //HttpDeleteAttribute attr_Delete = (HttpDeleteAttribute)action.Attributes.FirstOrDefault(x => x.GetType() == typeof(HttpDeleteAttribute));
                    //if (attr_Delete != null)
                    //{
                    //    f.Method = HttpMethods.Delete.ToLower();
                    //    f.Template = string.IsNullOrWhiteSpace(attr_Delete.Template) ? string.Empty : attr_Delete.Template.ToLower();
                    //    lstTemps.Add(f);
                    //}

                    //RouteAttribute attr_Route = (RouteAttribute)action.Attributes.FirstOrDefault(x => x.GetType() == typeof(RouteAttribute));
                    //if (attr_Route != null)
                    //{
                    //    f.Method = string.IsNullOrWhiteSpace(f.Method) ? HttpMethods.Get.ToLower() : f.Method;
                    //    f.Template = string.IsNullOrWhiteSpace(attr_Route.Template) ? string.Empty : attr_Route.Template.ToLower();
                    //    lstTemps.Add(f);
                    //}

                    f.KeyID = 0;
                    f.NgayTao = time;
                    f.Controller = controller.Controller;
                    f.Action = action.Action;
                    f.Path = string.Join("/", "api", f.Controller, f.Template).TrimEnd('/');
                }

                lstFeatures.AddRange(lstTemps);
            }

            return await SaveData(lstFeatures.ToArray());
        }
        async Task<ActionResult> SaveData(xFeature[] features)
        {
            aModel db = new aModel();
            try
            {
                db.BeginTransaction();
                IEnumerable<xFeature> lstRemoves = await db.xFeature.ToListAsync();
                db.xFeature.RemoveRange(lstRemoves.ToArray());
                db.xFeature.AddRange(features.ToArray());
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
        [Route("Login")]
        public async Task<ActionResult> Login()
        {
            aModel db = new aModel();
            try
            {
                string Username = Request.Headers["Username"];
                string Password = Request.Headers["Password"];

                if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
                    throw new Exception("Username hoặc Password không hợp lệ");

                xAccount account = await db.xAccount.FirstOrDefaultAsync(x => x.UserName.ToLower().Equals(Username.ToLower()) && x.Password.ToLower().Equals(Password.ToLower()));
                if (account == null)
                    throw new Exception("Tài khoản không tồn tại");

                xPersonnel personnel = await db.xPersonnel.FindAsync(account.KeyID);
                if (personnel == null)
                    throw new Exception("Nhân viên không tồn tại");

                UserInfo user = new UserInfo()
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
