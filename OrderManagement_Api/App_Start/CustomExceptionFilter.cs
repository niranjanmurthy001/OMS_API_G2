using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace OrderManagement_Api.App_Start
{
    public class CustomExceptionFilter:ExceptionFilterAttribute
    {

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {

            HttpStatusCode Status = HttpStatusCode.InternalServerError;
            string Message = String.Empty;

            var ExceptionType = actionExecutedContext.Exception.GetType();

            if (ExceptionType == typeof(UnauthorizedAccessException))
            {

                Message = "Access to the Api is not Authorized";
                Status = HttpStatusCode.Unauthorized;
            }
            else if (ExceptionType == typeof(DivideByZeroException))
            {

                Message = "Internal Server Error";
                Status = HttpStatusCode.InternalServerError;

            }
            else if (ExceptionType == typeof(NotImplementedException))
            {

                Message = "Action is Not Implimented";
                Status = HttpStatusCode.NotImplemented;

            }
           
            else
            {
                Message = "Not Found";
                Status = HttpStatusCode.NotFound;
            }

            actionExecutedContext.Response = new System.Net.Http.HttpResponseMessage()
            {

                Content = new StringContent(Message, System.Text.Encoding.UTF8, "text/plain"),
                StatusCode=Status
            };
            base.OnException(actionExecutedContext);


        }
    }
}