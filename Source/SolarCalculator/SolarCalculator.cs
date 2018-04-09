using System;

namespace SolarCalculation
{
    public static class SolarCalculator
    {
        public static SunTimes ToSunTimes(this DateTime timeStamp, double latitude, double longitude, TimeSpan? offset = null, bool dst = false)
        {
            return GetSunTimes(latitude, longitude, timeStamp, offset, dst);
        }

        private static SunTimes GetSunTimes(double latitude, double longitude, DateTime? dateTime = null, TimeSpan? offset = null, bool dst = false)
        {
            var timeStamp = dateTime ?? DateTime.UtcNow;
            var zoneOffset = offset ?? TimeSpan.Zero;
            
            var tracker = new SunTracker(latitude, longitude, timeStamp);
                  
            return new SunTimes
            {
                Local = new SunRiseSet
                {
                    Rise = tracker.Sunrise(zoneOffset, dst),
                    Set = tracker.Sunset(zoneOffset, dst)
                }.ToSolarDay(),
                UTC =  new SunRiseSet
                {
                    Rise = tracker.UtcSunrise(),
                    Set = tracker.UtcSunset()
                }.ToSolarDay(),             
            };
        }
    }
}