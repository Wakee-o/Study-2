using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

[TestFixture]
public sealed class SemaphoreServiceTests
{
    [Test]
    public void CountPrimes_ShouldReturnCorrectPrimeCount()
    {
        // Arrange
        var service = new SemaphoreService();

        // Act
        var result = service.CountPrimes(1, 100, 4);

        // Assert
        Assert.That(result.PrimeCount, Is.EqualTo(25));
    }

    [Test]
    public void CountPrimes_ShouldReturnCorrectSynchronizationType()
    {
        // Arrange
        var service = new SemaphoreService();

        // Act
        var result = service.CountPrimes(1, 100, 4);

        // Assert
        Assert.That(result.SynchronizationType, Is.EqualTo("Semaphore"));
    }

    [Test]
    public void GetVersionName_ShouldReturnSemaphoreName()
    {
        // Arrange
        var service = new SemaphoreService();

        // Act
        var result = service.GetVersionName();

        // Assert
        Assert.That(result, Is.EqualTo("Semaphore"));
    }

    [Test]
    public void CountPrimes_ShouldUseCorrectThreadCount()
    {
        // Arrange
        var service = new SemaphoreService();

        // Act
        var result = service.CountPrimes(1, 100, 4);

        // Assert
        Assert.That(result.ThreadCount, Is.EqualTo(4));
    }
}
