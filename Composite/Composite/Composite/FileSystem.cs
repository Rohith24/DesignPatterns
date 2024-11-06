using System;
using System.Collections.Generic;

namespace FileSystemCompositePattern
{
    public interface IFileSystemComponent
    {
        string Name { get; }
        void Display(int indentLevel);
        long GetSize();  
    }

    public class File : IFileSystemComponent
    {
        public string Name { get; private set; }
        public long Size { get; private set; } 

        public File(string name, long size)
        {
            Name = name;
            Size = size;
        }

        public void Display(int indentLevel)
        {
            Console.WriteLine($"{new string(' ', indentLevel)}- {Name} (File, Size: {Size} bytes)");
        }

        public long GetSize()
        {
            return Size;
        }
    }

    public class Directory : IFileSystemComponent
    {
        public string Name { get; private set; }
        private List<IFileSystemComponent> _components = new List<IFileSystemComponent>();

        public Directory(string name)
        {
            Name = name;
        }

        public void Add(IFileSystemComponent component)
        {
            _components.Add(component);
        }

        public void Remove(IFileSystemComponent component)
        {
            _components.Remove(component);
        }

        public void Display(int indentLevel)
        {
            Console.WriteLine($"{new string(' ', indentLevel)}+ {Name} (Directory)");
            foreach (var component in _components)
            {
                component.Display(indentLevel + 2);
            }
        }

        public long GetSize()
        {
            long totalSize = 0;
            foreach (var component in _components)
            {
                totalSize += component.GetSize();
            }
            return totalSize;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            File file1 = new File("Document1.txt", 1500);
            File file2 = new File("Image1.png", 3000);
            File file3 = new File("Video1.mp4", 15000000);

            Directory documentsDirectory = new Directory("Documents");
            documentsDirectory.Add(file1);
            documentsDirectory.Add(file2);

            Directory videosDirectory = new Directory("Videos");
            videosDirectory.Add(file3);

            Directory mainDirectory = new Directory("My Files");
            mainDirectory.Add(documentsDirectory);
            mainDirectory.Add(videosDirectory);

            Console.WriteLine("File System Structure:");
            mainDirectory.Display(0);

            Console.WriteLine($"\nTotal Size of '{mainDirectory.Name}': {mainDirectory.GetSize()} bytes");
        }
    }
}
