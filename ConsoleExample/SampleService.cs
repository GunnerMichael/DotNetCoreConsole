using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExample
{
    public class SampleService : ISampleService
    {
        public Task DoWorkAsync()
        {
            Console.WriteLine("Doing stuff in sample service");

            return Task.CompletedTask;
        }
    }
}
