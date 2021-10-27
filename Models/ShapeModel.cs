using System;

namespace ChromeShape.Models
{
    public abstract class Shape
    {
        public abstract double Area();
        public abstract double Perimeter();
    }
    public class Square : Shape
    {
        public double Side { get; set; }
        public override double Area()
        {
            return Side * Side;
        }
        public override double Perimeter()
        {
            return Side * 4;
        }
    }
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public override double Area()
        {
            return Width * Height;
        }
        public override double Perimeter()
        {
            return 2 * (Width * Height);
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double Area()
        {
            return Radius * Radius * Math.PI;
        }
        public override double Perimeter()
        {
            return 2 * Math.PI * (Radius * Radius * Math.PI);
        }
    }

    public enum ShapeType
    {
        Circle,
        Rectangle,
        Square
    }
}