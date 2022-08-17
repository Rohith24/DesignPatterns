using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuliderDemo
{
    public abstract class PersonBuilder : IPersonInfoBuilder
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }
}
