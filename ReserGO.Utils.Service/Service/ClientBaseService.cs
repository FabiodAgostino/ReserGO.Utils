using Microsoft.Extensions.Configuration;
using ReserGO.Utils.DTO.Service;
using ReserGO.Utils.Service.Interface;
using System.Net.Http.Json;

namespace ReserGO.Utils.Service.Service
{
    public class ClientBaseService<T> : BaseApiService<T>, IClientBaseService<T> where T : class
    {

        public ClientBaseService(HttpClient Http, IConfiguration Configuration) : base(Http)
        { }

        public async virtual Task<ServiceResponse<GenericPagedList<T>>> RequestPostWithBody(ServiceType serviceType, string queryString, object postbody)
        {
            return await RequestPostWithBody<GenericPagedList<T>>(serviceType, queryString, postbody);
        }

        /// <summary>
        /// Estrae una lista di oggetti filtrata per username, filtri griglia e filtri oggetto opzionali
        /// </summary>
        /// <param name="username"></param>
        /// <param name="dataSourceRequest"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<GenericPagedList<T>>> SelectAll(string username, object[] args = null)
        {
            var postbody = new { username, args };

            return await RequestPostWithBody(ServiceType.SelectAllByUsername, string.Empty, postbody);
        }

        /// <summary>
        /// Estrae una lista di oggetti filtrata per filtri griglia e filtri oggetto opzionali
        /// </summary>
        /// <param name="dataSourceRequest"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<GenericPagedList<T>>> SelectAll(object[] args = null)
        {
            var postbody = new { args };

            return await RequestPostWithBody(ServiceType.SelectAll, string.Empty, postbody);
        }

        /// <summary>
        /// Estra un oggetto per ID
        /// </summary>
        /// <param name="id_dto"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<T>> SelectById(int id_dto)
        {
            return await HttpClient.GetFromJsonAsync<ServiceResponse<T>>(string.Format("{0}?id_dto={1}", GetCommandUrl(ServiceType.SelectById), id_dto));
        }

        /// <summary>
        /// Estra una lista di oggetti filtrata per lista di id e filtro datasource griglia
        /// </summary>
        /// <param name="idList"></param>
        /// <param name="dataSourceRequest"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<GenericPagedList<T>>> SelectByIDList(List<int> idList)
        {
            var postbody = new { idList };
            return await RequestPostWithBody(ServiceType.SelectByIDList, string.Empty, postbody);
        }
    }
}
