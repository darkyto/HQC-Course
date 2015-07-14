namespace ClassChef
{
    using System;

    public abstract class Vegetable
    {
        public Vegetable()
        {
            this.IsPeeled = false;
            this.IsRotten = false;
            this.IsCut = false;
            this.IsCooked = false;
        }
        public bool IsPeeled { get; set; }
        public bool IsRotten { get; set; }
        public bool IsCut { get; set; }
        public bool IsCooked { get; set; }


    }
}
