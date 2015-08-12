namespace Abstraction
{
    using System;

    public class Circle : Figure, IFigure
    {
        private double radius;

        public Circle(double radius)
            : base()
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            protected set
            {
                if (double.IsNaN(value))
                {
                    throw new ArgumentNullException("Invalid input at Radius setter");
                }

                if (value <= 0f)
                {
                    throw new ArgumentOutOfRangeException("Radius of circle must be positive number");
                }

                this.radius = value;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcArea()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
