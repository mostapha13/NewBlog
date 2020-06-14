using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;

namespace Blog.Presentation.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorHandling
    {
        private readonly RequestDelegate _next;

        public ErrorHandling(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }

        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {

            var result = JsonConvert.SerializeObject(
                new
                {
                    source = ex.Source,
                    error = ex.Message
                });
            context.Response.ContentType = "application/json";


            Log.ForContext("Message", ex.Message)

                .Error($"Error: {result}");

            return context.Response.WriteAsync(result);
        }
    }

 
   
}
