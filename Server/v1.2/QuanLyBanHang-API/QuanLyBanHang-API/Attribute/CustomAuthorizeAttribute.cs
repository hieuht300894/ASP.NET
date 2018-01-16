using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace QuanLyBanHang_API
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            return base.IsAuthorized(actionContext);
        }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (!(CheckRole(actionContext) == HttpStatusCode.OK))
                base.OnAuthorization(actionContext);
        }
        HttpStatusCode CheckRole(HttpActionContext actionContext)
        {
            try
            {
                var attr = ((ReflectedHttpActionDescriptor)actionContext.ActionDescriptor).MethodInfo.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(AllowAnonymousAttribute));
                if (attr != null)
                    return HttpStatusCode.OK;

                var address = actionContext.Request.RequestUri;
                string MethodName = actionContext.Request.Method.Method.ToLower();
                string ControllerName = actionContext.ControllerContext.ControllerDescriptor.ControllerName.ToLower();
                string ActionName = actionContext.ActionDescriptor.ActionName.ToLower();

                aModel db = new aModel();
                xTaiKhoan taiKhoan = db.xTaiKhoan.Find(Convert.ToInt32(actionContext.Request.Headers.GetValues("IDAccount").ToList()[0]));
                if (taiKhoan == null)
                    return HttpStatusCode.NotFound;

                xPhanQuyen phanQuyen = db.xPhanQuyen.FirstOrDefault(x =>
                    x.IDNhomQuyen == taiKhoan.IDNhomQuyen &&
                    ((x.MacDinh && x.Action.Equals(ActionName) && x.Method.Equals(MethodName)) || (!x.MacDinh && x.Controller.Equals(ControllerName) && x.Action.Equals(ActionName) && x.Method.Equals(MethodName))));
                if (phanQuyen == null)
                    return HttpStatusCode.NotFound;

                //if (userFeature.TrangThai == 3)
                //    return HttpStatusCode.BadRequest;

                return HttpStatusCode.OK;
            }
            catch
            {
                return HttpStatusCode.BadRequest;
            }
        }
    }
}