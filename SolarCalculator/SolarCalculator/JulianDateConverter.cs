using System;

namespace SolarCalculation
{
    public static class JulianDateConverter
    {
        public static double CalculateJulianDate(DateTime gregorianDate)
        {
            var year = gregorianDate.Year;
            var month = gregorianDate.Month;
            var day = gregorianDate.Day;

            if (month <= 2)
            {
                year -= 1;
                month += 12;
            }

            var a = Math.Floor(year / 100d);
            var b = 2 - a + Math.Floor(a / 4d);

            var julianDate = Math.Floor(365.25 * (year + 4716)) + Math.Floor(30.6001 * (month + 1)) + day + b - 1524.5;

            return julianDate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="julianDate">The julian date for which we have to get the gregorian date</param>
        /// <param name="outsetGregorianDate">DateTime at 12:00 AM of that particular day</param>
        /// <param name="outsetJulianDate">Julian date for that particular day at 12:00 AM</param>
        /// <returns></returns>
        public static DateTime CalculateGregorianDate(double julianDate, DateTime outsetGregorianDate, double outsetJulianDate)
        {
            var hourPart = (julianDate - outsetJulianDate) * 24;
            var hours = Math.Floor(hourPart * 24);

            var minutePart = (hourPart - hours) * 60;
            var minutes = Math.Floor(minutePart);

            var seconds = Math.Round((minutePart - minutes) * 60);

            return outsetGregorianDate.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds);
        }
    }
}
