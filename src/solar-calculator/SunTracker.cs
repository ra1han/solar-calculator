using System;

namespace SolarCalculation
{
    public class SunTracker
    {
        public double SolarTransit
        {
            get
            {
                if (solarTransit != null)
                {
                    return solarTransit.Value;
                }
                meanSolarTime = meanSolarTime ?? CalculateMeanSolarTime(JulianDate, longitude);
                solarMeanAnomaly = solarMeanAnomaly ?? CalculateSolarMeanAnomaly(meanSolarTime.Value);
                eclipticLongitude = eclipticLongitude ?? CalculateEclipticLongitude(solarMeanAnomaly.Value);
                solarTransit = GetSolarTransit(meanSolarTime.Value, solarMeanAnomaly.Value, eclipticLongitude.Value);
                return solarTransit.Value;
            }
        }

        public double HourAngle
        {
            get
            {
                if (hourAngle != null)
                {
                    return hourAngle.Value;
                }
                meanSolarTime = meanSolarTime ?? CalculateMeanSolarTime(JulianDate, longitude);
                solarMeanAnomaly = solarMeanAnomaly ?? CalculateSolarMeanAnomaly(meanSolarTime.Value);
                eclipticLongitude = eclipticLongitude ?? CalculateEclipticLongitude(solarMeanAnomaly.Value);
                declinationOfSun = GetDeclinationOfSun(eclipticLongitude.Value);
                hourAngle = CalculateHourAngle(latitude, declinationOfSun.Value);

                return hourAngle.Value;
            }
        }

        public double JulianDate
        {
            get
            {
                if (julianDate == null)
                {
                    julianDate = JulianDateConverter.CalculateJulianDate(GregorianDate);
                }

                return julianDate.Value;
            }
        }

        public DateTime GregorianDate { get; private set; }

        private double? julianDate;
        private double? solarTransit;
        private double? hourAngle;

        private double? meanSolarTime;
        private double? solarMeanAnomaly;
        private double? eclipticLongitude;
        private double? declinationOfSun;
        private double latitude;
        private double longitude;

        public SunTracker(double latitude, double longitude, DateTime gregorianDate)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            GregorianDate = gregorianDate.Date;
        }

        private static double CalculateHourAngle(double latitude, double declinationOfSun)
        {
            var hourAngle = Math.Acos(
                (MathUtil.Sind(-0.83) - (MathUtil.Sind(latitude) * MathUtil.Sin(declinationOfSun))) /
                ((MathUtil.Cosd(latitude)) * MathUtil.Cos(declinationOfSun)));

            return MathUtil.RadianToDegree(hourAngle);
        }

        private static double GetDeclinationOfSun(double elipticLongitude)
        {
            return Math.Asin(MathUtil.Sind(elipticLongitude) * MathUtil.Sind(Constants.EarthMeanObliquity));
        }

        private static double GetSolarTransit(double meanSolarNoon, double solarMeanAnomaly, double elipticLongitude)
        {
            return Constants.JD02012000 + meanSolarNoon + 0.0053 * ((MathUtil.Sind(solarMeanAnomaly))) -
                   0.0069 * (MathUtil.Sind(2 * elipticLongitude));
        }

        private static double CalculateEclipticLongitude(double solarMeanAnomaly)
        {
            var equationOfCenter = CalculateEquationOfCenter(solarMeanAnomaly);
            var eclipticLongitude = CalculateEclipticLongitude(solarMeanAnomaly, equationOfCenter);

            return eclipticLongitude;
        }

        private static double CalculateSolarMeanAnomaly(double meanSolarNoon)
        {
            var solarMeanAnomaly = (357.5291 + 0.98560028 * meanSolarNoon) % 360;

            if (solarMeanAnomaly < 0)
                solarMeanAnomaly += 360;
            return solarMeanAnomaly;
        }

        private static double CalculateEclipticLongitude(double solarMeanAnomaly, double equationOfTheCenter)
        {
            var elipticLongitude = (solarMeanAnomaly + equationOfTheCenter + 180 + 102.9372) % 360;
            if (elipticLongitude < 0)
                elipticLongitude += 360;
            return elipticLongitude;
        }

        private static double CalculateEquationOfCenter(double solarMeanAnomaly)
        {
            return 1.9148 *
                   MathUtil.Sind(solarMeanAnomaly) +
                   0.02 *
                   MathUtil.Sind(2 * solarMeanAnomaly) +
                   0.0003 *
                   MathUtil.Sind(3 * solarMeanAnomaly);
        }

        private static double CalculateMeanSolarTime(double julianDate, double longitude)
        {
            var n = julianDate - Constants.JD01012000 + (68.184 / Constants.TotalDaysInYear);
            var meanSolarTime = n - (longitude / 360d);
            return meanSolarTime;
        }
    }
}
