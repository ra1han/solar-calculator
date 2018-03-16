using System;

namespace SolarCalculation
{
    public static class MathUtil
    {
        public static double Sin(double angleRadian)
        {
            return Math.Sin(angleRadian);
        }
        public static double Sind(double angleDegree)
        {
            return Math.Sin(DegreeToRadian(angleDegree));
        }
        public static double Cosd(double angleDegree)
        {
            return Math.Cos(DegreeToRadian(angleDegree));
        }
        public static double Cos(double angleRadian)
        {
            return Math.Cos(angleRadian);
        }
        static public double DegreeToRadian(double angleDegree)
        {
            return (Math.PI * angleDegree / 180.0);
        }
        static public double RadianToDegree(double angleRadian)
        {
            return (180.0 * angleRadian / Math.PI);
        }
    }
}
