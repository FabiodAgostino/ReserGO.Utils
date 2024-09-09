using ReserGO.Utils.DTO.Service;

namespace ReserGO.Utils.Service.Interface
{
    public interface IClientBaseService<TModel> : IBaseApiService<TModel> where TModel : class
    {
        Task<ServiceResponse<GenericPagedList<TModel>>> RequestPostWithBody(ServiceType serviceType, string queryString, object postbody);
        Task<ServiceResponse<GenericPagedList<TModel>>> SelectAll(object[] args = null);
        Task<ServiceResponse<GenericPagedList<TModel>>> SelectAll(string username, object[] args = null);
        Task<ServiceResponse<TModel>> SelectById(int TModeld_dto);
        Task<ServiceResponse<GenericPagedList<TModel>>> SelectByIDList(List<int> idList);
    }
}
