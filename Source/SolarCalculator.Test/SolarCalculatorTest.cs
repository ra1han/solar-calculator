using System;
using Xunit;

namespace SolarCalculation.Test
{
    public class SolarCalculatorTest
    {
        private static readonly TimeSpan MaxTimeDifference = TimeSpan.FromMinutes(10); // This will handle near polar coordinates
        
        [Fact]
        public void FortWorthTest()
        {
            var location = new
            {
                latitude = 32.768799,
                longitude = -97.309341,
            };
            var theDate = new DateTime(2018, 1, 1);            
            var results = theDate.ToSunTimes(location.latitude, location.longitude, TimeSpan.FromHours(-6));
            var jan1 = new
            {
                Rise = new DateTime(2018, 1, 1, 7, 31, 0),
                Set = new DateTime(2018, 1, 1, 17, 35, 0)
            };
            var diffs = new
            {
                Rise = results.Local.Rise.Subtract(jan1.Rise).Duration(),
                Set = results.Local.Set.Subtract(jan1.Set).Duration()
            };
            
            Assert.True(diffs.Rise <= MaxTimeDifference, $"Difference {diffs.Rise}");
            Assert.True(diffs.Set <= MaxTimeDifference, $"Difference {diffs.Set}");
        }        
        
        [Fact]
        public void GetUtcSunRise_Test()
        {
            Assert.All("solar-calculation-test-data.csv".ReadRecords<SolarDayTest>(), record =>
            {
                var times = record.date.ToSunTimes(record.latitude, record.longitude, TimeSpan.FromHours(record.timezone), record.dst);                
                var diff = times.Local.Rise.Subtract(record.sunrise).Duration();
                Assert.True(diff <= MaxTimeDifference, $"Difference {diff}");
            });
        }

        [Fact]
        public void GetUtcSunSet_Test()
        {
            Assert.All("solar-calculation-test-data.csv".ReadRecords<SolarDayTest>(), record =>
            {
                var times = record.date.ToSunTimes(record.latitude, record.longitude, TimeSpan.FromHours(record.timezone), record.dst);
                var diff = times.Local.Set.Subtract(record.sunset).Duration();
                Assert.True(diff <= MaxTimeDifference, $"Difference {diff}");
            });
        }
    }
    
    public class SolarDayTest
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int timezone { get; set; }
        public bool dst { get; set; }
        public DateTime date { get; set; }
        public DateTime sunrise { get; set; }
        public DateTime sunset { get; set; }
    }        
}
