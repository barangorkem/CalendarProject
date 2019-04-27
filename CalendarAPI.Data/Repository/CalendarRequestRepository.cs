using CalendarAPI.Data.Context;
using CalendarAPI.Data.Models;
using System;


namespace CalendarAPI.Data.Repository
{
    public class CalendarRequestRepository
    {
        CalendarDBContext _dbContext;

        public CalendarRequestRepository(CalendarDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public int FindFirstDayRepetition(DateTime started_date, DateTime end_date)
        {
            int counter = 0;
            if (started_date.Day > 1)  //Eğer girilen gün o ayın 1.günü değilse o ayı aralıkta kabul edemeyiz.
            {
                started_date = started_date.AddMonths(1); //Bu yüzden ayı 1 ay kadar ileri alıyoruz.
            }
            do
            {

                DateTime firstDayOfMonth = new DateTime(started_date.Year, started_date.Month, 1);

                if (firstDayOfMonth.DayOfWeek.ToString() == "Sunday")
                {
                    counter++;
                }

                started_date = started_date.AddMonths(1);  

            } while (end_date >= started_date);
            return counter;
        }
        public void InsertRequest(CalendarRequest calendarRequest)
        {
            try
            {
                _dbContext.CalendarRequest.Add(calendarRequest);
                Save();
            }catch(Exception err)
            {
                throw err;
            }
            
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
