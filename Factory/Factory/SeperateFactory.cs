using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeperateFactoryProgram
{
    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }

    public static class PointFactory
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

    public class Point
    {
        private double x, y;

        public Point(double a, double b, CoordinateSystem coordinateSystem = CoordinateSystem.Cartesian)
        {
            x = a;
            y = b;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }
    public class FactoryPr
    {
        public void main()
        {
            var p = PointFactory.NewCaresianPoint(1, 3);
        }
    }

}
