using ReserGO.Utils.DTO.Service;

namespace ReserGO.Utils.Service.Interface
{
    public interface IBaseApiService<T> where T : class
    {
        string GetCommandUrl(ServiceType serviceType);
        Task<ServiceResponse<Q>> PostItem<Q>(T item, ServiceType serviceType);
        Task<ServiceResponse<Q>> PutItem<Q>(T item, ServiceType serviceType);
        Task<ServiceResponse<Q?>> RequestGet<Q>(ServiceType serviceType, string queryString);
        Task RequestPost(ServiceType serviceType, string queryString);
        Task<ServiceResponse<Q>> RequestPostWithBody<Q>(ServiceType serviceType, string queryString, object postbody);
        Task<ServiceResponse<Q>> DeleteItemById<Q>(int itemId, ServiceType serviceType, string propertyName);
    }
}