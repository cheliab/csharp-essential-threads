using System;
using System.Threading;

namespace Threads_006
{
    /// <summary>
    /// Пример работы фонового потока
    /// </summary>
    class Program
    {
        static void WriteSecond()
        {
            // Бесконечный цикл
            while (true)
            {
                Console.WriteLine($"{new string(' ', 15)}Secondary");
                
                Thread.Sleep(500);
            }
        }
        
        static void Main(string[] args)
        {
            Thread thread = new Thread(WriteSecond);
            thread.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Primary");
                
                Thread.Sleep(500);
            }

            // Делаем второй поток фоновым
            // Он завершится не смотря на беконечный цикл внутри
            thread.IsBackground = true;
        }
    }
}

// Результат:

//                Secondary
// Primary
// Primary
//                Secondary
//                Secondary
// Primary
// Primary
//                Secondary
// Primary
//                Secondary
// Primary
//                Secondary
//                Secondary
// Primary
// Primary
//                Secondary
//                Secondary
// Primary
// Primary
//                Secondary
//                Secondary
//
// Process finished with exit code 0.
