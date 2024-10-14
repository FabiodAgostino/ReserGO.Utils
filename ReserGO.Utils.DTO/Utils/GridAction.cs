using ReserGO.Utils.DTO.Service;

namespace ReserGO.Utils.DTO.Utils
{
    public class GridAction<T, F>
    {
        public IEnumerable<T> Items { get; set; }
        public F Filter { get; set; }
        public TypeActionsGRID TypeActions { get; set; }
        public string? Error { get; set; }
        public GenericPagedFilter<F> PagingOptions { get; set; }

        public GridAction()
        {

        }
        public GridAction(IEnumerable<T> items, TypeActionsGRID typeActions)
        {
            Items = items;
            TypeActions = typeActions;
        }

        public GridAction(IEnumerable<T> items, TypeActionsGRID typeActions, string error)
        {
            Items = items;
            TypeActions = typeActions;
            Error = error;
        }

        public GridAction(GenericPagedFilter<F> pagingOptions, TypeActionsGRID typeActions, string error)
        {
            PagingOptions = pagingOptions;
            TypeActions = typeActions;
            Error = error;
        }
        public GridAction(F filter, TypeActionsGRID typeActions, string error)
        {
            Filter = filter;
            TypeActions = typeActions;
            Error = error;
        }
    }

    public enum TypeActionsGRID
    {
        INSERT = 0,
        UPDATE = 1,
        SINGLE_DELETE = 2,
        MULTIPLE_DELETE = 3,
        GENERIC_DELETE = 4,
        APPROVED = 5,
        NOT_APPROVED = 6,
        MARK_CHECKED = 7,
        EXPORT_CSV = 8,
        PAGE_CHANGED = 9,
        PAGE_SIZE_CHANGED = 10,
        FILTER,
    }
}
