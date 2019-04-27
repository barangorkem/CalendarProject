
using Microsoft.AspNetCore.Mvc;
using CalendarAPI.Log;
using CalendarAPI.Response;
using System.Net;

namespace CalendarAPI.Controllers
{
    
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("api/error")]
        public IActionResult Error444(int? statusCode=null) //Hatalı adreslere buraya gelir.
        {
            if (statusCode.HasValue)
            {
                if (statusCode.Value == 404 || statusCode.Value == 500)
                {
                    var viewName = statusCode.ToString();
                    return StatusCode(444,"444 ERROR"); ;
                }
          
            }
            return StatusCode(200);
        }
    }
}