using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Adapter
{
    interface IPoint
    {
        void Draw();
    }

    public class Point : IPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(".");
        }
    }

    public class Line
    {
        public Point Start, End;

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public void Draw()
        {
            Start.Draw();
            End.Draw();
        }
    }
    public interface IRectangle
    {
        void DrawRectangle();
    }

    public class Rectangle : IRectangle
    {
        public List<Line> lines;

        public Rectangle(int x, int y, int width, int height)
        {
            lines = new List<Line>();
            lines.Add(new Line(new Point(x, y), new Point(x + width, y)));
            lines.Add(new Line(new Point(x + width, y), new Point(x + width, y + height)));
            lines.Add(new Line(new Point(x, y), new Point(x, y + height)));
            lines.Add(new Line(new Point(x, y + height), new Point(x + width, y + height)));
        }

        public void DrawRectangle()
        {
            foreach (var line in lines)
            {
                line.Draw();
            }
           
        }
    }

    public class LineToPointAdapter : IPoint
    {
        List<Point> points;
        public LineToPointAdapter(Line line)
        {
            points = new List<Point>();
            //Console.WriteLine($"\n{++count}: Generating points for line [{line.Start}, {line.End}]");
            int left = Math.Min(line.Start.X, line.End.X);
            int right = Math.Max(line.Start.X, line.End.X);
            int top = Math.Min(line.Start.Y, line.End.Y);
            int bottom = Math.Max(line.Start.Y, line.End.Y);
            int dx = right - left;
            int dy = line.End.Y - line.Start.Y;

            if (dx == 0)
            {
                for (int y = top; y <= bottom; ++y)
                {
                    points.Add(new Point(left, y));
                }
            }
            else if (dy == 0)
            {
                for (int x = left; x <= right; ++x)
                {
                    points.Add(new Point(x, top));
                }
            }
        }

        public void Draw()
        {
            foreach (var point in points)
            {
                point.Draw();
            }
        }
    }

    public class AdpterDemo
    {
        static void Main(string[] args)
        {
            var rect = new Rectangle(1, 1, 10, 10);
            rect.DrawRectangle();
            foreach (var line in rect.lines)
            {
                var adapter = new LineToPointAdapter(line);
                adapter.Draw();
            }
            Console.SetCursorPosition(1, 30);
        }
    }
}
