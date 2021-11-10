using System;
using System.Threading;

namespace Thread_002_PointerExample
{
    class Program
    {
        private static void GetPointerInfo()
        {
            unsafe
            {
                var localVar = 1;
                var localPointer = &localVar; // адресс локальной переменной в памяти 
            }
        }
        
        static void Main(string[] args)
        {
            Thread thread = new Thread(GetPointerInfo);
            thread.Start();

            GetPointerInfo();
            
            Console.ReadLine();
        }
    }
}