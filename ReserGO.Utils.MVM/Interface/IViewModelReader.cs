namespace ReserGO.Utils.MVM.Interface
{
    public interface IViewModelReader<TModel> : IBaseViewModel<TModel>
    {
        Task Refresh(bool reload);

    }
}