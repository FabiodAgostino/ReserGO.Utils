using Microsoft.Extensions.Logging;
using ReserGO.Utils.Event;
using ReserGO.Utils.MVM.Interface;
using ReserGO.Utils.MVM.ViewModel;
using ReserGO.Utils.Service.Interface;

namespace Infocad.Blazor.Common.MVM
{
    public class ViewModelReader<TModel> : BaseViewModel<TModel>, IViewModelReader<TModel> where TModel : class
    {
        private readonly IBaseApiService<TModel> _clService;

        public ViewModelReader(IBaseApiService<TModel> clService, IEvent aggregator, ILogger logger) : base(aggregator, logger)
        {
            _clService = clService;
        }

        public virtual async Task Refresh(bool reload)
        {
        }

    }
}
