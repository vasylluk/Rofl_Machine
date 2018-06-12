using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rofl_Machine
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point() { X = 0; Y = 0; }
        public Point(double x) { X = x; Y = x; }
        public override string ToString() =>
            $"({X}, {Y})";
    }

    class Ellipse : IEquatable<Ellipse>, ICloneable
    {
        public Point center { get; set; }
        double a { get; set; }
        double b { get; set; }
        // формула для обчислення ексцентриситету еліпса: е = с/а, де с = а^2 - b^2
        public double Eccentricity { get => Math.Sqrt(a * a - b * b) / a; }
        public double A { get => a; }
        public double B { get => b; }
        public Point Center { get => new Point { X = center.X, Y = center.Y }; }
        //конструктор еліпса, який за замовчуванням визначає центр еліпса у початкові координат 
        public Ellipse(double A, double B)
        {
            center.X = 0;
            center.Y = 0;
            a = A;
            b = B;
        }
        public Ellipse(Point c, double A, double B) {
            center = c;
            a = A;
            b = B;
        }
        public Ellipse() { }
        //необхідно зробити функцію обчислення площі віртуальною для можливості перевизначення функії у дочірньому класі 
        public virtual double Area()
        {
            return Math.PI * this.A * this.B;
        }
        //еквівалентність перевіряється повним накладанням еліпсів
        public bool Equals(Ellipse other)
        {
            if (Center.X == other.Center.X && this == other) return true;
            return false;
        }

        public object Clone()
        {
            return new Ellipse { center = this.Center, a = this.A, b = this.B };
        }
        //перевірку належності точки еліпсу реалізовано завдяки використанню канонічного рівняння еліпса
        public bool Contains(Point p)
        {
            bool tmp = false;
            double r1 = Math.Sqrt(Math.Pow((p.X - Eccentricity * A), 2) + p.Y * p.Y) + Math.Sqrt(Math.Pow((p.X - Eccentricity * A), 2) + p.Y * p.Y);
            if (r1 == 2 * A) tmp = true;
            return tmp;
        }

        //вектор реалізовано точкою
        public static Ellipse operator +(Ellipse e, Point vect)
        {
            return new Ellipse { center = new Point { X = e.Center.X + vect.X, Y = e.Center.Y + vect.Y }, a = e.A, b = e.B };
        }
        //при стисненні/розтягненні необхідно змінити велику і малу півосі еліпса на заданий коефіцієнт
        public static Ellipse operator *(Ellipse e, double coef)
        {
            if (coef > 0)
                return new Ellipse { center = new Point { X = e.Center.X, Y = e.Center.Y }, a = e.A * coef, b = e.B * coef };
            else throw new Exception("Invalid coefficient");
        }
        //порівняння реалізовано через порівняння півосей (враховано випадки повернутих на певний кут еліпсів)
        public static bool operator ==(Ellipse e1, Ellipse e2)
        {
            bool tmp = false;
            if (e1.A == e2.A && e1.B == e2.B || e1.A == e2.B && e1.B == e2.A) tmp = true;
            return tmp;
        }

        public static bool operator !=(Ellipse e1, Ellipse e2)
        {
            return !(e1 == e2);
        }
    }
    //коло як клас-нащадок еліпса, має власну формулу для обчислення площі
    class Circle : Ellipse
    {
        double radius { get; set; }
        public double Radius { get => radius; }
        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }

        public Circle(double r, Point c)
        {
            radius = r;
            center = c;
        }

        public Circle(double r)
        {
            radius = r;
            center = new Point { X = 0, Y = 0 };
        }

    }
        
}
