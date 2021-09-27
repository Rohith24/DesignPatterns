using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory2Program
{
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Consumed");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Consumed coffee");

        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Put tea bag, water, '{amount}'");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Put tea bag, water, '{amount}'");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        //public enum AvailableDrink
        //{
        //    Coffee, Tea
        //}

        //private Dictionary<AvailableDrink, IHotDrinkFactory> factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();

        //public HotDrinkMachine()
        //{
        //    foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
        //    {
        //        var factory = (IHotDrinkFactory)Activator.CreateInstance(Type.GetType("AbstractFactoryProgram." + Enum.GetName(typeof(AvailableDrink), drink)));
        //        factories.Add(drink, factory);
        //    }
        //}

        //public IHotDrink MakeDrink(AvailableDrink drink, int amount)
        //{
        //    return factories[drink].Prepare(amount);
        //}

        private List<Tuple<string, IHotDrinkFactory>> facotries = new List<Tuple<string, IHotDrinkFactory>>();

        public HotDrinkMachine()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    facotries.Add(Tuple.Create(t.Name.Replace("Factory", string.Empty), (IHotDrinkFactory)Activator.CreateInstance(t)));
                }
            }
        }

        public IHotDrink MakeDrink()
        {
            Console.Write("Avaolable drinks:");
            for (int i = 0; i < facotries.Count; i++)
            {
                Tuple<string, IHotDrinkFactory> tuple = facotries[i];
                Console.WriteLine($"{i}: {tuple.Item1}");
            }

            while (true)
            {
                string s;
                if ((s = Console.ReadLine()) != null && int.TryParse(s, out int i2) && i2 >= 0 && i2 < facotries.Count)
                {
                    Console.WriteLine("Specify AMount:");
                    s = Console.ReadLine();
                    if (s != null && int.TryParse(s, out int amount) && amount > 0)
                    {
                        return facotries[i2].Item2.Prepare(amount);
                    }
                }
                Console.WriteLine("In correct input");
            }
        }

    }


    class MyProgram
    {
        static void Main21()
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink();
            drink.Consume();
        }
    }



}
