using System;

namespace SolarCalculation
{
    public static class SunTrackerExtensions
    {
        public static DateTime UTCSunrise(this SunTracker tracker)
        {

            var sunriseJulianDate = tracker.SolarTransit - (tracker.HourAngle / 360.0);
            var sunriseUtcGregorianDate = JulianDateConverter.CalculateGregorianDate(sunriseJulianDate, tracker.GregorianDate, tracker.JulianDate);
            return sunriseUtcGregorianDate;
        }

        public static DateTime Sunrise(this SunTracker tracker, TimeSpan offset)
        {
            var sunriseUtcGregorianDate = UTCSunrise(tracker);
            var sunriseLocalGregorianDate = sunriseUtcGregorianDate.Add(offset);

            return sunriseLocalGregorianDate;
        }

        public static DateTime Sunrise(this SunTracker tracker, TimeSpan offset, bool dayLightSaving)
        {
            var sunriseUtcGregorianDate = UTCSunrise(tracker);
            var sunriseLocalGregorianDate = sunriseUtcGregorianDate.Add(offset);
            sunriseLocalGregorianDate = dayLightSaving ? sunriseLocalGregorianDate.AddHours(1) : sunriseLocalGregorianDate;

            return sunriseLocalGregorianDate;
        }

        public static DateTime UTCSunset(this SunTracker tracker)
        {
            var sunsetJulianDate = tracker.SolarTransit + (tracker.HourAngle / 360.0);
            var sunsetUtcGregorianDate = JulianDateConverter.CalculateGregorianDate(sunsetJulianDate, tracker.GregorianDate, tracker.JulianDate);
            return sunsetUtcGregorianDate;
        }

        public static DateTime Sunset(this SunTracker tracker, TimeSpan offset)
        {
            var sunriseUtcGregorianDate = UTCSunset(tracker);
            var sunrisetLocalGregorianDate = sunriseUtcGregorianDate.Add(offset);

            return sunrisetLocalGregorianDate;
        }

        public static DateTime Sunset(this SunTracker tracker, TimeSpan offset, bool dayLightSaving)
        {
            var sunriseUtcGregorianDate = UTCSunset(tracker);
            var sunrisetLocalGregorianDate = sunriseUtcGregorianDate.Add(offset);
            sunrisetLocalGregorianDate = dayLightSaving ? sunrisetLocalGregorianDate.AddHours(1) : sunrisetLocalGregorianDate;
            return sunrisetLocalGregorianDate;
        }        
    }
}