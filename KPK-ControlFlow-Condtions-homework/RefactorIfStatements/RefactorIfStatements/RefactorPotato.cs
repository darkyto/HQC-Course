namespace RefactorIfStatements
{
    using System;

    public class RefactorPotato
    {
        public static void Main()
        { 
            var potato = new Object();

            bool potatoHasBeenPeeled = false;
            bool potatoIsRotten = false;
            
            if (potato != null)
	        {
                if (potatoHasBeenPeeled && !potatoIsRotten)
                {
                    Cook(potato);
                }
                else 
                {
                    throw new Exception("Bad potato!");
                }
	        }
        }
        public static void Cook(Object vegetable) 
        {
            Console.WriteLine("Cookiiiing.. done!");
        }
    }
}
