using System;

namespace SolarCalculation
{
    public class SolarCalculator
    {
        private SunTracker sunTracker;

        public SolarCalculator(double latitude, double longitude, DateTime gregorianDate)
        {
            sunTracker = new SunTracker(latitude, longitude, gregorianDate);
        }

        public DateTime GetUtcSunRise()
        {

            var sunriseJulianDate = sunTracker.SolarTransit - (sunTracker.HourAngle / 360.0);
            var sunriseUtcGregorianDate = JulianDateConverter.CalculateGregorianDate(sunriseJulianDate, sunTracker.GregorianDate, sunTracker.JulianDate);
            return sunriseUtcGregorianDate;
        }

        public DateTime GetSunRise(int timeZone)
        {
            var sunriseUtcGregorianDate = GetUtcSunRise();
            var sunriseLocalGregorianDate = sunriseUtcGregorianDate.AddHours(timeZone);

            return sunriseLocalGregorianDate;
        }

        public DateTime GetSunRise(int timeZone, bool dayLightSaving)
        {
            var sunriseUtcGregorianDate = GetUtcSunRise();
            var sunriseLocalGregorianDate = sunriseUtcGregorianDate.AddHours(timeZone);
            sunriseLocalGregorianDate = dayLightSaving ? sunriseLocalGregorianDate.AddHours(1) : sunriseLocalGregorianDate;

            return sunriseLocalGregorianDate;
        }

        public DateTime GetUtcSunSet()
        {
            var sunsetJulianDate = sunTracker.SolarTransit + (sunTracker.HourAngle / 360.0);
            var sunsetUtcGregorianDate = JulianDateConverter.CalculateGregorianDate(sunsetJulianDate, sunTracker.GregorianDate, sunTracker.JulianDate);

            return sunsetUtcGregorianDate;
        }

        public DateTime GetSunSet(int timeZone)
        {
            var sunriseUtcGregorianDate = GetUtcSunSet();
            var sunrisetLocalGregorianDate = sunriseUtcGregorianDate.AddHours(timeZone);

            return sunrisetLocalGregorianDate;
        }

        public DateTime GetSunSet(int timeZone, bool dayLightSaving)
        {
            var sunriseUtcGregorianDate = GetUtcSunSet();
            var sunrisetLocalGregorianDate = sunriseUtcGregorianDate.AddHours(timeZone);
            sunrisetLocalGregorianDate = dayLightSaving ? sunrisetLocalGregorianDate.AddHours(1) : sunrisetLocalGregorianDate;

            return sunrisetLocalGregorianDate;
        }
    }
}