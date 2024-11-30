using System;
// Threadler ile çalışırken alttaki .Threading kütüphanesi kullanılır.
using System.Threading;

// Thread kullanımı

namespace IsaProgram
{
    class Program
    {
        static void Main(string[] args)
        {

            Thread mainThread = Thread.CurrentThread;
            mainThread.Name = "Main Thread";

            // Aynı anda çalışmaya başlayan iki sayaç
            Thread thread1 = new Thread(Countdown);
            Thread thread2 = new Thread(Countup);
            thread1.Start();
            thread2.Start();

            thread1.Join(); // iki sayaç bitmeden main thread is complete çıktısını verme.
            thread2.Join();

            Console.WriteLine(mainThread.Name + " tamamlandı!");
            Console.ReadKey();

        }
        public static void Countdown()
        {
            for (int i = 10; i >= 0; i--)
            {
                Console.WriteLine($"Timer #1 :{i} saniye");
                Thread.Sleep(1000);

            }
            Console.WriteLine($"Timer #1 tamamlandı!");
        }
        public static void Countup()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"Timer #2 :{i} saniye");
                Thread.Sleep(1000);

            }
            Console.WriteLine($"Timer #2 tamamlandı!");
        }

    }
}