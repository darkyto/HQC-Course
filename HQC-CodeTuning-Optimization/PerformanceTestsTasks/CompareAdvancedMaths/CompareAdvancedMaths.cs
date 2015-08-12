namespace CompareAdvancedMaths
{
    using System;
    using CompareSimpleMathOperations;

    public class CompareAdvancedMaths
    {
        private const float ValueFloatToTest = 100.0F;
        private const double ValueDoubleToTest = 100.0;
        private const decimal ValueDecimalToTest = 100.0M;

        public static void Main()
        {
            CompareSimpleMaths.DrawLineOnConsole("SQUARE ROOT TESTS");
            TestMethods.TestOperation(ValueFloatToTest, Operations.Sqrt);
            TestMethods.TestOperation(ValueDoubleToTest, Operations.Sqrt);
            TestMethods.TestOperation(ValueDecimalToTest, Operations.Sqrt);

            CompareSimpleMaths.DrawLineOnConsole("NATURAL LOGARITHM TESTS");
            TestMethods.TestOperation(ValueFloatToTest, Operations.Log);
            TestMethods.TestOperation(ValueDoubleToTest, Operations.Log);
            TestMethods.TestOperation(ValueDecimalToTest, Operations.Log);

            CompareSimpleMaths.DrawLineOnConsole("SINUS TESTS");
            TestMethods.TestOperation(ValueFloatToTest, Operations.Sin);
            TestMethods.TestOperation(ValueDoubleToTest, Operations.Sin);
            TestMethods.TestOperation(ValueDecimalToTest, Operations.Sin);
        }
    }
}
