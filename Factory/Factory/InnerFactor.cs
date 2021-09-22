using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnerFactory
{

    public class Point
    {
        private double x, y;

        private Point(double a, double b)
        {
            x = a;
            y = b;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

        public static Point Orgin => new Point(0, 0);
        public static Point Orgin2 = new Point(0, 0);

        public static class Factory
        {
            public static Point NewCaresianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }

    }
    public class FactoryPr
    {
        public void main()
        {
            var p = Point.Factory.NewCaresianPoint(1, 3);
            var q = Point.Factory.NewPolarPoint(1, 60);


        }
    }

}
