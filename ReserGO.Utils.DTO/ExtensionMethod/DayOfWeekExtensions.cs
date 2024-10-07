﻿namespace ReserGO.Utils.DTO.ExtensionMethod
{
    public static class DayOfWeekExtensions
    {

        private static readonly Dictionary<DayOfWeek, string> ItalianDaysOfWeek = new()
            {
                { DayOfWeek.Monday, "Lunedì" },
                { DayOfWeek.Tuesday, "Martedì" },
                { DayOfWeek.Wednesday, "Mercoledì" },
                { DayOfWeek.Thursday, "Giovedì" },
                { DayOfWeek.Friday, "Venerdì" },
                { DayOfWeek.Saturday, "Sabato" },
                { DayOfWeek.Sunday, "Domenica" }
            };
        public static List<DayOfWeek>? ToDayOfWeekList(this string? daysOfTheWeek)
        {
            if (string.IsNullOrEmpty(daysOfTheWeek))
            {
                return null;
            }

            var days = daysOfTheWeek.Split(',');

            return days
                .Select(day => Enum.TryParse<DayOfWeek>(day.Trim(), true, out var result) ? result : (DayOfWeek?)null)
                .Where(day => day.HasValue)  // Filtra i null
                .Select(day => day.Value)    // Estrai i valori
                .OrderBy(day => ItalianDaysOfWeek[day]) // Ordina usando il dizionario
                .ToList();
        }

        public static List<string>? ToItalianStringList(this List<DayOfWeek>? listDaysOfTheWeek)
        {
            if (listDaysOfTheWeek == null || !listDaysOfTheWeek.Any())
            {
                return null;
            }
            return listDaysOfTheWeek.Select(day => ItalianDaysOfWeek[day]).ToList();
        }


    }


}
