using System;
using System.Threading;

// Thread kullanımı

 namespace MyFirstProgram
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
            
            Console.WriteLine(mainThread.Name + " is complete!");
            Console.ReadKey();
           
        }
        public static void Countdown()
        {
            for (int i = 10; i >= 0; i--)
            {
                Console.WriteLine($"Timer #1 :{i} seconds");
                Thread.Sleep(1000);

            }
            Console.WriteLine($"Timer #1 is complete!");
        }
        public static void Countup()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"Timer #2 :{i} seconds");
                Thread.Sleep(1000);

            }
            Console.WriteLine($"Timer #2 is complete!");
        }
        
    }
}
