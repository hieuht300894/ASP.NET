using EntityModel.DataModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace QuanLyBanHang_API
{
    public class Filter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext context)
        {
            if (CheckRole(context) == HttpStatusCode.OK)
            {
                base.OnActionExecuting(context);
            }
            else
            {
                context.Response = new System.Net.Http.HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
        }

        HttpStatusCode CheckRole(HttpActionContext actionContext)
        {
            try
            {
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





                ////IPAddress address = context.HttpContext.Connection.RemoteIpAddress;

                //ControllerActionDescriptor descriptor = (ControllerActionDescriptor)context.ActionDescriptor;
                //string MethodName = context.HttpContext.Request.Method.ToLower();
                //string ControllerName = descriptor.ControllerName.ToLower();
                //string ActionName = descriptor.ActionName.ToLower();
                //string TemplateName = descriptor.AttributeRouteInfo.Template.ToLower();

                //aModel db = new aModel();

                //xAccount account = db.xAccount.Find(Convert.ToInt32(controller.Request.Headers["IDAccount"].ToList()[0]));
                //if (account == null)
                //    return HttpStatusCode.BadRequest;

                //xUserFeature userFeature = db.xUserFeature
                //    .FirstOrDefault(x =>
                //        x.IDPermission == account.IDPermission &&
                //        x.Controller.Equals(ControllerName) &&
                //        x.Action.Equals(ActionName) &&
                //        x.Method.Equals(MethodName) &&
                //        x.Path.Equals(TemplateName));

                //if (userFeature == null)
                //    return HttpStatusCode.BadRequest;

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
