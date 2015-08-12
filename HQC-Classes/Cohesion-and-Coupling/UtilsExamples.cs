namespace CohesionAndCoupling
{
    using System;

    internal class UtilsExamples
    {
        internal static void Main()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                DistanceCalculator.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                DistanceCalculator.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Figure3D figure = new Figure3D(3, 4, 5);
            Console.WriteLine("Figure3D Volume = {0:f2}", figure.CalcVolume());
            Console.WriteLine("Figure3D Diagonal XYZ = {0:f2}", figure.CalcDiagonalXYZ());
            Console.WriteLine("Figure3D Diagonal XY = {0:f2}", figure.CalcDiagonalXY());
            Console.WriteLine("Figure3D Diagonal XZ = {0:f2}", figure.CalcDiagonalXZ());
            Console.WriteLine("Figure3D Diagonal YZ = {0:f2}", figure.CalcDiagonalYZ());
        }
    }
}
