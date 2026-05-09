using System.Diagnostics;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1;

/// <summary>
/// Версия 1. Использует Monitor (lock) для синхронизации
/// </summary>
public sealed class MonitorService : IPrimeCounter
{
    private readonly object _lockObject = new();
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="threadCount"></param>
    /// <returns></returns>
    public PrimeCountResultDto CountPrimes(int start, int end, int threadCount)
    {
        var stopwatch = Stopwatch.StartNew();

        int primeCount = 0;
        var primes = new List<int>();
        var threads = new List<Thread>();

        int range = (end - start + 1) / threadCount;

        for (int i = 0; i < threadCount; i++)
        {
            int threadStart = start + i * range;
            int threadEnd = (i == threadCount - 1)
                ? end
                : threadStart + range - 1;

            int threadNumber = i + 1;

            Thread thread = new Thread(() =>
            {
                for (int number = threadStart; number <= threadEnd; number++)
                {
                    Console.WriteLine($"[Поток {threadNumber}] Проверка числа: {number}");

                    if (IsPrime(number))
                    {
                        lock (_lockObject)
                        {
                            primeCount++;
                            primes.Add(number);

                            Console.WriteLine($"[Поток {threadNumber}] Простое число найдено: {number}");
                        }
                    }
                }
            });

            threads.Add(thread);
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        stopwatch.Stop();

        return new PrimeCountResultDto
        {
            PrimeCount = primeCount,
            ExecutionTime = stopwatch.Elapsed,
            ThreadCount = threadCount,
            SynchronizationType = "Monitor (lock)",
            FoundPrimes = primes
        };
    }
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns></returns>
    public string GetVersionName()
    {
        return "Monitor (lock)";
    }

    private bool IsPrime(int number)
    {
        if (number < 2)
            return false;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }
}
