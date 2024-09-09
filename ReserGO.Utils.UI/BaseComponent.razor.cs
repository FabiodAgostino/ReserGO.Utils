using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ReserGO.Utils.MVM.Interface;
using System.ComponentModel;

namespace ReserGO.Utils.UI
{
    public partial class BaseComponent<TViewModel, TModel> where TViewModel : IBaseViewModel<TModel> where TModel : class
    {

        [Inject]
        public TViewModel BaseViewModel { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }


        [Parameter]
        public AuthenticationState BaseAuthenticationState { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (BaseViewModel != null)
            {
                BaseViewModel.PropertyChanged += OnPropertyChangedHandler;
            }

            await base.OnInitializedAsync();
        }

        private async void OnPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            await InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }

        public void Dispose()
        {
            if (BaseViewModel != null)
                BaseViewModel.PropertyChanged -= OnPropertyChangedHandler;
        }
    }
}
