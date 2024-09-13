using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ReserGO.Utils.MVM.Interface
{
    public interface IBaseViewModel<TModel>
    {
        bool IsFirstLoad { get; set; }
        bool IsLoading { get; set; }
        TModel SelectedItem { get; set; }
        EventCallback NeedDataReloading { get; set; }
        ILogger Logger { get; }
        event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null);
        void Publish(TModel model);
    }
}