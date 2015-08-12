namespace Methods
{
    using System;

    public class CartesianSpaceMethods
    {
        public static double CalculateDistance(double x1, double x2, double y1, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        public static bool HorizontalLineCheck(double x1, double x2)
        {
            bool isVertical = x1 == x2;
            return isVertical;
        }

        public static bool VerticalLineCheck(double y1, double y2)
        {
            bool isHorizontal = y1 == y2;
            return isHorizontal;
        }
    }
}
