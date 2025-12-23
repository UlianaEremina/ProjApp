using Xunit;
using EreminaSamoylenkoApp;

namespace EreminaSamoylenkoTests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData(15, 10, 25, 1.0)]
        [InlineData(10, 10, 25, 1.0)]
        [InlineData(5, 10, 25, 0.5)]
        [InlineData(30, 10, 25, 0.7)]
        [InlineData(-5, 10, 25, 0.1)]
        public void CalculateTemperatureScore_ReturnsExpected(double temp, int min, int max, double expected)
        {
            double result = Program.CalculateTemperatureScore(temp, min, max);
            Assert.Equal(expected, result, 1);
        }

        [Theory]
        [InlineData("1", "ПОСАДКИ", 1.0)]
        [InlineData("2", "ПОСАДКИ", 0.7)]
        [InlineData("3", "ПОСАДКИ", 0.5)]
        [InlineData("4", "ПОСАДКИ", 0.1)]
        [InlineData("1", "СБОРА УРОЖАЯ", 1.0)]
        [InlineData("3", "СБОРА УРОЖАЯ", 0.2)]
        [InlineData("4", "СБОРА УРОЖАЯ", 0.0)]
        [InlineData("5", "СБОРА УРОЖАЯ", 0.5)]
        public void CalculateWeatherScore_ReturnsExpected(string weatherType, string operationType, double expected)
        {
            double result = Program.CalculateWeatherScore(weatherType, operationType);
            Assert.Equal(expected, result, 1);
        }

        [Theory]
        [InlineData("пшеница", 50, 0.5)]
        [InlineData("пшеница", 40, 1.0)]
        [InlineData("кукуруза", 60, 1.0)]
        [InlineData("картофель", 75, 0.5)]
        [InlineData("клубника", 65, 1.0)]
        public void CalculateHarvestHumidityScore_ReturnsExpected(string crop, double humidity, double expected)
        {
            double result = Program.CalculateHarvestHumidityScore(humidity, crop);
            Assert.Equal(expected, result, 0.5);
        }
    }
}
