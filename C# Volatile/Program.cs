// Volatile Kullanımı

// 1.Örnek
using System;
using System.Threading;

partial class Program
{
    volatile static bool Durum;
    volatile static int Sayi = 1;

    static void Main(string[] args)
    {
        // Başlangıçta Sayi'nın değerini yazdır
        Console.WriteLine(Sayi);

        Thread t = new Thread(new ThreadStart(() =>
        {
            Sayi = 5;
            Durum = true; // İş parçacığı çalıştığında Sayi 5'e ayarlanır ve durum true olur.
        }));

        t.Start(); // İş parçacığını çalıştırır.

        while (true)
        {
            if (Durum)
            {
                Sayi += 5;
                Console.WriteLine(Sayi); // İş parçacığı çalışıp durum true olduğunda Sayi'ya 5 ekler ve yeni değeri yazdırır.
                break;
            }

           
        }

        // İş parçacığının bitmesini bekleyin.
        t.Join();

        Console.WriteLine("Program has completed. Press any key to exit...");
        Console.ReadKey(); // Kullanıcıdan bir tuşa basmasını bekleyin.
    }
}




// 2.Örnek


/*public class WorkerThreadExample : Worker
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

        // main threadi 3000 milisaniye(3 saniye) bekleterek worked threadin çalışmasına izin ver.
    /*    Thread.Sleep(3000);

        // Worked threadin kendisini durdurmasını söyle.
        workerObject.RequestStop();

        // Thread.Join() methodu ile bir thread bitene kadar diğerinin çalışmasını engelle.
   /*     workerThread.Join();
        Console.WriteLine("Main thread: worker thread has terminated.");
        Console.ReadKey();
    }

}*/