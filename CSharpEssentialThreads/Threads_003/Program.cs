using System;
using System.Threading;

namespace Thread_003
{
    class Program
    {
        static void SecondWriter()
        {
            // Получаем ссылку на экземпляр текущего потока
            Thread thread = Thread.CurrentThread;

            // Даем имя потоку
            thread.Name = "Secondary";

            // Информация о вторичном потоке
            Console.WriteLine($"ID потока {thread.Name}: {thread.GetHashCode().ToString()}");

            for (int counter = 0; counter < 10; counter++)
            {
                Console.WriteLine($"{new string(' ', 15)}{thread.Name} {counter}");
                
                // Пауза 1 сек.
                Thread.Sleep(1000);
            }
        }
        
        static void Main(string[] args)
        {
            // Получаем ссылку на основной поток
            Thread primaryThread = Thread.CurrentThread;

            // Даем название
            primaryThread.Name = "Primary";
            
            // Информация по основному потоку
            Console.WriteLine("ID потока {0}: {1}", primaryThread.Name, primaryThread.GetHashCode().ToString());

            // Запускаем второй поток
            Thread secondaryThread = new Thread(SecondWriter);
            secondaryThread.Start();
            
            for (int counter = 0; counter < 10; counter++)
            {
                Console.WriteLine($"{primaryThread.Name} {counter}");

                // Пауза 1.5 секунды
                Thread.Sleep(1500);
            }
            
            Console.ReadLine();
        }
    }
}

// Результат

// Видно что на построение потока уходит какое-то время
// Успевает вывестись сообщение из цикла "Primary 0"

// ID потока Primary: 1
// Primary 0
// ID потока Secondary: 4
//                Secondary 0
//                Secondary 1
// Primary 1
//                Secondary 2
// Primary 2
//                Secondary 3
//                Secondary 4
// Primary 3
//                Secondary 5
// Primary 4
//                Secondary 6
//                Secondary 7
// Primary 5
//                Secondary 8
// Primary 6
//                Secondary 9
// Primary 7
// Primary 8
// Primary 9
