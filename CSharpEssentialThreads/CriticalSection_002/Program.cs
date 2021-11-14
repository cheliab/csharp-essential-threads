using System;
using System.Threading;

// Использование класса Monitor в место lock
// lock компилируется в Monitor
namespace CriticalSection_002
{
    class ClassWithMonitor
    {
        private object locker = new object();

        public void MethodWithMonitor()
        {
            int threadHash = Thread.CurrentThread.GetHashCode();
            
            Monitor.Enter(locker); // Блокируем участок кода (устанавливает в locker значение null)

            for (int counter = 0; counter < 10; counter++)
            {
                Console.WriteLine($"Поток № {threadHash}: шаг {counter}");
                Thread.Sleep(200);
            }
            Console.WriteLine(new string('-', 20));
            
            Monitor.Exit(locker); // Если забыть выйти, остальные потоки не смогут выполнить этот участок кода
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var classWithMonitor = new ClassWithMonitor();
            
            for (int i = 0; i < 3; i++)
            {
                new Thread(classWithMonitor.MethodWithMonitor).Start();
            }
            
            Console.ReadLine();
        }
    }
}

// Результат:
// Аналогично использованию lock все потоки идут по порядку

// Поток № 4: шаг 0
// Поток № 4: шаг 1
// Поток № 4: шаг 2
// Поток № 4: шаг 3
// Поток № 4: шаг 4
// Поток № 4: шаг 5
// Поток № 4: шаг 6
// Поток № 4: шаг 7
// Поток № 4: шаг 8
// Поток № 4: шаг 9
// --------------------
// Поток № 6: шаг 0
// Поток № 6: шаг 1
// Поток № 6: шаг 2
// Поток № 6: шаг 3
// Поток № 6: шаг 4
// Поток № 6: шаг 5
// Поток № 6: шаг 6
// Поток № 6: шаг 7
// Поток № 6: шаг 8
// Поток № 6: шаг 9
// --------------------
// Поток № 5: шаг 0
// Поток № 5: шаг 1
// Поток № 5: шаг 2
// Поток № 5: шаг 3
// Поток № 5: шаг 4
// Поток № 5: шаг 5
// Поток № 5: шаг 6
// Поток № 5: шаг 7
// Поток № 5: шаг 8
// Поток № 5: шаг 9
// --------------------

// ------------------------------------------

// Результат 2:
// Пример с закомментированным Monitor.Exit(locker)

// Поток № 4: шаг 0
// Поток № 4: шаг 1
// Поток № 4: шаг 2
// Поток № 4: шаг 3
// Поток № 4: шаг 4
// Поток № 4: шаг 5
// Поток № 4: шаг 6
// Поток № 4: шаг 7
// Поток № 4: шаг 8
// Поток № 4: шаг 9
// --------------------