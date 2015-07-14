namespace BoolPrint
{
    using System;

    public class Conventer
    {
        private const int MaxCount = 6;

        public void BooleanToString(bool value)
        {
            string stringedBoolean = value.ToString();
            Console.WriteLine(stringedBoolean);
        }
    }
}
