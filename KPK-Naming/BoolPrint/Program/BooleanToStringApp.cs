namespace BoolPrint
{
    using System;

    public class BooleanToStringApp
    {
        public static void Main()
        {
            Conventer conventer = new Conventer();
            conventer.BooleanToString(true);
            conventer.BooleanToString(false);
        }
    }
}
