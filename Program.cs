using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rofl_Machine;

namespace Rofl_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point { X = 0, Y = 0 };
            Point p2 = new Point { X = 0, Y = 5 };
            Point v1 = new Point { X = 10, Y = 10 };
            Ellipse e1 = new Ellipse(p1,10,5);
            Ellipse e2 = new Ellipse(v1,5,10);
            Circle circle = new Circle(10);
            Console.WriteLine($"e1 Area: {e1.Area()}\n");
            Console.WriteLine($"circle Area: {circle.Area()}\n");
            Console.WriteLine($"Center coordinates of e1 + v1: {(e1+v1).Center.ToString()}\n");
            Console.WriteLine($"e1 * 2: a = {(e1*2).A}, b = {(e1 * 2).B}\n");
            Console.WriteLine($"e1 Eccentricity: {e1.Eccentricity}\n");
            Console.WriteLine($"e1 == e2: {e1==e2}\n");
            Console.WriteLine($"e1 equals e2: {e1.Equals(e2)}\n");
            Console.WriteLine($"e1 Contains p2: {e1.Contains(p2)}");
            Console.ReadKey();
        }
    }
}
