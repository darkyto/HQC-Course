namespace ClassChef
{
    using System;

    public class Chef
    {
        public void Cook()
        {
            Bowl bowl = GetBowl();
            Potato potato = GetPotato();
            Carrot carrot = GetCarrot();

            this.Peel(potato);
            this.Peel(carrot);

            this.Cut(potato);
            this.Cut(carrot);

            bowl.Add(carrot);
            bowl.Add(potato);
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private void Cut(Vegetable vegetable)
        {
            Console.WriteLine("The vegetable has been CUT!");
            vegetable.IsCut = true;
        }

        private void Peel(Vegetable vegetable)
        {
            Console.WriteLine("The vegetable has been PEELED!");
            vegetable.IsPeeled = true;
        }
    }
}