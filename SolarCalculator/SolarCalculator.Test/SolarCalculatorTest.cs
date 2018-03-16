using System;
using SolarCalculation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SolarCalculation.Test
{
    [TestClass]
    public class SolarCalculatorTest
    {
        private TestContext testContext;

        public TestContext TestContext
        {
            get { return testContext; }
            set { testContext = value; }
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    "|DataDirectory|\\solar-calculation-test-data.csv", "solar-calculation-test-data#csv", DataAccessMethod.Sequential),
                    DeploymentItem("solar-calculation-test-data.csv")]
        public void GetUtcSunRise_Test()
        {
            var lat = double.Parse(TestContext.DataRow["latitude"].ToString());
            var longt = double.Parse(TestContext.DataRow["logitude"].ToString());
            var timeZone = int.Parse(TestContext.DataRow["timezone"].ToString());
            var dst = Int32.Parse(TestContext.DataRow["dst"].ToString()) == 1 ? true : false;
            var date = DateTime.Parse(TestContext.DataRow["date"].ToString());
            var expectedSunrise = DateTime.Parse(TestContext.DataRow["sunrise"].ToString());

            var solarCalc = new SolarCalculator(lat, longt, date);
            var actualSunrise = solarCalc.GetSunRise(timeZone, dst);
            actualSunrise = actualSunrise.AddSeconds(-actualSunrise.Second);

            var diffSeconds = Math.Abs((actualSunrise - expectedSunrise).TotalSeconds);

            Assert.IsTrue(diffSeconds <= 120, "Difference " + diffSeconds);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\solar-calculation-test-data.csv", "solar-calculation-test-data#csv", DataAccessMethod.Sequential),
            DeploymentItem("solar-calculation-test-data.csv")]
        public void GetUtcSunSet_Test()
        {
            var lat = double.Parse(TestContext.DataRow["latitude"].ToString());
            var longt = double.Parse(TestContext.DataRow["logitude"].ToString());
            var timeZone = int.Parse(TestContext.DataRow["timezone"].ToString());
            var dst = Int32.Parse(TestContext.DataRow["dst"].ToString()) == 1 ? true : false;
            var date = DateTime.Parse(TestContext.DataRow["date"].ToString());
            var expectedSunset = DateTime.Parse(TestContext.DataRow["sunset"].ToString());

            var solarCalc = new SolarCalculator(lat, longt, date);
            var actualSunset = solarCalc.GetSunSet(timeZone, dst);
            actualSunset = actualSunset.AddSeconds(-actualSunset.Second);

            var diffSeconds = Math.Abs((actualSunset - actualSunset).TotalSeconds);

            Assert.IsTrue(diffSeconds <= 120, "Difference " + diffSeconds);
        }
    }
}
