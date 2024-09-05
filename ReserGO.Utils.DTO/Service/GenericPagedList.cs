namespace ReserGO.Utils.DTO.Service
{
    public class GenericPagedList<T>
    {
        public List<T> CurrentPageData { get; set; }
        public int TotalItemCount { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }

    }
}
