using System;
using System.Threading.Tasks;

namespace ConsoleExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new Bootstrapper().Run(args);
        }
    }
}
