using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibility
{
    /// <summary>
    /// Only stores journal details
    /// Here we are not operating on journal. 
    /// </summary>
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;
        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

    }

    /// <summary>
    /// To make operations on journal
    /// </summary>
    public class Persistence
    {
        public void SaveToFile(Journal j, string fileName, bool overwrite = false)
        {
            if (overwrite || !File.Exists(fileName))
            {
                File.WriteAllText(fileName, j.ToString());
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("This is one journal");
            j.AddEntry("restrict single responsibility");
            Console.WriteLine(j.ToString());

            var p = new Persistence();
            var filename = Environment.CurrentDirectory + "\\single.txt";
            p.SaveToFile(j, filename, true);
            Process.Start(filename);
        }
    }
}
