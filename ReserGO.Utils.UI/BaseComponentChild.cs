using Microsoft.AspNetCore.Components;
using ReserGO.Utils.MVM.Interface;

namespace ReserGO.Utils.UI
{
    public class BaseComponentChild<TViewModel, TModel> : ComponentBase where TModel : class where TViewModel : IBaseViewModel<TModel>
    {
        protected TModel SelectedModel;

        [CascadingParameter(Name = "ViewModelInstance")]
        public IBaseViewModel<TModel> ViewModel { get; set; }

        public TViewModel CurrentViewModel { get => (TViewModel)ViewModel; }

    }
}
