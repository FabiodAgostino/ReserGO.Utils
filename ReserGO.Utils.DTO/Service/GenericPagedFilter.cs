namespace ReserGO.Utils.DTO.Service
{
    public class GenericPagedFilter<T>
    {
        public T Filter { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public int? TotalCount { get; set; }
    }
}
