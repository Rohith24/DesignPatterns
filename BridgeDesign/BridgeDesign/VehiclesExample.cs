using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDesign
{
    public abstract class Vehicle
    {
        protected IWorkshop Workshop1;
        protected IWorkshop Workshop2;

        public Vehicle(IWorkshop workshop1, IWorkshop workshop2)
        {
            this.Workshop1 = workshop1;
            this.Workshop2 = workshop2;
        }

        abstract public void Manufacture();
    }

    public class Car : Vehicle
    {
        public Car(IWorkshop workshop1, IWorkshop workshop2): base(workshop1, workshop2) 
        {

        }

        public override void Manufacture()
        {
            Console.WriteLine("Car");
            Workshop1.Work();
            Workshop2.Work();
        }
    }


    public class Bike : Vehicle
    {
        public Bike(IWorkshop workshop1, IWorkshop workshop2) : base(workshop1, workshop2)
        {

        }

        public override void Manufacture()
        {
            Console.WriteLine("Bike");
            Workshop1.Work();
            Workshop2.Work();
        }
    }

    public interface IWorkshop
    {
        public void Work();
    }


    public class ProduceParts : IWorkshop
    {
        public void Work()
        {
            Console.WriteLine("Produced Parts");
        }
    }

    public class AssembleParts : IWorkshop
    {
        public void Work()
        {
            Console.WriteLine("Assembled Parts");
        }
    }


    public class VehiclesExample
    {
        static void Main(string[] args)
        {
            Vehicle vehicle1 = new Car(new ProduceParts(), new AssembleParts());
            vehicle1.Manufacture();
            Vehicle vehicle2 = new Bike(new ProduceParts(), new AssembleParts());
            vehicle2.Manufacture();
        }
    }
}
