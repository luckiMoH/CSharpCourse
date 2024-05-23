using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasy
{
    class Shape
    {
        public int X {  get; set; }
        public int Y { get; set; }
        public virtual void Draw()
        {
            Console.WriteLine("Drawing shape");
        }
    }

    class Circle : Shape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing circle");

        }
    }

    class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing rectangle");
        }
    }

    class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing triangle");
        }
    }
}
