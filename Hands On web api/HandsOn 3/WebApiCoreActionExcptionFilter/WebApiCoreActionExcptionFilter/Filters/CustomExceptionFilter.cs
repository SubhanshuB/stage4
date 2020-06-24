using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiCoreActionExcptionFilter.Filters
{
    public class CustomExceptionFilter: ExceptionFilterAttribute, IExceptionFilter
    {
        public override void OnException(ExceptionContext context)
        {
            
            var error = context.Exception;
            string strPath = @"D:\error.txt";
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + error.Message);
                sw.WriteLine("Stack Trace: " + error.StackTrace);
                sw.WriteLine("===========End============= " + DateTime.Now);

            }

            context.HttpContext.Response.StatusCode = 401;
            context.Result = new ExceptionResult(error,true);
            context.ExceptionHandled = true;
            base.OnException(context);
        }
    }
}
