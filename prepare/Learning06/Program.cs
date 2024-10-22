using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        Square shape1 = new Square("Green",15);
        shapes.Add(shape1);
        Rectangle shape2 = new Rectangle("Red",10,15);
        shapes.Add(shape2);
        Circle shape3 = new Circle("Blue",12);
        shapes.Add(shape3);

        foreach(Shape sh in shapes){
            string color = sh.GetColor();
            double area = sh.GetArea();
            Console.WriteLine($"The {color} shape has an area of {area}");
        }
    }
}