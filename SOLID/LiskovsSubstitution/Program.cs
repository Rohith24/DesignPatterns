using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovsSubstitution
{
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle() { }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}:{Height}";
        }
    }

    public class Square : Rectangle
    {
        public override int Width { set { base.Width = base.Height = value; } }
        public override int Height { set { base.Width = base.Height = value; } }

    }

    public class Program
    {
        static public int Area(Rectangle r) => r.Height * r.Width;
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(0, 0);
            Console.WriteLine($"{rectangle} area is {Area(rectangle)}");

            Square square = new Square();
            square.Width = 4;
            Console.WriteLine($"{square} area is {Area(square)}");

            Console.ReadLine();
        }
    }
}
