using CalendarAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarAPI.Data.Context
{
    public class CalendarDBContext:DbContext
    {
        public CalendarDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<CalendarRequest> CalendarRequest { get; set; }

    }
}
