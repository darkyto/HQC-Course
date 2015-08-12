namespace CookingApp
{
    using System;
    using System.Collections.Generic;

    public class Bowl
    {
        public const int WidthCentimetres = 25;
        public const int MaxWaterMililitres = 800;

        public Bowl()
        {
            this.Diameter = WidthCentimetres;
            this.MililitresSize = MaxWaterMililitres;
            this.Vegetables = new List<Vegetable>();
        }

        public int Diameter { get; set; }

        public int MililitresSize { get; set; }

        public List<Vegetable> Vegetables { get; private set; }

        public void Add(Vegetable vegetable) 
        {
            this.Vegetables.Add(vegetable);
        }
    }
}
