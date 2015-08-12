namespace Abstraction
{
    using System;
    using System.Text;

    public class Rectangle : Figure, IFigure
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
            : base()
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width 
        {
            get
            {
                return this.width;
            }

            protected set
            {
                if (double.IsNaN(value))
                {
                    throw new ArgumentNullException("Invalid input at width setter");
                }

                if (value <= 0f)
                {
                    throw new ArgumentOutOfRangeException("Width of rectangle must be positive number");
                }

                this.width = value;
            }
        }

        public double Height 
        {
            get
            {
                return this.height;
            }

            protected set
            {
                if (double.IsNaN(value))
                {
                    throw new ArgumentNullException("Invalid input at height setter");
                }

                if (value <= 0f)
                {
                    throw new ArgumentOutOfRangeException("height of rectangle must be positive number");
                }

                this.height = value;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcArea()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
