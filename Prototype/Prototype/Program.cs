using System;
using System.Collections.Generic;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var r1 = new HRobot("1", 100, 1000, 23);
            r1.Name = "Rohith";
            r1.Names = new List<string> { "Challa", "Rohith" };
            var r2 = (HRobot)r1.Clone();
            Console.WriteLine("Name: " + r1.Name);
            Console.WriteLine("Name: " + r2.Name);
            r2.Name = "Sunny";
            r2.Names[1] = "Rohit";
            Console.WriteLine("Name: " + r1.Name + r1.Names[0] + r1.Names[1]);
            Console.WriteLine("Name: " + r2.Name + r2.Names[0] + r2.Names[1]);
            Console.WriteLine("Hello World!");
        }
    }

    public class Robot : ICloneable
    {

        public Robot()
        {

        }
        public Robot(string id, int rAM, int rOM)
        {
            Id = id;
            RAM = rAM;
            ROM = rOM;
        }

        public string Id { get; set; }
        public int RAM { get; set; }
        public int ROM { get; set; }

        public virtual object Clone()
        {
            return new Robot(Id, RAM, ROM);
        }
    }

    public class HRobot : Robot
    {
        public HRobot(int a)
        {
        }

        public HRobot(string id, int rAM, int rOM, int a) : base(id, rAM, rOM)
        {
            A = a;
        }

        public String Name { get; set; }
        public List<string> Names { get; set; }

        public int A { get; set; }

        public override object Clone()
        {
            var n = new HRobot(Id, RAM, ROM, A);
            n.Name = Name;
            n.Names = new List<string>();
            foreach (var name in Names)
            {
                n.Names.Add(name);
            }
            return n;
        }

    }
}
