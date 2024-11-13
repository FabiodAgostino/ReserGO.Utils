namespace ReserGO.Utils.DTO.ExtensionMethod
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
        public static readonly Dictionary<string, int> ItalianDaysOrder = new(StringComparer.OrdinalIgnoreCase)
            {
                { "Lunedì", 1 },
                { "Martedì", 2 },
                { "Mercoledì", 3 },
                { "Giovedì", 4 },
                { "Venerdì", 5 },
                { "Sabato", 6 },
                { "Domenica", 7 }
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

        public static List<string>? OrderDayOfWeekList(this string? daysOfTheWeek)
        {
            if (string.IsNullOrEmpty(daysOfTheWeek))
            {
                return null;
            }

            var days = daysOfTheWeek.Split(',');

            return days
                .Select(day => day.Trim())  // Rimuove gli spazi
                .Where(day => !string.IsNullOrEmpty(day))  // Filtra le stringhe vuote
                .Select(day => Enum.TryParse<DayOfWeek>(day, true, out var dayOfWeek)
                    ? ItalianDaysOfWeek[dayOfWeek]  // Usa il dizionario per ottenere il giorno in italiano
                    : null)
                .Where(italianDay => italianDay != null) // Filtra i giorni non validi
                .OrderBy(day => ItalianDaysOrder.TryGetValue(day, out var order) ? order : 8) // Ordina usando il dizionario
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

        public static string DayToItalianString(this DayOfWeek day)
        {
            return ItalianDaysOfWeek[day];
        }

        public static List<string> GetMissingDays(this List<string> daysOfTheWeek)
        {
            var allDays = ItalianDaysOfWeek.Values.ToList();
            var missingDays = allDays.Except(daysOfTheWeek, StringComparer.OrdinalIgnoreCase).ToList();
            return missingDays.OrderBy(day => ItalianDaysOrder[day]).ToList();
        }





    }


}
