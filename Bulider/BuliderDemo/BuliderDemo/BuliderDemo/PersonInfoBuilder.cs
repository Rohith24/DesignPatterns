using BuliderDemo.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuliderDemo
{
    public class PersonInfoBuilder : PersonBuilder, IPersonInfoBuilder
    {
        public IPersonInfoBuilder Called(string name)
        {
            person.Name = name;
            return this;
        }

        public IPersonInfoBuilder WithAge(int age)
        {
            person.Age = age;
            return this;
        }
    }

    public class PersonEducationBuilder : PersonInfoBuilder, IPersonEducationBuilder
    {
        public IPersonEducationBuilder Education(string education)
        {
            person.HighestEducation = education;
            return this;
        }
    }
}
