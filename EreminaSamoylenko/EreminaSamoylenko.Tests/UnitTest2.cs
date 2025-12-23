using System;
using System.IO;
using System.Collections.Generic;
using Xunit;
using static EreminaSamoylenkoApp.Program;

namespace EreminaSamoylenkoTests
{
    public class ProgramTests2
    {

        [Fact]
        public void CalculateTemperatureScore_ShouldReturnExpectedValues()
        {
            Assert.Equal(1.0, CalculateTemperatureScore(15, 10, 20));
            Assert.Equal(0.5, CalculateTemperatureScore(9, 10, 20));
            Assert.Equal(0.7, CalculateTemperatureScore(21, 10, 20));
            Assert.Equal(0.1, CalculateTemperatureScore(4, 10, 20));
        }

        [Fact]
        public void CalculateWeatherScore_ShouldReturnExpectedValues()
        {
            Assert.Equal(1.0, CalculateWeatherScore("1", "ПОСАДКИ"));
            Assert.Equal(0.1, CalculateWeatherScore("4", "ПОСАДКИ"));
            Assert.Equal(0.2, CalculateWeatherScore("3", "СБОРА УРОЖАЯ"));
        }

        [Fact]
        public void CalculateHarvestHumidityScore_ShouldReturnExpectedValues()
        {
            Assert.Equal(1.0, CalculateHarvestHumidityScore(55, "пшеница"));
            Assert.Equal(1.0, CalculateHarvestHumidityScore(60, "картофель"));
            Assert.Equal(0.5, CalculateHarvestHumidityScore(80, "картофель"));
        }
    }
}
