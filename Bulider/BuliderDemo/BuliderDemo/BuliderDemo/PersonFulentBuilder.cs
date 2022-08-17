using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuliderDemo.Fluent
{
    public class PersonInfoBuilder<SELF> : PersonBuilder where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }

        public SELF WithAge(int age)
        {
            person.Age = age;
            return (SELF)this;
        }
    }

    public class PersonEducationBuilder<SELF>
     : PersonInfoBuilder<PersonEducationBuilder<SELF>>
     where SELF : PersonEducationBuilder<SELF>
    {
        public SELF Education(string education)
        {
            person.HighestEducation = education;
            return (SELF)this;
        }
    }


    public class PersonJobBuilder<SELF>
     : PersonEducationBuilder<PersonJobBuilder<SELF>>
     where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAsA(string job)
        {
            person.Job = job;
            return (SELF)this;
        }
    }

}
