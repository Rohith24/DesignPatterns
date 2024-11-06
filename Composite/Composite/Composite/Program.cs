using System;
using System.Collections.Generic;

namespace CompositePatternExample
{
    public interface IOrganizationComponent
    {
        string Name { get; }
        string Position { get; }
        double Budget { get; }

        string GetDetails();  
        double CalculateTotalBudget();  
    }

    public class Employee : IOrganizationComponent
    {
        public string Name { get; private set; }
        public string Position { get; private set; }
        public double Budget { get; private set; }

        public Employee(string name, string position, double salary)
        {
            Name = name;
            Position = position;
            Budget = salary;
        }

        public string GetDetails()
        {
            return $"Employee: {Name}, Position: {Position}, Salary: {Budget:C}";
        }

        public double CalculateTotalBudget()
        {
            return Budget;
        }
    }

    public class Manager : IOrganizationComponent
    {
        public string Name { get; private set; }
        public string Position { get; private set; }
        public double Budget { get; private set; }

        public Manager(string name, string position, double salary)
        {
            Name = name;
            Position = position;
            Budget = salary;
        }

        public string GetDetails()
        {
            return $"Manager: {Name}, Position: {Position}, Salary: {Budget:C}";
        }

        public double CalculateTotalBudget()
        {
            return Budget;
        }
    }

    public class TeamLead : IOrganizationComponent
    {
        public string Name { get; private set; }
        public string Position { get; private set; }
        public double Budget { get; private set; }

        public TeamLead(string name, string position, double salary)
        {
            Name = name;
            Position = position;
            Budget = salary;
        }

        public string GetDetails()
        {
            return $"Team Lead: {Name}, Position: {Position}, Salary: {Budget:C}";
        }

        public double CalculateTotalBudget()
        {
            return Budget;
        }
    }

    public class Department : IOrganizationComponent
    {
        public string Name { get; private set; }
        public string Position { get; private set; }
        public double Budget { get; private set; }

        private List<IOrganizationComponent> _components = new List<IOrganizationComponent>();

        public Department(string name, double salary)
        {
            Name = name;
            Position = "Department";
            Budget = salary;
        }

        public void Add(IOrganizationComponent component)
        {
            _components.Add(component);
        }

        public void Remove(IOrganizationComponent component)
        {
            _components.Remove(component);
        }

        public string GetDetails()
        {
            return $"Department: {Name}, Overhead Cost: {Budget:C}";
        }

        public double CalculateTotalBudget()
        {
            double total = Budget;
            foreach (var component in _components)
            {
                total += component.CalculateTotalBudget();
            }
            return total;
        }
    }

    public class Project : IOrganizationComponent
    {
        public string Name { get; private set; }
        public string Position { get; private set; }
        public double Budget { get; private set; }  

        private List<IOrganizationComponent> _components = new List<IOrganizationComponent>();

        public Project(string projectName, double budget)
        {
            Name = projectName;
            Position = "Project";
            Budget = budget;
        }

        public void Add(IOrganizationComponent component)
        {
            _components.Add(component);
        }

        public void Remove(IOrganizationComponent component)
        {
            _components.Remove(component);
        }

        public string GetDetails()
        {
            return $"Project: {Name}, Budget: {Budget:C}";
        }

        public double CalculateTotalBudget()
        {
            double total = Budget;
            foreach (var component in _components)
            {
                total += component.CalculateTotalBudget();
            }
            return total;
        }
    }

    public class Program
    {
        public static void Main1(string[] args)
        {
            Employee emp1 = new Employee("E1", "Software Engineer", 60000);
            Employee emp2 = new Employee("E2", "QA Engineer", 55000);
            Manager manager1 = new Manager("M1", "Engineering Manager", 100000);
            TeamLead lead1 = new TeamLead("L1", "Frontend Lead", 75000);

            Department engineering = new Department("Department1", 20000);
            Project projectAlpha = new Project("Project 1", 15000);

            engineering.Add(emp1);
            engineering.Add(emp2);
            engineering.Add(manager1);
            engineering.Add(lead1);
            engineering.Add(projectAlpha);

            projectAlpha.Add(emp1); 
            projectAlpha.Add(lead1); 

            Department company = new Department("Company", 50000);
            company.Add(engineering);

            Console.WriteLine(company.GetDetails());
            Console.WriteLine("Total Cost: " + company.CalculateTotalBudget().ToString("C"));
        }
    }
}
