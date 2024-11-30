// Volatile Kullanımı

public class Worker
{
    /* Volatile anahtar kelimesi, derleyiciye bu verilerin
     üyeye birden fazla iş parçacığı tarafından eriştiğini söyler. */
    private volatile bool _shouldStop;
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
}