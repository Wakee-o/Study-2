using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2;

public static class Program
{
    public static void Main()
    {
        int start = 1;
        int end = 10000;
        int threadCount = 4;

        var monitorService = new MonitorService();
        var mutexService = new MutexService();
        var semaphoreService = new SemaphoreService();

        Console.WriteLine("===== MONITOR =====");
        var monitorResult = monitorService.CountPrimes(start, end, threadCount);
        Console.WriteLine(monitorResult);

        Console.WriteLine();

        Console.WriteLine("===== MUTEX =====");
        var mutexResult = mutexService.CountPrimes(start, end, threadCount);
        Console.WriteLine(mutexResult);

        Console.WriteLine();

        Console.WriteLine("===== SEMAPHORE =====");
        var semaphoreResult = semaphoreService.CountPrimes(start, end, threadCount);
        Console.WriteLine(semaphoreResult);

        Console.WriteLine();

        Console.WriteLine("Проверка правильности:");
        Console.WriteLine($"Monitor: {monitorResult.IsValid(1229)}");
        Console.WriteLine($"Mutex: {mutexResult.IsValid(1229)}");
        Console.WriteLine($"Semaphore: {semaphoreResult.IsValid(1229)}");
        
    }
}
