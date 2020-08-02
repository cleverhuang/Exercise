using System;

namespace Inheritance
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; }

        public override double Area => Math.Round(Math.PI * Math.Pow(Radius, 2), 2);

        public override double Perimeter => Math.Round(2 * Math.PI * Radius, 2);

        public double Circumference => Perimeter;

        public double Diameter => Radius * 2;
    }

}