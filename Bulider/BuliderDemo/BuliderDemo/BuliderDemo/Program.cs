// See https://aka.ms/new-console-template for more information
using BuliderDemo;

Console.WriteLine("Hello, World!");

var me = Person.New
              .Called("Rohith").WithAge(20).Education("B.Tech").WorksAsA("Software")
              .Build();