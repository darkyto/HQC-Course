namespace ClassSizeTask
{
    using System;

    public class ConsoleTest
    {
        public static void Main()
        {
            var point = new Point(1, 2);
            var pointNew = new Point(2, 3);
            Console.WriteLine(point.ToString());

            var rotated = Point.Rotate(point, 15);
            Console.WriteLine(rotated.ToString());

            var rotatedAround = Point.RotateAroundPoint(point, pointNew, 45);
            Console.WriteLine(rotatedAround.ToString());
        }
    }
}
