using System;

namespace SolarCalculation
{
    public static class SolarCalculator
    {
        public static SunTimes Times(this DateTime timestamp, double latitude, double longitude, TimeSpan? offset = null, bool dst = false)
        {
            return Times(latitude, longitude, timestamp, offset, dst);
        }
        
        public static SunTimes Times(double latitude, double longitude, DateTime? theDate = null, TimeSpan? offset = null, bool dst = false)
        {
            var timestamp = theDate ?? DateTime.UtcNow;
            var zoneOffset = offset ?? TimeSpan.Zero;
            
            var tracker = new SunTracker(latitude, longitude, timestamp);
                  
            return new SunTimes
            {
                Local = new SunRiseSet
                {
                    Rise = tracker.Sunrise(zoneOffset, dst),
                    Set = tracker.Sunset(zoneOffset, dst)
                }.ToSolarDay(),
                UTC =  new SunRiseSet
                {
                    Rise = tracker.UTCSunrise(),
                    Set = tracker.UTCSunset()
                }.ToSolarDay(),             
            };
        }
    }
}