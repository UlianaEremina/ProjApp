using Xunit;
using System.Collections.Generic;

namespace Tests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData(20, 15, 25, 1.0)]
        [InlineData(15, 15, 25, 1.0)]
        [InlineData(25, 15, 25, 1.0)]
        [InlineData(10, 15, 25, 0.5)]
        [InlineData(5, 15, 25, 0.1)]
        [InlineData(30, 15, 25, 0.7)]
        [InlineData(35, 15, 25, 0.5)]
        public void CalculateTemperatureScore_VariousCases_ReturnsExpected(
            double temp, int minTemp, int maxTemp, double expected)
        {
            double result = CalculateTemperatureScore(temp, minTemp, maxTemp);
            Assert.Equal(expected, result, 6);
        }

        [Theory]
        [InlineData("1", "ПОСАДКИ", 1.0)]
        [InlineData("2", "ПОСАДКИ", 0.7)]
        [InlineData("3", "ПОСАДКИ", 0.5)]
        [InlineData("4", "ПОСАДКИ", 0.1)]
        [InlineData("неизвестно", "ПОСАДКИ", 0.5)]
        public void CalculateWeatherScore_Planting_ReturnsExpected(
            string weatherType, string operationType, double expected)
        {
            double result = CalculateWeatherScore(weatherType, operationType);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1", "СБОРА УРОЖАЯ", 1.0)]
        [InlineData("2", "СБОРА УРОЖАЯ", 0.7)]
        [InlineData("3", "СБОРА УРОЖАЯ", 0.2)]
        [InlineData("4", "СБОРА УРОЖАЯ", 0.0)]
        [InlineData("неизвестно", "СБОРА УРОЖАЯ", 0.5)]
        public void CalculateWeatherScore_Harvest_ReturnsExpected(
            string weatherType, string operationType, double expected)
        {
            double result = CalculateWeatherScore(weatherType, operationType);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("пшеница", 55, 1.0)]
        [InlineData("пшеница", 65, 0.5)]
        [InlineData("кукуруза", 60, 1.0)]
        [InlineData("кукуруза", 80, 0.5)]
        [InlineData("картофель", 65, 1.0)]
        [InlineData("клубника", 70, 1.0)]
        [InlineData("несуществующая", 70, 1.0)]
        public void CalculateHarvestHumidityScore_VariousCases_ReturnsExpected(
            string crop, double humidity, double expected)
        {
            double result = CalculateHarvestHumidityScore(humidity, crop);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Databases_AreInitialized_WithCorrectCountAndKeys()
        {
            CalculateTemperatureScore(20, 10, 30);

            Assert.Equal(4, cropsDatabase.Count);
            Assert.Equal(4, harvestDatabase.Count);

            Assert.Contains("пшеница", cropsDatabase.Keys);
            Assert.Contains("кукуруза", cropsDatabase.Keys);
            Assert.Contains("картофель", cropsDatabase.Keys);
            Assert.Contains("клубника", cropsDatabase.Keys);

            Assert.Contains("пшеница", harvestDatabase.Keys);
            Assert.Contains("кукуруза", harvestDatabase.Keys);
            Assert.Contains("картофель", harvestDatabase.Keys);
            Assert.Contains("клубника", harvestDatabase.Keys);
        }
        [Fact]
        public void CalculateProbability_ForWheat_ReturnsExpected()
        {
            var criteria = cropsDatabase["пшеница"];
            double probability = CalculateProbabilityForCrop(20, 10, 70, "1", criteria);
            Assert.True(probability > 0.7);
        }

        [Fact]
        public void ShowPlantingCrops_PrintsExpectedText()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            ShowPlantingCrops();

            string output = sw.ToString();
            Assert.Contains("СПРАВОЧНИК КУЛЬТУР", output);
            Assert.Contains("Культура: Пшеница (яровая)", output);
            Assert.Contains("Культура: Кукуруза", output);
            Assert.Contains("КУЛЬТУРЫ ДЛЯ СБОРА УРОЖАЯ", output);
        }


    }
}