using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuliderDemo
{
    public class Director
    {
        public class Builder : PersonInfoBuilder<Builder>
        {
            internal Builder() { }
        }

        public static Builder FluentBuilder => new Builder();

        public static Builder Builder => new Builder();
    }
}
