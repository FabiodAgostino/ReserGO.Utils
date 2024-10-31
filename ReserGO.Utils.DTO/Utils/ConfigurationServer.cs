namespace ReserGO.Utils.DTO.Utils
{
    public enum  ExtendedInput
    {
        SIMPLE,
        ADVANCED
    }

    public class ConfigurationServer
    {
        public ExtendedInput ExtendedInput { get; set; }
        public bool Manutenzione { get; set; }
    }
}
