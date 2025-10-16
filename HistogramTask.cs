namespace Names;

internal static class HistogramTask
{
    public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
    {
        var days = new string[31];
        for (int i = 0; i < 31; i++)
            days[i] = (i + 1).ToString();

        var birthsPerDay = new double[31];
        
        foreach (var person in names)
        {
            if (person.BirthDate.Day == 1)
                continue;
            
            if (person.Name.ToLower() == name.ToLower())
            {
                birthsPerDay[person.BirthDate.Day - 1]++;
            }
        }

        return new HistogramData(
            $"Рождаемость людей с именем '{name}'", 
            days, 
            birthsPerDay);
    }
}