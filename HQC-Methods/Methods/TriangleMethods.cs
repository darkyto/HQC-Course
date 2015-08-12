namespace Methods
{
    using System;

    public static class TriangleMethods
    {
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            try
            {
                a = Convert.ToDouble(a);
                b = Convert.ToDouble(b);
                c = Convert.ToDouble(c);
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid input at CalculateTriangleArea(a, b, c)");
            }

            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive number.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }
    }
}
