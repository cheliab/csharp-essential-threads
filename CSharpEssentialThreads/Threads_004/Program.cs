using System;
using System.Threading;

namespace Threads_004
{
    /// <summary>
    /// Пример передачи параметра в поток
    /// </summary>
    class Program
    {
        // Передаем строку в поток
        static void WriteSecond(object argument)
        {
            Console.WriteLine(argument);
        }

        // Передаем класс в поток
        static void WriteThirdWithClass(object threadClassArgument)
        {
            ThreadArgumentClass a = (ThreadArgumentClass)threadClassArgument;
            Console.WriteLine($"{a.FirstParam}");
            Console.WriteLine($"{a.SecondParam}");
        }
        
        static void Main(string[] args)
        {
            // Второй поток с передачей строки
            ParameterizedThreadStart writeSecond = new ParameterizedThreadStart(WriteSecond);
            Thread thread = new Thread(writeSecond);
            thread.Start("Hello");
            
            Thread.Sleep(500);

            // Третий поток с передачей класса
            ParameterizedThreadStart writeThird = new ParameterizedThreadStart(WriteThirdWithClass);
            Thread threadThird = new Thread(writeThird);
            threadThird.Start(new ThreadArgumentClass());
            
            Console.ReadLine();
        }
    }

    class ThreadArgumentClass
    {
        public string FirstParam = "first param value";
        public string SecondParam = "second param value";
    }
}

// Результат:

// Hello
// first param value
// second param value
