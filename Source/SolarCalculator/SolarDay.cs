using System;

namespace SolarCalculation
{
    public class SunRiseSet
    {
        public DateTime Rise { get; set; }
        public DateTime Set { get; set; }        
    }
    
    public class SolarDay : SunRiseSet
    {
        public DateTime SolarNoon { get; set; }
        public TimeSpan DayLength { get; set; }        
    }

    public static class SolarDayExtensions
    {
        public static SolarDay ToSolarDay(this SunRiseSet riseSet)
        {
            var daylight = riseSet.Set.Subtract(riseSet.Rise);
            return new SolarDay
            {
                Rise = riseSet.Rise,
                Set = riseSet.Set,
                DayLength = daylight,
                SolarNoon = riseSet.Rise.AddSeconds(daylight.TotalSeconds / 2)
            };
        }
    }    
}