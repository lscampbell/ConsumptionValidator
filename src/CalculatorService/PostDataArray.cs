using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CalculatorService
{
    public class PostDataArray
    {
        readonly string _postData; 
        public PostDataArray(dynamic data) => _postData = JsonConvert.SerializeObject(data);
        public async Task<bool> MakeCallAsync(string path)
        {            // Create a request using a URL that can receive a post.   
            using (var client = new HttpClient())
            {
                await client.PostAsync(path, new StringContent(_postData, Encoding.UTF8, "application/json"));
            }
            return true;
        }
    }
}