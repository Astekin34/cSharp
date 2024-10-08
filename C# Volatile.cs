// Volatile Kullanımı

using System;
using System.Threading;
partial class Program
{

    volatile static bool Durum;
    volatile static int Sayi = 1;
    /* Değişkenin birden fazla iş parçacığı tarafından değiştirilebileceğini
     * ve bu nedenle derleyicinin optimizasyon yapmaması gerektiğini belirtir. */
    static void Main(string[] args)
    {
        Thread t = new Thread(new ThreadStart(() => //lambda işareti ile iş parçacığının yapması gereken işler tanımlanır.
        {
            Sayi = 5;
            Durum = true; // iş parçacığı çalıştığında Sayı 5 e ayarlanır ve durum true olur.
        }));
        t.Start(); // iş parçacığını çalıştırır.


        while (true)
        {
            if (Durum)
            {
                Sayi += 5;
                Console.WriteLine(Sayi); // iş parçacığı çalışıp durum true olduğunda Sayi ya 5 ekler ve yeni değeri yazdırır.

                break;
            }
            Console.WriteLine(Sayi);

        }

    }
}


// 2.Örnek
public class Worker
{
    // thread başladığınde bu method çağrılır.
    public void DoWork()
    {
        bool work = false;
        while (!_shouldStop)
        {
            work = !work; // iş yap
        }
        Console.WriteLine("Worker thread: terminating gracefully.");
    }
    public void RequestStop()
    {
        _shouldStop = true;
    }
    /* Volatile anahtar kelimesi, derleyiciye bu verilerin
     üyeye birden fazla iş parçacığı tarafından eriştiğini söyler. */
    private volatile bool _shouldStop;
}

public class WorkerThreadExample
{
    public static void Main()
    {
        // Worker objesini oluştur. Bu threadi başlatmaz.
        Worker workerObject = new Worker();
        Thread workerThread = new Thread(workerObject.DoWork);

        // Worker threadini başlatma.
        workerThread.Start();
        Console.WriteLine("Main thread: starting worker thread...");

        // worker threadi başlayana kadar döngüye al.
        while (!workerThread.IsAlive)
            ;

       / main threadi 3000 milisaniye(3 saniye) bekleterek worked threadin çalışmasına izin ver./
     Thread.Sleep(3000);

        // Worked threadin kendisini durdurmasını söyle.
        workerObject.RequestStop();

        /* Thread.Join() methodu ile bir thread bitene kadar diğerinin çalışmasını engelle.*/
        workerThread.Join();
        Console.WriteLine("Main thread: worker thread has terminated.");
    }

}