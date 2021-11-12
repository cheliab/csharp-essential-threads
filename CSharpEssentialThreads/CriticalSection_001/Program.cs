using System;
using System.Threading;

// Критичейская секция (critical section)

// lock - блокирует участов кода, чтобы его мог выполнить только 1 поток
// остальные потоки будут ждать

namespace CriticalSection_001
{
    class ClassWithCriticalSection
    {
        /// <summary>
        /// Объект блокировки (объект синхронизации доступа к разделяемуму ресурсу)
        /// </summary>
        private object block = new object();

        public void MethodWithCriticalSection()
        {
            int threadHash = Thread.CurrentThread.GetHashCode();

            lock (block)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine();
                    
                    Thread.Sleep(100);
                }
                
                Console.WriteLine(new string('-', 20));
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            
            
            Console.ReadLine();
        }
    }
}