using Microsoft.VisualStudio.TestPlatform.TestHost;
using EreminaSamoylenkoApp;
using Xunit;

public class CalculationTests
{
    [Theory]
    [InlineData(15, 10, 20, 1.0)]   // в диапазоне
    [InlineData(9, 10, 20, 0.5)]    // ниже мин
    [InlineData(25, 10, 20, 0.7)]   // выше макс
    public void CalculateTemperatureScore_ReturnsExpected(double temp, int min, int max, double expected)
    {
        double result = Program.Program.CalculateTemperatureScore(temp, min, max);
        Assert.Equal(expected, result, 1); // 1 знак после запятой
    }
}
