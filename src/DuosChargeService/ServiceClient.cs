using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DuosChargeService
{
    public class ServiceClient<TRequest,TResponse>
    {
        readonly string _baseUrl;
        readonly string _path;

        public ServiceClient(string baseUrl, string path)
        {
            _path = path;
            _baseUrl = baseUrl;
        }

        public async Task<TResponse> PostAsync(TRequest request)
        {
            var client = new HttpClient { BaseAddress = new Uri(_baseUrl) };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var requestJson = JsonConvert.SerializeObject(request);
            var response = await client.PostAsync(_path, new StringContent(requestJson, Encoding.UTF8, "application/json"));
            var responseJson = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResponse>(responseJson);  
        }
    }
}