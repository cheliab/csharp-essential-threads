using System;
using System.Threading;

namespace Threads_005
{
    /// <summary>
    /// Использование анонимных методов и лямбда выражений
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            
            Thread threadOne = new Thread(delegate() { Console.WriteLine($"1. counter = {++counter}"); });
            threadOne.Start();
            
            Thread.Sleep(100);
            Console.WriteLine($"2. counter = {counter}");

            Thread threadTwo = new Thread((object argument) => { Console.WriteLine($"3. counter = {(int)argument}"); });
            threadTwo.Start(counter);
            
            Console.ReadLine();
        }
    }
}