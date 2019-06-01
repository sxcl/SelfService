using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SelfServiceMachine.Common;
using System;
using System.Threading.Tasks;

namespace SelfServiceMachine.Filter
{
    /// <summary>
    /// 异常拦截中间件
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// 异步方法
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                var statusCode = context.Response.StatusCode;
                if (e is ArgumentException)
                {
                    statusCode = 200;
                }

                await HandleExceptionAsync(context, statusCode, e.Message);
            }
            finally
            {
                var statusCode = context.Response.StatusCode;
                var msg = "";
                if (statusCode != 200)
                {
                    _logger.LogError(context.Request.GetAbsoluteUri() + "\r\n" + statusCode.ToString());
                }
                if (!string.IsNullOrEmpty(msg))
                {
                    await HandleExceptionAsync(context, statusCode, msg);
                }
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, int statusCode, string message)
        {
            var data = new { code = statusCode.ToString(), is_success = false, msg = message };
            var result = JsonOperator.JsonSerialize(new { data });
            context.Response.ContentType = "application/json;charset=utf-8";
            return context.Response.WriteAsync(result);
        }
    }
}
