using System;
using System.Collections.Generic;

namespace EreminaSamoylenkoApp;

public abstract class Program
{
    // Структура для хранения критериев культуры (посадка)
    struct CropCriteria
    {
        public string Name;
        public int MinDayTemp;
        public int MaxDayTemp;
        public int MinNightTemp;
        public double DayTempWeight;
        public double NightTempWeight;
        public double HumidityWeight;
        public double WeatherWeight;
        public string OptimalMonths;
    }

    // Структура для хранения критериев культуры (сбор)
    struct HarvestCriteria
    {
        public string Name;
        public int MinDayTemp;
        public int MaxDayTemp;
        public int MinNightTemp;
        public double DayTempWeight;
        public double NightTempWeight;
        public double HumidityWeight;
        public double WeatherWeight;
        public string OptimalMonths;
    }

    // База данных культур для посадки с экспертными оценками
    static Dictionary<string, CropCriteria> cropsDatabase = new Dictionary<string, CropCriteria>
    {
        {
            "пшеница",
            new CropCriteria
            {
                Name = "Пшеница (яровая)",
                MinDayTemp = 10,
                MaxDayTemp = 25,
                MinNightTemp = 0,
                DayTempWeight = 1.0,
                NightTempWeight = 0.8,
                HumidityWeight = 1.0,
                WeatherWeight = 0.7,
                OptimalMonths = "апрель — май"
            }
        },
        {
            "кукуруза",
            new CropCriteria
            {
                Name = "Кукуруза",
                MinDayTemp = 18,
                MaxDayTemp = 30,
                MinNightTemp = 8,
                DayTempWeight = 1.0,
                NightTempWeight = 1.0,
                HumidityWeight = 1.0,
                WeatherWeight = 1.0,
                OptimalMonths = "май — июнь"
            }
        },
        {
            "картофель",
            new CropCriteria
            {
                Name = "Картофель",
                MinDayTemp = 15,
                MaxDayTemp = 22,
                MinNightTemp = 5,
                DayTempWeight = 1.0,
                NightTempWeight = 0.8,
                HumidityWeight = 1.0,
                WeatherWeight = 0.9,
                OptimalMonths = "апрель — май"
            }
        },
        {
            "клубника",
            new CropCriteria
            {
                Name = "Клубника (весенняя посадка)",
                MinDayTemp = 15,
                MaxDayTemp = 20,
                MinNightTemp = 5,
                DayTempWeight = 1.0,
                NightTempWeight = 1.0,
                HumidityWeight = 1.0,
                WeatherWeight = 1.0,
                OptimalMonths = "апрель — май"
            }
        }
    };

