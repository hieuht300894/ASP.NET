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
                context.Response.Content.Headers.Add("Exception", "Unauthorized");
            }
        }

        HttpStatusCode CheckRole(HttpActionContext context)
        {
            return HttpStatusCode.OK;

            //try
            //{
            //    ApiController controller = (Controller)context.Controller;

            //    //IPAddress address = context.HttpContext.Connection.RemoteIpAddress;

            //    //ControllerActionDescriptor descriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            //    //string MethodName = context.HttpContext.Request.Method.ToLower();
            //    //string ControllerName = descriptor.ControllerName.ToLower();
            //    //string ActionName = descriptor.ActionName.ToLower();
            //    //string TemplateName = descriptor.AttributeRouteInfo.Template.ToLower();

            //    ControllerActionDescriptor descriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            //    string MethodName = context.HttpContext.Request.Method.ToLower();
            //    string ControllerName = descriptor.ControllerName.ToLower();
            //    string ActionName = descriptor.ActionName.ToLower();
            //    string TemplateName = descriptor.AttributeRouteInfo.Template.ToLower();

            //    aModel db = new aModel();

            //    xAccount account = db.xAccount.Find(Convert.ToInt32(controller.Request.Headers["IDAccount"].ToList()[0]));
            //    if (account == null)
            //        return HttpStatusCode.BadRequest;

            //    xUserFeature userFeature = db.xUserFeature
            //        .FirstOrDefault(x =>
            //            x.IDPermission == account.IDPermission &&
            //            x.Controller.Equals(ControllerName) &&
            //            x.Action.Equals(ActionName) &&
            //            x.Method.Equals(MethodName) &&
            //            x.Path.Equals(TemplateName));

            //    if (userFeature == null)
            //        return HttpStatusCode.BadRequest;

            //    if (userFeature.TrangThai == 3)
            //        return HttpStatusCode.BadRequest;

            //    return HttpStatusCode.OK;
            //}
            //catch
            //{
            //    return HttpStatusCode.BadRequest;
            //}
        }
    }
}
