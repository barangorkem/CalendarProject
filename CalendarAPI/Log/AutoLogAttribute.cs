using CalendarAPI.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;


namespace CalendarAPI.Log
{
    public class AutoLogAttribute : TypeFilterAttribute
    {
        public AutoLogAttribute() : base(typeof(AutoLogActionFilterImpl))
        {

        }

        private class AutoLogActionFilterImpl : IActionFilter
        {
            private readonly ILogger _logger;
            public AutoLogActionFilterImpl(ILoggerFactory loggerFactory)
            {
                _logger = loggerFactory.CreateLogger<AutoLogAttribute>();
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                //Gelen istekler yazılır.
                LogWrite.LogMessage(context.HttpContext.Request.Path.ToString()); //İlk bağlantı olacağı zaman url çubuğundaki yol kaydedilir.
            }

            public void OnActionExecuted(ActionExecutedContext context)

            {
              


                    var result = (ObjectResult)context.Result;
                if(result.StatusCode==444)
                {
                    LogWrite.LogMessage(ErrorResponse.ERROR_REQUEST);
                }
                else
                {
                    LogWrite.LogMessage(result.Value.ToString());
                }

                //TODO: log body content and response as well

            }

        }
    }
}

