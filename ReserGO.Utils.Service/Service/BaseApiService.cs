using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using ReserGO.Utils.DTO.Service;
using ReserGO.Utils.Service.Interface;
using ReserGO.Utils.DTO.Utils;

namespace ReserGO.Utils.Service.Service
{
    public class BaseApiService<T> : IBaseApiService<T> where T : class
    {

        private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new TimeSpanToStringConverter() }
        };

        protected HttpClient HttpClient;
        protected string Server;
        protected string ExtraBaseUrl;


        public BaseApiService(HttpClient Http)
        {
            HttpClient = Http;
          
        }

        public virtual string GetCommandUrl(ServiceType serviceType)
        {
            string basecommand = string.Format("{0}api/{1}/", Server,
                string.IsNullOrEmpty(ExtraBaseUrl) ? typeof(T).Name : ExtraBaseUrl);
            string command = serviceType == ServiceType.Base
                ? basecommand
                : string.Format("{0}{1}", basecommand, serviceType.ToString());
            return command;
        }


        public async virtual Task<ServiceResponse<Q>> PostItem<Q>(T item, ServiceType serviceType)
        {
            var res = await HttpClient.PostAsJsonAsync(GetCommandUrl(serviceType), item);
            if (res.IsSuccessStatusCode || res.StatusCode == HttpStatusCode.BadRequest)
            {
                var itemRes =
                    await res.Content.ReadFromJsonAsync<ServiceResponse<Q>>((JsonSerializerOptions)null, default);
                return itemRes;
            }
            else
            {
                var message = res.Content.ReadAsStringAsync();
                var ex = new Exception($"The service returned with status {res.StatusCode} message:{message}");
                throw ex;
            }
        }

        public async virtual Task<ServiceResponse<Q>> DeleteItemById<Q>(int itemId, ServiceType serviceType, string propertyName)
        {
            try
            {
                string url = $"{GetCommandUrl(serviceType)}?{propertyName}={itemId}";
                var response = await HttpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Q>>(jsonSerializerOptions);
                    return result;
                }

                string error = await response.Content.ReadAsStringAsync();
                throw new Exception($"The service returned with status {response.StatusCode} message: {error}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting item with ID {itemId}: {ex.Message}");
                throw;
            }
        }

        public async virtual Task<ServiceResponse<Q>> PutItem<Q>(T item, ServiceType serviceType)
        {
            var res = await HttpClient.PutAsJsonAsync(GetCommandUrl(serviceType), item);
            if (res.IsSuccessStatusCode || res.StatusCode == HttpStatusCode.BadRequest)
            {
                var itemRes =
                    await res.Content.ReadFromJsonAsync<ServiceResponse<Q>>((JsonSerializerOptions)null, default);
                return itemRes;
            }
            else
            {
                var message = res.Content.ReadAsStringAsync();
                var ex = new Exception($"The service returned with status {res.StatusCode} message:{message}");
                throw ex;
            }
        }


        public async virtual Task<ServiceResponse<Q>> RequestGet<Q>(ServiceType serviceType, string queryString)
        {
            try
            {
                string queryS;

                if (!string.IsNullOrEmpty(queryString))
                {
                    queryS = string.Format("{0}?{1}", GetCommandUrl(serviceType), queryString);
                }
                else
                {
                    queryS = GetCommandUrl(serviceType);
                }

                HttpResponseMessage res = await HttpClient.GetAsync(queryS);
                if (res.IsSuccessStatusCode || res.StatusCode == HttpStatusCode.BadRequest)
                {
                    var result = await res.Content.ReadFromJsonAsync<ServiceResponse<Q>>();
                    return result;
                }

                var message = res.Content.ReadAsStringAsync();
                var ex = new Exception($"The service returned with status {res.StatusCode} message:{message}");
                throw ex;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }

        }


        public async virtual Task RequestPost(ServiceType serviceType, string queryString)
        {
            string queryS;

            if (!string.IsNullOrEmpty(queryString))
            {
                queryS = string.Format("{0}?{1}", GetCommandUrl(serviceType), queryString);
            }
            else
            {
                queryS = GetCommandUrl(serviceType);
            }

            HttpResponseMessage response = await HttpClient.PostAsync(queryS, null);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                string error = await response.Content.ReadAsStringAsync();
                throw new Exception($"The service returned with status {response.StatusCode} message:{error}");
            }
        }

        public async Task<ServiceResponse<R>> RequestPost<Q, R>(ServiceType serviceType, string queryString, Q body)
        {
            string queryS;

            if (!string.IsNullOrEmpty(queryString))
                queryS = string.Format("{0}?{1}", GetCommandUrl(serviceType), queryString);
            else
                queryS = GetCommandUrl(serviceType);

            HttpResponseMessage res = await HttpClient.PostAsJsonAsync<Q>(queryS, body);

            if (res.IsSuccessStatusCode || res.StatusCode == HttpStatusCode.BadRequest)
                return await res.Content.ReadFromJsonAsync<ServiceResponse<R>>();
            else
            {
                string error = await res.Content.ReadAsStringAsync();
                throw new Exception($"The service returned with status {res.StatusCode} message:{error}");
            }
        }

        public async virtual Task<ServiceResponse<Q>> RequestPostWithBody<Q>(ServiceType serviceType,
            string queryString, object postbody)
        {
            string queryS;

            if (!string.IsNullOrEmpty(queryString))
            {
                queryS = string.Format("{0}?{1}", GetCommandUrl(serviceType), queryString);
            }
            else
            {
                queryS = GetCommandUrl(serviceType);
            }

            HttpResponseMessage response = await HttpClient.PostAsJsonAsync(queryS, postbody);

            if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return await response.Content.ReadFromJsonAsync<ServiceResponse<Q>>(jsonSerializerOptions);
            }

            string error = await response.Content.ReadAsStringAsync();
            throw new Exception($"The service returned with status {response.StatusCode} message:{error}");
        }
    }
}