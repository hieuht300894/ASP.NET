namespace Server.Middleware
{
    //public class Filter : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(ActionExecutingContext context)
    //    {
    //        if (CheckRole(context) == HttpStatusCode.BadRequest)
    //        {
    //            UnauthorizedResult unauthorized = new UnauthorizedResult();
    //            context.Result = unauthorized;
    //        }
    //        else
    //        {
    //            base.OnActionExecuting(context);
    //        }

    //        //// TODO implement some business logic for this...
    //        //if (context.HttpContext.Request.Method.Equals("GET"))
    //        //{
    //        //    context.HttpContext.Response.StatusCode = (Int32)HttpStatusCode.BadRequest;

    //        //    Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary modelState = new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary();
    //        //    modelState.AddModelError("Error", "Not Get");

    //        //    Microsoft.AspNetCore.Mvc.BadRequestObjectResult badRequest = new Microsoft.AspNetCore.Mvc.BadRequestObjectResult(modelState);
    //        //    context.Result = badRequest;
    //        //}
    //        //else
    //        //{
    //        //    base.OnActionExecuting(context);
    //        //}
    //    }

    //    HttpStatusCode CheckRole(ActionExecutingContext context)
    //    {
    //        try
    //        {
    //            Controller controller = (Controller)context.Controller;

    //            //IPAddress address = context.HttpContext.Connection.RemoteIpAddress;

    //            //ControllerActionDescriptor descriptor = (ControllerActionDescriptor)context.ActionDescriptor;
    //            //string MethodName = context.HttpContext.Request.Method.ToLower();
    //            //string ControllerName = descriptor.ControllerName.ToLower();
    //            //string ActionName = descriptor.ActionName.ToLower();
    //            //string TemplateName = descriptor.AttributeRouteInfo.Template.ToLower();

    //            ControllerActionDescriptor descriptor = (ControllerActionDescriptor)context.ActionDescriptor;
    //            string MethodName = context.HttpContext.Request.Method.ToLower();
    //            string ControllerName = descriptor.ControllerName.ToLower();
    //            string ActionName = descriptor.ActionName.ToLower();
    //            string TemplateName = descriptor.AttributeRouteInfo.Template.ToLower();

    //            aModel db = new aModel();

    //            xAccount account = db.xAccount.Find(Convert.ToInt32(controller.Request.Headers["IDAccount"].ToList()[0]));
    //            if (account == null)
    //                return HttpStatusCode.BadRequest;

    //            xUserFeature userFeature = db.xUserFeature
    //                .FirstOrDefault(x =>
    //                    x.IDPermission == account.IDPermission &&
    //                    x.Controller.Equals(ControllerName) &&
    //                    x.Action.Equals(ActionName) &&
    //                    x.Method.Equals(MethodName) &&
    //                    x.Path.Equals(TemplateName));

    //            if (userFeature == null)
    //                return HttpStatusCode.BadRequest;

    //            if (userFeature.TrangThai == 3)
    //                return HttpStatusCode.BadRequest;

    //            return HttpStatusCode.OK;
    //        }
    //        catch
    //        {
    //            return HttpStatusCode.BadRequest;
    //        }
    //    }
    //}
}
