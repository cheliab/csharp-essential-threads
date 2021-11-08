using System;
using System.Threading;

namespace Threads_002
{
    class Program
    {
        // Статический метод, который планируется выполнять одновременно
        // в главном (первичном)
        // и во вторичном потоке.
        static void WriteSecond()
        {
            // CLR назначает каждому потоку свой стек
            // это значит что методы в них имеют свои собственные локальные переменные
            
            // Отдельный экзепляр переменной counter создается в стеке каждого потока
            int counter = 0;
            
            // Поэтому в цикле для каждого потока будут выводиться, свои значения counter
            // каждый начнется с нуля - 0, 1, 2.

            while (counter < 10)
            {
                Thread.Sleep(500); // ожидание в пол секунды для наглядности
                
                Console.WriteLine("Thread Id {0}, counter = {1}", Thread.CurrentThread.GetHashCode(), counter);
                counter++;
            }
        }
        
        static void Main(string[] args)
        {
            // Работа вторичного потока
            Thread thread = new Thread(WriteSecond);
            thread.Start();
            
            // Работа первичного потока
            WriteSecond();
            
            // В каждом из потоков своя копия метода WriteSecond
            
            Console.ReadLine();
        }
    }
}

// Результат:
// Thread Id 1, counter = 0
// Thread Id 4, counter = 0
// Thread Id 4, counter = 1
// Thread Id 1, counter = 1
// Thread Id 1, counter = 2
// Thread Id 4, counter = 2
// Thread Id 1, counter = 3
// Thread Id 4, counter = 3
// Thread Id 4, counter = 4
// Thread Id 1, counter = 4
// Thread Id 4, counter = 5
// Thread Id 1, counter = 5
// Thread Id 4, counter = 6
// Thread Id 1, counter = 6
// Thread Id 4, counter = 7
// Thread Id 1, counter = 7
// Thread Id 4, counter = 8
// Thread Id 1, counter = 8
// Thread Id 4, counter = 9
// Thread Id 1, counter = 9
