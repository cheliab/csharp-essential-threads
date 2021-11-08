using System;
using System.Threading;

namespace Threads_001
{
    /// <summary>
    /// Простой пример выполнения метода в отдельном потоке
    /// </summary>
    class Program
    {
        // Метод, который будет запущен в отдельном потоке
        static void WriteSecond()
        {
            // бесконечный цикл во втором потоке
            while (true)
            {
                Console.WriteLine(new string(' ', 10) + "Secondary");                
            }
        }
        
        static void Main(string[] args)
        {
            ThreadStart writeSecond = new ThreadStart(WriteSecond);
            Thread thread = new Thread(writeSecond);
            thread.Start();

            // бесконечный цикл в основном потоке
            while (true)
            {
                Console.WriteLine("Primary");
            }
            
            // до этого места программа не дойдет
            Console.ReadLine();
        }
    }
}

// Результат:
//         Secondary
//         Secondary
//         Secondary
// Primary
// Primary
// Primary