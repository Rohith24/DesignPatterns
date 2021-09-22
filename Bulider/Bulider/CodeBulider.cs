using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulider
{

    class PropertyBuilder
    {
        private const int indentSize = 2;

        public string Type { get; set; }
        public string Name { get; set; }

        public PropertyBuilder(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.Append($"{i}public {Type} {Name};\n");
            return sb.ToString();
        }
    }

    class CodeBuilder
    {
        public string Name { get; set; }
        public List<PropertyBuilder> Properties = new List<PropertyBuilder>();
        private const int indentSize = 2;

        public CodeBuilder(string name)
        {
            Name = name;
        }

        public CodeBuilder AddField(string name, string type)
        {
            Properties.Add(new PropertyBuilder(name, type));
            return this;
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.Append($"{i}public class {Name}\n");
            sb.Append($"{i}{{\n");

            foreach (var e in Properties)
                sb.Append(e.ToStringImpl(indent + 1));

            sb.Append($"{i}}}\n");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }

    public class MyClass
    {
        public static void Main(string[] args)
        {
            var person = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int").AddField("Gender", "string");
            Console.WriteLine(person);
            Console.ReadLine();
        }
    }
}
