namespace ReserGO.Utils.DTO.Utils
{
    public enum AvailabilityType
    {
        /// <summary>
        /// Non disponibile in un giorno specifico 
        /// Esempio: l'admin non vuole che la risorsa sia prenotabile il 25 dicembre perchè Il negozio è chiuso.
        /// Proprietà utilizzate: SpecificDate
        /// </summary>
        UnavailableSpecificDay,

        /// <summary>
        /// Non disponibile in base ai giorni della settimana (es. chiuso il lunedì e martedì)
        /// Proprietà Utilizzate DaysOfTheWeek
        /// </summary>
        UnavailableByDaysOfTheWeek,

        /// <summary>
        /// Non disponibile in un orario ricorrente (es. ogni giovedì dalle 19:00 alle 21:00)
        /// es2: non disponibile tutti i giorni dalle 00:00 alle 09:00
        /// Proprietà utilizzate: DaysOfTheWeek (scrivi i giorni), StartTime, EndTime
        /// </summary>
        UnavailableRecurringTime,

        
        /// <summary>
        /// Non disponibile in un giorno specifico con orario specifico (es. 14 dicembre dalle 14:00 alle 15:00) DA USARE SOLO NELLA MODIFICA DELLA RISORSA PER GIORNI SPECIFICI 
        /// Esempio: L'admin ha bisogno che domani la risorsa non sia disponibile dalle ore 13 alle ore 19
        /// Proprietà utilizzate: SpecificDay, EndDateTime
        /// </summary>
        UnavailableTimeDateSlot,

        /// <summary>
        /// Non disponibile in generale (es. prodotto non disponibile) DA USARE SOLO NELLA MODIFICA DELLA RISORSA
        /// </summary>
        UnavailableGeneral,
    }
}
