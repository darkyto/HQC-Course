namespace ClassSizeTask
{
    using System;

    public class Point
    {
        private double x;
        private double y;

        public Point(double x, double y)
        {
            this.XCoord = x;
            this.YCoord = y;
        }

        public double XCoord 
        {
            get
            {
                return this.x;
            }
            private set
            {
                this.x = value;
            }
        }
        public double YCoord
        {
            get
            {
                return this.y;
            }
            private set
            {
                this.y = value;
            }
        }

        /// <summary>
        /// Method to rotate points through angle (Cartesian system) counter-clockwise
        /// </summary>
        /// <param name="point"></param>
        /// <param name="thetaAngle"></param>
        /// <returns>New point with the new coordinates X and Y</returns>
        public static Point Rotate(Point point, double thetaAngle) 
        {
            double s = Math.Abs(Math.Sin(thetaAngle));
            double c = Math.Abs(Math.Cos(thetaAngle));

            double newXCoord = (c * point.x) - (s * point.y);
            double newYCoord = (s * point.x) + (c * point.y);

            return new Point(newXCoord, newYCoord);
        }
        /// <summary>
        /// Method to rotate a point through angle around another point in Cartesian system
        /// </summary>
        /// <param name="pointToRotate"></param>
        /// <param name="staticPoint"></param>
        /// <param name="thetaAngle"></param>
        /// <returns>New point with the new coordinates X and Y rotated around the given point</returns>
        public static Point RotateAroundPoint(Point pointToRotate, Point staticPoint, double thetaAngle)
        {
            double sina = Math.Abs(Math.Sin(thetaAngle));
            double cosina = Math.Abs(Math.Cos(thetaAngle));

            double px = pointToRotate.XCoord;
            double py = pointToRotate.YCoord;

            double ox = staticPoint.XCoord;
            double oy = staticPoint.YCoord;

            double newXCoord = (cosina * (px - ox)) - (sina * (py - oy)) + ox;
            double newYCoord = (sina * (px - ox)) + (cosina * (py - oy)) + oy;

            Point result = new Point(newXCoord, newYCoord);
            return result;
        }
        public override string ToString()
        {
            return "Point Coordinates \nX Coordinate: "+this.XCoord+"\nY Coordinate: "+this.YCoord+"\n";
        }
    }
}
