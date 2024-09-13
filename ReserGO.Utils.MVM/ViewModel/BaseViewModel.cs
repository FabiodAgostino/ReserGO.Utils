using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ReserGO.Utils.Event;
using ReserGO.Utils.MVM.Interface;

namespace ReserGO.Utils.MVM.ViewModel
{
    public class BaseViewModel<TModel> : IBaseViewModel<TModel> where TModel : class
    {
        #region Private Variables

        protected TModel selectedItem;
        protected bool isLoading = true;
        protected bool isFirstLoad = true;

        #endregion

        public BaseViewModel(IEvent aggregator, ILogger logger)
        {
            Aggregator = aggregator;
            Logger = logger;
        }

        public readonly IEvent Aggregator;
        public ILogger Logger { get; }

        #region Public Events

        public EventCallback NeedDataReloading { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Methods
        public virtual void Publish(TModel model)
        {
        }

        #endregion

        #region Public Properties

        public TModel SelectedItem
        {
            get => selectedItem;

            set
            {
                if (value != null && !value.Equals(selectedItem))
                {
                    selectedItem = value;
                    Publish(selectedItem);
                    OnPropertyChanged();
                }
            }
        }

        public bool IsLoading
        {
            get => isLoading;
            set
            {
                if (value != isLoading)
                {
                    isLoading = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsFirstLoad
        {
            get => isFirstLoad;
            set
            {
                if (value != isFirstLoad)
                {
                    isFirstLoad = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Private Methods

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}