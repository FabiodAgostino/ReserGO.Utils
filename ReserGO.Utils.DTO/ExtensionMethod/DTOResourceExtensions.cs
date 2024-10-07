namespace ReserGO.Utils.DTO.ExtensionMethod
{
    public static class DTOResourceExtensions
    {
        //public static List<DTOResource>? ToDayOfWeekList(this string? daysOfTheWeek)
        //{
        //    if (string.IsNullOrEmpty(daysOfTheWeek))
        //    {
        //        return null;
        //    }

        //    var days = daysOfTheWeek.Split(',');

        //    return days
        //        .Select(day => Enum.TryParse<DayOfWeek>(day.Trim(), true, out var result) ? result : (DayOfWeek?)null)
        //        .Where(day => day.HasValue)  // Filtra i null
        //        .Select(day => day.Value)    // Estrai i valori
        //        .OrderBy(day => ItalianDaysOfWeek[day]) // Ordina usando il dizionario
        //        .ToList();
        //}
    }
}
