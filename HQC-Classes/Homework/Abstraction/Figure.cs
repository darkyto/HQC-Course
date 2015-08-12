namespace Abstraction
{
    using System;
    using System.Text;

    public abstract class Figure : IFigure
    {
        public Figure()
        {
        }

        public abstract double CalcPerimeter();

        public abstract double CalcArea();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Figure of type: [{0}]", this.GetType().Name);
            sb.AppendLine();
            sb.AppendFormat(" {0} area: {1:F3}", this.GetType().Name, this.CalcArea());
            sb.AppendLine();
            sb.AppendFormat(" {0} perimeter: {1:F3}", this.GetType().Name, this.CalcPerimeter());
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
