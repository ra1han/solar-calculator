using System;
using Xunit;

namespace SolarCalculation.Test
{
    public class JulianDateTest
    {
        [Fact]
        public void CalculateGregorianDate_Test()
        {
            Assert.All("julian-date-test-data.csv".ReadRecords<JD_DateTest>(), record =>
            {
                var date = JulianDateConverter.CalculateGregorianDate(record.jd, record.outsetDate, record.outsetJD);
                Assert.Equal(date, record.date);                
            });
        }

        [Fact]
        public void CalculateJulianDate_Test()
        {
            Assert.All("julian-date-test-data2.csv".ReadRecords<JD_SimpleDateTest>(), record =>
            {
                var jd = JulianDateConverter.CalculateJulianDate(record.date);                
                Assert.Equal(jd, record.jd);
            });            
        }
    }

    public class JD_SimpleDateTest
    {
        public double jd { get; set; }
        public DateTime date { get; set; }        
    }    
    
    public class JD_DateTest : JD_SimpleDateTest
    {
        public double outsetJD { get; set; }
        public DateTime outsetDate { get; set; }
    }
}
