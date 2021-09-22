using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFactorProgram
{
    public class Foo
    {
        private Foo()
        {

        }

        private async Task<Foo> InitAsync()
        {
            await Task.Delay(1000);
            return this;
        }

        public static Task<Foo> CreateAsync()
        {
            var result = new Foo();
            return result.InitAsync();
        }
    }

    public class AsyncMain
    {

        public static async Task Main2()
        {
            Foo x = await Foo.CreateAsync();

        }
    }


}
