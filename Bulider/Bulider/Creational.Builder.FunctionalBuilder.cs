using System;
using System.Collections.Generic;

namespace DotNetDesignPatternDemos.Creational.Builder
{
    public class Person
    {
        public string Name, Position;
    }

    public sealed class PersonBuilder
    {
        public readonly List<Action<Person>> Actions
          = new List<Action<Person>>();

        public PersonBuilder Called(string name)
        {
            Actions.Add(p => { p.Name = name; });
            return this;
        }

        public Person Build()
        {
            var p = new Person();
            Actions.ForEach(a => a(p));
            return p;
        }
    }

    public static class PersonBuilderExtensions
    {
        public static PersonBuilder WorksAsA
          (this PersonBuilder builder, string position)
        {
            builder.Actions.Add(p =>
            {
                p.Position = position;
            });
            return builder;
        }
    }

    //public class FunctionalBuilder
    //{
    //    public static void Main(string[] args)
    //    {
    //        var pb = new PersonBuilder();
    //        var person = pb.Called("Dmitri").WorksAsA("Programmer").Build();
    //    }
    //}
}


namespace OldWay
{
    public class Person
    {
        public string Name, Position;
    }

    public sealed class PersonBuilder
    {
        private readonly List<Func<Person, Person>> Actions
          = new List<Func<Person, Person>>();

        public PersonBuilder Called(string name) => Do(p => p.Name = name);
        public PersonBuilder Do(Action<Person> action) => AddAction(action);

        public Person Bulid()
        {
            var p = new Person();
            Actions.ForEach(a => a(p));
            return p;
        }

        public PersonBuilder AddAction(Action<Person> action)
        {
            Actions.Add(p => { action(p); return p; });
            return this;
        }

        public Person Build()
        {
            var p = new Person();
            Actions.ForEach(a => a(p));
            return p;
        }
    }
}

namespace OldWayAnother
{
    public class Person
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Position: {Position}";
        }
    }

    public abstract class FunctionalBulider<TSubject, TSelf> where TSelf : FunctionalBulider<TSubject, TSelf>
        where TSubject : new()
    {
        private readonly List<Action<TSubject>> Actions
          = new List<Action<TSubject>>();

        public TSelf AddField(string name, string value)
        {
            Actions.Add(p =>
            {
                p.GetType().GetProperty(name).SetValue(p, value, null);

            });
            return (TSelf)this;
        }

        public TSubject Build()
        {
            var p = new TSubject();
            Actions.ForEach(a => a(p));
            return p;
        }

        public TSelf AddAction(Action<TSubject> action)
        {
            Actions.Add(action);
            return (TSelf)this;
        }

    }

    public sealed class PersonBuilder : FunctionalBulider<Person, PersonBuilder>
    {

    }

    public class FunctionalBuilder
    {
        //public static void Main(string[] args)
        //{
        //    var pb = new PersonBuilder();
        //    var person = pb.AddField("Name", "Dmitri").Build();
        //    Console.WriteLine(person);
        //    Console.ReadLine();
        //}
    }
}