    // База данных культур для сбора урожая с экспертными оценками
    static Dictionary<string, HarvestCriteria> harvestDatabase = new Dictionary<string, HarvestCriteria>
    {
        {
            "пшеница",
            new HarvestCriteria
            {
                Name = "Пшеница (озимя)",
                MinDayTemp = 18,
                MaxDayTemp = 25,
                MinNightTemp = 5,
                DayTempWeight = 1.0,
                NightTempWeight = 0.9,
                HumidityWeight = 1.0,
                WeatherWeight = 1.0,
                OptimalMonths = "июль — август"
            }
        },
        {
            "кукуруза",
            new HarvestCriteria
            {
                Name = "Кукуруза",
                MinDayTemp = 20,
                MaxDayTemp = 28,
                MinNightTemp = 10,
                DayTempWeight = 1.0,
                NightTempWeight = 0.9,
                HumidityWeight = 0.9,
                WeatherWeight = 1.0,
                OptimalMonths = "сентябрь — октябрь"
            }
        },
        {
            "картофель",
            new HarvestCriteria
            {
                Name = "Картофель",
                MinDayTemp = 15,
                MaxDayTemp = 20,
                MinNightTemp = 5,
                DayTempWeight = 1.0,
                NightTempWeight = 0.9,
                HumidityWeight = 1.0,
                WeatherWeight = 1.0,
                OptimalMonths = "август — сентябрь"
            }
        },
        {
            "клубника",
            new HarvestCriteria
            {
                Name = "Клубника",
                MinDayTemp = 18,
                MaxDayTemp = 24,
                MinNightTemp = 8,
                DayTempWeight = 1.0,
                NightTempWeight = 0.9,
                HumidityWeight = 0.9,
                WeatherWeight = 1.0,
                OptimalMonths = "июнь — июль"
            }
        }
    };

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Здравствуйте! Вас приветствует Ваш персональный помощник ОГОРОДНИК!");
            Console.WriteLine("Данная программа предназначена для помощи в определении наилучшего времени");
            Console.WriteLine("для посадки и сбора урожая различных культур.");
            Console.WriteLine("Программа использует метод логистической регрессии с экспертными оценками.");
            Console.WriteLine("Помимо всего ранее перечисленного вы сможете узнать много иной полезной информации!");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Основное меню:");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("1. Расчет вероятности посадки (с экспертной оценкой)");
            Console.WriteLine("2. Расчет вероятности сбора урожая (с экспертной оценкой)");
            Console.WriteLine("3. Интересные факты для посадки и сбора");
            Console.WriteLine("4. Посадочные культуры (справочник)");
            Console.WriteLine("5. Примечание");
            Console.WriteLine("6. Завершить");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.Write("Выберите опцию: ");
            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    CalculateProbability(cropsDatabase, "ПОСАДКИ");
                    break;
                case "2":
                    CalculateProbability(harvestDatabase, "СБОРА УРОЖАЯ");
                    break;
                case "3":
                    ShowInterestingFacts();
                    break;
                case "4":
                    ShowPlantingCrops();
                    break;
                case "5":
                    ShowTestCalculations();
                    break;
                case "6":
                    Console.WriteLine("--------------------------------------------------------------------");
                    Console.WriteLine("Спасибо за использование программы!");
                    Console.WriteLine("Завершение работы программы.");
                    Console.WriteLine("--------------------------------------------------------------------");
                    return;
                default:
                    Console.WriteLine("Некорректный ввод, попробуйте снова. Нажмите Enter для продолжения");
                    Console.ReadKey();
                    break;
            }
        }
    }

    // Обобщенный метод для расчета вероятности (для посадки и сбора)
    public static void CalculateProbability<T>(Dictionary<string, T> database, string operationType)
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------------------------------");
        Console.WriteLine($"РАСЧЕТ ВЕРОЯТНОСТИ {operationType} С ЭКСПЕРТНОЙ ОЦЕНКОЙ");
        Console.WriteLine("--------------------------------------------------------------------");

        // Выбор культуры
        Console.WriteLine("\nВыберите культуру для анализа:");
        int i = 1;
        foreach (var crop in database)
        {
            if (operationType == "ПОСАДКИ")
            {
                var cropCriteria = (CropCriteria)(object)crop.Value;
                Console.WriteLine($"{i}. {cropCriteria.Name}");
            }
            else
            {
                var harvestCriteria = (HarvestCriteria)(object)crop.Value;
                Console.WriteLine($"{i}. {harvestCriteria.Name}");
            }
            i++;
        }
        Console.Write("Введите номер культуры: ");

        if (!int.TryParse(Console.ReadLine(), out int cropIndex) || cropIndex < 1 || cropIndex > database.Count)
        {
            Console.WriteLine("Некорректный выбор культуры!");
            Console.ReadKey();
            return;
        }

        string selectedCrop = "";
        int current = 1;
        foreach (var crop in database)
        {
            if (current == cropIndex)
            {
                selectedCrop = crop.Key;
                break;
            }
            current++;
        }

        // Ввод данных о погодных условиях
        Console.WriteLine("\nВведите данные о погодных условиях:");

        Console.Write("Температура днем (°C): ");
        if (!double.TryParse(Console.ReadLine(), out double dayTemp))
        {
            Console.WriteLine("Некорректный ввод температуры!");
            Console.ReadKey();
            return;
        }

        Console.Write("Температура ночью (°C): ");
        if (!double.TryParse(Console.ReadLine(), out double nightTemp))
        {
            Console.WriteLine("Некорректный ввод температуры!");
            Console.ReadKey();
            return;
        }

        Console.Write("Влажность почвы (%): ");
        if (!double.TryParse(Console.ReadLine(), out double humidity))
        {
            Console.WriteLine("Некорректный ввод влажности!");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Погодные условия:");
        Console.WriteLine("1. Солнечно");
        Console.WriteLine("2. Облачно");
        Console.WriteLine("3. Дождь");
        Console.WriteLine("4. Снег");
        Console.Write("Выберите тип погоды (1-4): ");
        string weatherType = Console.ReadLine()!;

        // Расчет вероятности в зависимости от типа операции
        double probability;
        string cropName;
        string optimalMonths;

        if (operationType == "ПОСАДКИ")
        {
            var criteria = (CropCriteria)(object)database[selectedCrop];
            cropName = criteria.Name;
            optimalMonths = criteria.OptimalMonths;

            Console.WriteLine($"\nАнализ для: {cropName}");
            Console.WriteLine($"Оптимальные месяцы: {optimalMonths}");
            Console.WriteLine($"Оптимальная температура днем: {criteria.MinDayTemp}°C - {criteria.MaxDayTemp}°C");
            Console.WriteLine($"Минимальная температура ночью: {criteria.MinNightTemp}°C");

            // Расчет баллов по каждому параметру
            double dayTempScore = CalculateTemperatureScore(dayTemp, criteria.MinDayTemp, criteria.MaxDayTemp);
            double nightTempScore = (nightTemp >= criteria.MinNightTemp) ? 1.0 : 0.5;
            double humidityScore = (humidity >= 60 && humidity <= 80) ? 1.0 : 0.5;
            double weatherScore = CalculateWeatherScore(weatherType, operationType);

            // Применение весов экспертной оценки
            dayTempScore *= criteria.DayTempWeight;
            nightTempScore *= criteria.NightTempWeight;
            humidityScore *= criteria.HumidityWeight;
            weatherScore *= criteria.WeatherWeight;

            // Расчет вероятности
            probability = (dayTempScore + nightTempScore + humidityScore + weatherScore) / 4.0;

            Console.WriteLine("\n--------------------------------------------------------------------");
            Console.WriteLine("РЕЗУЛЬТАТЫ РАСЧЕТА:");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine($"Температура днем: {dayTemp}°C -> Балл: {dayTempScore:F2}");
            Console.WriteLine($"Температура ночью: {nightTemp}°C -> Балл: {nightTempScore:F2}");
            Console.WriteLine($"Влажность почвы: {humidity}% -> Балл: {humidityScore:F2}");
            Console.WriteLine($"Погодные условия -> Балл: {weatherScore:F2}");
        }
        else
        {
            var criteria = (HarvestCriteria)(object)database[selectedCrop];
            cropName = criteria.Name;
            optimalMonths = criteria.OptimalMonths;

            Console.WriteLine($"\nАнализ для: {cropName}");
            Console.WriteLine($"Оптимальные месяцы: {optimalMonths}");
            Console.WriteLine($"Оптимальная температура днем: {criteria.MinDayTemp}°C - {criteria.MaxDayTemp}°C");
            Console.WriteLine($"Минимальная температура ночью: {criteria.MinNightTemp}°C");

            // Расчет баллов для сбора урожая
            double dayTempScore = CalculateTemperatureScore(dayTemp, criteria.MinDayTemp, criteria.MaxDayTemp);
            double nightTempScore = (nightTemp >= criteria.MinNightTemp) ? 1.0 : 0.5;
            double humidityScore = CalculateHarvestHumidityScore(humidity, selectedCrop);
            double weatherScore = CalculateWeatherScore(weatherType, operationType);

            // Применение весов экспертной оценки
            dayTempScore *= criteria.DayTempWeight;
            nightTempScore *= criteria.NightTempWeight;
            humidityScore *= criteria.HumidityWeight;
            weatherScore *= criteria.WeatherWeight;

            // Расчет вероятности
            probability = (dayTempScore + nightTempScore + humidityScore + weatherScore) / 4.0;

            Console.WriteLine("\n--------------------------------------------------------------------");
            Console.WriteLine("РЕЗУЛЬТАТЫ РАСЧЕТА:");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine($"Температура днем: {dayTemp}°C -> Балл: {dayTempScore:F2}");
            Console.WriteLine($"Температура ночью: {nightTemp}°C -> Балл: {nightTempScore:F2}");
            Console.WriteLine($"Влажность почвы: {humidity}% -> Балл: {humidityScore:F2}");
            Console.WriteLine($"Погодные условия -> Балл: {weatherScore:F2}");
        }

        Console.WriteLine("--------------------------------------------------------------------");
        Console.WriteLine($"ВЕРОЯТНОСТЬ УДАЧНОЙ {operationType}: {probability:P2}");

        // Рекомендации
        string recommendation;
        if (operationType == "ПОСАДКИ")
        {
            recommendation = probability switch
            {
                < 0.4 => "Лучше воздержаться от посадки.",
                < 0.7 => "Стоит еще подождать, погода благоприятна лишь для посадки некоторых культур.",
                _ => "Большой процент успешной заготовки и дальнейшей высадки растений."
            };
        }
        else
        {
            recommendation = probability switch
            {
                < 0.4 => "Уборка не рекомендуется.",
                < 0.7 => "Стоит подождать или убирать с осторожностью.",
                _ => "Условия благоприятны для уборки урожая."
            };
        }

        Console.WriteLine($"РЕКОМЕНДАЦИЯ: {recommendation}");
        Console.WriteLine("--------------------------------------------------------------------");
        Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
        Console.ReadKey();
    }

    // Расчет балла для температуры
    public static double CalculateTemperatureScore(double temp, int minTemp, int maxTemp)
    {
        if (temp >= minTemp && temp <= maxTemp)
            return 1.0;
        else if (temp < minTemp - 5)
            return 0.1;
        else if (temp < minTemp)
            return 0.5;
        else if (temp > maxTemp + 5)
            return 0.5;
        else if (temp > maxTemp)
            return 0.7;
        else
            return 0.3;
    }

    // Расчет балла для погоды
    public static double CalculateWeatherScore(string weatherType, string operationType)
    {
        if (operationType == "ПОСАДКИ")
        {
            return weatherType switch
            {
                "1" => 1.0,  // Солнечно
                "2" => 0.7,  // Облачно
                "3" => 0.5,  // Дождь
                "4" => 0.1,  // Снег
                _ => 0.5
            };
        }
        else
        {
            // Для сбора урожая другие приоритеты
            return weatherType switch
            {
                "1" => 1.0,  // Солнечно - идеально для уборки
                "2" => 0.7,  // Облачно - приемлемо
                "3" => 0.2,  // Дождь - затрудняет уборку
                "4" => 0.0,  // Снег - исключает уборку
                _ => 0.5
            };
        }
    }

    // Расчет балла для влажности при сборе урожая
    public static double CalculateHarvestHumidityScore(double humidity, string crop)
    {
        // Специфичные условия для разных культур при сборе
        return crop switch
        {
            "пшеница" => humidity < 60 ? 1.0 : 0.5,  // Для пшеницы нужна сухая почва
            "кукуруза" => (humidity >= 50 && humidity <= 70) ? 1.0 : 0.5,
            "картофель" => (humidity >= 60 && humidity <= 70) ? 1.0 : 0.5,
            "клубника" => (humidity >= 60 && humidity <= 70) ? 1.0 : 0.5,
            _ => (humidity >= 60 && humidity <= 80) ? 1.0 : 0.5
        };
    }

    // Тестовые расчеты из курсовой работы
    public static void ShowTestCalculations()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------------------------------");
        Console.WriteLine("ПРИМЕЧАНИЕ");
        Console.WriteLine("--------------------------------------------------------------------");
        Console.WriteLine("Примеры расчетов вероятности удачной посадки и сбора урожая");
        Console.WriteLine("методом логистической регресии по формуле: P(Y=1) = (a + b + c + d) / 4");
        Console.WriteLine("где a,b,c,d - баллы по температуре днем/ночью, влажности и погоде");
        Console.WriteLine("--------------------------------------------------------------------\n");

        Console.WriteLine("РАСЧЕТЫ ДЛЯ ПОСАДКИ:");
        Console.WriteLine("===================\n");

        // Пример 1: Пшеница в январе
        Console.WriteLine("1. ПШЕНИЦА (ЯРОВАЯ) - 24 января");
        Console.WriteLine("Температура днем: -5°C -> Балл: 0");
        Console.WriteLine("Температура ночью: -10°C -> Балл: 0");
        Console.WriteLine("Влажность: 85% -> Балл: 0");
        Console.WriteLine("Погода: Солнечно -> Балл: 0.7");
        Console.WriteLine("Расчет: P = (0 + 0 + 0 + 0.7) / 4 = 0.175 (17.5%)");
        Console.WriteLine("Вывод: Лучше воздержаться от посадки");
        Console.WriteLine("--------------------------------------------------------------------\n");

        // Пример 2: Пшеница в мае
        Console.WriteLine("2. ПШЕНИЦА (ЯРОВАЯ) - 2 мая");
        Console.WriteLine("Температура днем: 18°C -> Балл: 1");
        Console.WriteLine("Температура ночью: 6°C -> Балл: 0.8");
        Console.WriteLine("Влажность: 56% -> Балл: 0.5");
        Console.WriteLine("Погода: Солнечно -> Балл: 0.7");
        Console.WriteLine("Расчет: P = (1 + 0.8 + 0.5 + 0.7) / 4 = 0.75 (75%)");
        Console.WriteLine("Вывод: Успешный процент посадки");
        Console.WriteLine("--------------------------------------------------------------------\n");

        // Пример 3: Картофель в апреле
        Console.WriteLine("3. КАРТОФЕЛЬ - 16 апреля");
        Console.WriteLine("Температура днем: 14°C -> Балл: 0.9");
        Console.WriteLine("Температура ночью: 4°C -> Балл: 0.5");
        Console.WriteLine("Влажность: 65% -> Балл: 1");
        Console.WriteLine("Погода: Облачно -> Балл: 0.9");
        Console.WriteLine("Расчет: P = (0.9 + 0.5 + 1 + 0.9) / 4 = 0.825 (82.5%)");
        Console.WriteLine("Вывод: Большой процент успешной посадки");
        Console.WriteLine("--------------------------------------------------------------------\n");

        Console.WriteLine("РАСЧЕТЫ ДЛЯ СБОРА УРОЖАЯ:");
        Console.WriteLine("========================\n");

        // Пример 4: Пшеница в июле
        Console.WriteLine("4. ПШЕНИЦА (ОЗИМАЯ) - 15 июля");
        Console.WriteLine("Температура днем: 24°C -> Балл: 1");
        Console.WriteLine("Температура ночью: 12°C -> Балл: 0.9");
        Console.WriteLine("Влажность: 55% -> Балл: 1");
        Console.WriteLine("Погода: Солнечно -> Балл: 1");
        Console.WriteLine("Расчет: P = (1 + 0.9 + 1 + 1) / 4 = 0.975 (97.5%)");
        Console.WriteLine("Вывод: Условия идеальны для уборки пшеницы");
        Console.WriteLine("--------------------------------------------------------------------\n");

        // Пример 5: Картофель в сентябре
        Console.WriteLine("5. КАРТОФЕЛЬ - 10 сентября");
        Console.WriteLine("Температура днем: 16°C -> Балл: 1");
        Console.WriteLine("Температура ночью: 6°C -> Балл: 0.9");
        Console.WriteLine("Влажность: 75% -> Балл: 0.8");
        Console.WriteLine("Погода: Дождь -> Балл: 0");
        Console.WriteLine("Расчет: P = (1 + 0.9 + 0.8 + 0) / 4 = 0.675 (67.5%)");
        Console.WriteLine("Вывод: Уборка возможна, но из-за дождя есть риски - лучше подождать");
        Console.WriteLine("--------------------------------------------------------------------\n");

        Console.WriteLine("ОЦЕНОЧНАЯ ШКАЛА ДЛЯ ПОСАДКИ:");
        Console.WriteLine("0-40%: Лучше воздержаться от посадки");
        Console.WriteLine("41-69%: Стоит подождать");
        Console.WriteLine("70-100%: Успешная посадка");
        Console.WriteLine("\nОЦЕНОЧНАЯ ШКАЛА ДЛЯ СБОРА УРОЖАЯ:");
        Console.WriteLine("0-40%: Уборка не рекомендуется");
        Console.WriteLine("41-69%: Стоит подождать или убирать с осторожностью");
        Console.WriteLine("70-100%: Условия благоприятны для уборки");
        Console.WriteLine("--------------------------------------------------------------------");

        Console.WriteLine("\nНажмите любую клавишу для возврата...");
        Console.ReadKey();
    }

    // Показать справочник культур
    public static void ShowPlantingCrops()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------------------------------");
        Console.WriteLine("СПРАВОЧНИК КУЛЬТУР ДЛЯ ПОСАДКИ И СБОРА");
        Console.WriteLine("--------------------------------------------------------------------\n");

        Console.WriteLine("КУЛЬТУРЫ ДЛЯ ПОСАДКИ:");
        Console.WriteLine("====================\n");
        foreach (var crop in cropsDatabase)
        {
            Console.WriteLine($"Культура: {crop.Value.Name}");
            Console.WriteLine($"Оптимальные месяцы: {crop.Value.OptimalMonths}");
            Console.WriteLine($"Температура днем: {crop.Value.MinDayTemp}°C - {crop.Value.MaxDayTemp}°C");
            Console.WriteLine($"Температура ночью: не ниже {crop.Value.MinNightTemp}°C");
            Console.WriteLine("--------------------------------------------------------------------");
        }

        Console.WriteLine("\nКУЛЬТУРЫ ДЛЯ СБОРА УРОЖАЯ:");
        Console.WriteLine("==========================\n");
        foreach (var crop in harvestDatabase)
        {
            Console.WriteLine($"Культура: {crop.Value.Name}");
            Console.WriteLine($"Оптимальные месяцы: {crop.Value.OptimalMonths}");
            Console.WriteLine($"Температура днем: {crop.Value.MinDayTemp}°C - {crop.Value.MaxDayTemp}°C");
            Console.WriteLine($"Температура ночью: не ниже {crop.Value.MinNightTemp}°C");
            Console.WriteLine("--------------------------------------------------------------------");
        }

        Console.WriteLine("\nНажмите любую клавишу для возврата...");
        Console.ReadKey();
    }

    // Показать интересные факты
    public static void ShowInterestingFacts()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------------------------------");
        Console.WriteLine("ИНТЕРЕСНЫЕ ФАКТЫ О ПОСАДКЕ И СБОРЕ УРОЖАЯ");
        Console.WriteLine("--------------------------------------------------------------------\n");

        Console.WriteLine("ФАКТЫ О ПОСАДКЕ:");
        Console.WriteLine("1. Пшеница (яровая) лучше всего растет при температуре +10...+25°C");
        Console.WriteLine("2. Кукуруза очень теплолюбива - минимальная температура для роста +12°C");
        Console.WriteLine("3. Картофель боится заморозков - минимальная ночная температура +5°C");
        Console.WriteLine("4. Клубника любит влагу - оптимальная влажность почвы 75-85%");
        Console.WriteLine("5. Большинство культур лучше сажать в пасмурную погоду");
        Console.WriteLine("\nФАКТЫ О СБОРЕ УРОЖАЯ:");
        Console.WriteLine("1. Пшеницу лучше убирать в сухую солнечную погоду");
        Console.WriteLine("2. Картофель нельзя убирать в дождь - это приводит к гниению");
        Console.WriteLine("3. Клубнику собирают утром, когда она прохладная");
        Console.WriteLine("4. Кукурузу убирают когда зерна становятся твердыми");
        Console.WriteLine("5. Идеальная влажность почвы для уборки - менее 60%");
        Console.WriteLine("--------------------------------------------------------------------");
        Console.WriteLine("\nНажмите любую клавишу для возврата...");
        Console.ReadKey();
    }
}