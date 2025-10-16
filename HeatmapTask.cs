using System;

namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var days = GenerateDayLabels();
            var months = GenerateMonthLabels();
            var birthsData = CalculateBirthsData(names);

            return new HeatmapData(
                "Тепловая карта рождаемости", 
                birthsData, 
                days, 
                months);
        }

        private static string[] GenerateDayLabels()
        {
            var days = new string[30];
            for (int i = 0; i < 30; i++)
                days[i] = (i + 2).ToString();
            return days;
        }

        private static string[] GenerateMonthLabels()
        {
            var months = new string[12];
            for (int i = 0; i < 12; i++)
                months[i] = (i + 1).ToString();
            return months;
        }

        private static double[,] CalculateBirthsData(NameData[] names)
        {
            var birthsData = new double[30, 12];

            foreach (var person in names)
            {
                if (ShouldSkipPerson(person))
                    continue;

                var (dayIndex, monthIndex) = GetDateIndices(person.BirthDate);
                birthsData[dayIndex, monthIndex]++;
            }

            return birthsData;
        }

        private static bool ShouldSkipPerson(NameData person)
        {
            return person.BirthDate.Day == 1;
        }

        private static (int dayIndex, int monthIndex) GetDateIndices(DateTime birthDate)
        {
            int dayIndex = birthDate.Day - 2;
            int monthIndex = birthDate.Month - 1;
            return (dayIndex, monthIndex);
        }
    }
}