using System;
using SolarCalculation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SolarCalculation.Test
{
    [TestClass]
    public class JulianDateTest
    {
        private TestContext testContext;

        public TestContext TestContext
        {
            get { return testContext; }
            set { testContext = value; }
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    "|DataDirectory|\\julian-date-test-data.csv", "julian-date-test-data#csv", DataAccessMethod.Sequential),
                    DeploymentItem("julian-date-test-data.csv")]
        public void CalculateGregorianDate_Test()
        {
            var jd = double.Parse(TestContext.DataRow["jd"].ToString());
            var outsetJd = double.Parse(TestContext.DataRow["outsetJD"].ToString());
            var actualDate = DateTime.Parse(TestContext.DataRow["date"].ToString());
            var outsetDate = DateTime.Parse(TestContext.DataRow["outsetDate"].ToString());

            var date = JulianDateConverter.CalculateGregorianDate(jd, outsetDate, outsetJd);

            Assert.AreEqual(date, actualDate);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\julian-date-test-data2.csv", "julian-date-test-data2#csv", DataAccessMethod.Sequential),
            DeploymentItem("julian-date-test-data2.csv")]
        public void CalculateJulianDate_Test()
        {
            var actualJD = double.Parse(TestContext.DataRow["jd"].ToString());
            var date = DateTime.Parse(TestContext.DataRow["date"].ToString()).Date;

            var jd = JulianDateConverter.CalculateJulianDate(date);

            Assert.AreEqual(jd, actualJD);
        }
    }
}
