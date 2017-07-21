using System;
using System.Collections.Generic;
using System.Text;

namespace SOCIOS
{
    class ultimodia
    {
        public DateTime GetLastDayOf(DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }
    }
}
