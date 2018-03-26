using System;
using Xunit;

namespace SolarCalculation.Test
{
    public class SolarCalculatorTest
    {
        private static readonly TimeSpan MaxTimeDifference = TimeSpan.FromMinutes(10); // This will handle near polar coordinates
        
        [Fact]
        public void GetUtcSunRise_Test()
        {
            Assert.All("solar-calculation-test-data.csv".ReadRecords<SolarDayTest>(), record =>
            {
                var times = record.date.Times(record.latitude, record.longitude, TimeSpan.FromHours(record.timezone), record.dst);                
                var diff = times.Local.Rise.Subtract(record.sunrise).Duration();
                Assert.True(diff <= MaxTimeDifference, "Difference " + diff);              
            });
        }

        [Fact]
        public void GetUtcSunSet_Test()
        {
            Assert.All("solar-calculation-test-data.csv".ReadRecords<SolarDayTest>(), record =>
            {
                var times = record.date.Times(record.latitude, record.longitude, TimeSpan.FromHours(record.timezone), record.dst);
                var diff = times.Local.Set.Subtract(record.sunset).Duration();
                Assert.True(diff <= MaxTimeDifference, "Difference " + diff);                
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
