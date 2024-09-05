using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ReserGO.Utils.MVM.Interface;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Claims;

namespace ReserGO.Utils.UI;

public partial class BaseComponent<TViewModel, TModel> where TViewModel : IBaseViewModel<TModel> where TModel : class
{
    public BaseComponent()
    {
    }

    [Inject]
    public ILocalStorageService LocalStorageService { get; set; }

    [Inject]
    public TViewModel BaseViewModel { get; set; }

    [Parameter]
    public AuthenticationState BaseAuthenticationState { get; set; }

    [Parameter]
    public RenderFragment Content { get; set; }

    private static int cnt = 0;

    protected override async Task OnInitializedAsync()
    {
        if (BaseViewModel != null)
        {
            BaseViewModel.PropertyChanged += OnPropertyChangedHandler;
        }
        
        if (BaseAuthenticationState != null)
        {
            var username = BaseAuthenticationState.User.Identity.Name;
            if (BaseAuthenticationState.User.Claims.ToList().LastOrDefault().Type == ClaimTypes.AuthenticationInstant)
                username = BaseAuthenticationState.User.Claims.ToList().LastOrDefault().Value;
            Debug.WriteLine($"cnt: {cnt++} username:{username} type:{typeof(TViewModel).Name}");
        }

        await base.OnInitializedAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
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