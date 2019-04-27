using System;
using System.Net;
using CalendarAPI.Data.Models;
using CalendarAPI.Data.Repository;
using CalendarAPI.MaxRequest;
using Microsoft.AspNetCore.Mvc;
using CalendarAPI.Data.Context;
using CalendarAPI.Response;

namespace CalendarAPI.Controllers
{
    [ApiController]
    public class CalendarController : ControllerBase
    {
        Throttle throttler;
        DateTime _started_date, _end_date;
        CalendarRequestRepository _calendarRequestRepository;
        
        public CalendarController(CalendarDBContext dbContext )
        {
            throttler = new Throttle("maxrequest");
            _calendarRequestRepository = new CalendarRequestRepository(dbContext);
        }


        [HttpGet]
        [Produces("application/json")]
        [Route("api/{started_date}/{end_date}")]
        public IActionResult GetCalendarDate(string started_date, string end_date)
        {
            try
            { 
            if (throttler.RequestShouldBeThrottled())  //1 dakikada 10 dan fazla istekte bulunamaz.
            {
                return StatusCode((int)HttpStatusCode.BadRequest,ErrorResponse.MAX_ERROR );
            }
            else
            {
                if (DateTime.TryParse(started_date, out _started_date) && DateTime.TryParse(end_date, out _end_date))
                {
                    if (_started_date > _end_date)
                    {
                        return StatusCode((int)HttpStatusCode.BadRequest, ErrorResponse.IS_GREATER_ERROR );

                    }
                    else if (_started_date.Year > 2000 || _started_date.Year < 1901 || _end_date.Year > 2000 || _end_date.Year < 1901)
                    {
                        return StatusCode((int)HttpStatusCode.BadRequest, ErrorResponse.IS_DATE_BETWEEN);

                    }
                    else
                    {


                        int result = _calendarRequestRepository.FindFirstDayRepetition(_started_date, _end_date);
                        _calendarRequestRepository.InsertRequest(
                            new CalendarRequest {
                                StartedDate = _started_date,
                                EndDate = _end_date,
                                Result = result,
                                RequestDate = DateTime.Now.Date
                            });
                        return StatusCode((int)HttpStatusCode.OK, result.ToString());

                    }
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, ErrorResponse.IS_DATE_TYPE);
                }

            }
        }catch(Exception err)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,ErrorResponse.INTERVAL_ERROR);
            }
        }
    }
}