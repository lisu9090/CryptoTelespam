using ProofOfConcept.ServiceWorker.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Helpers
{
    class JsonApiAdapter : IRestApiAdapter
    {
        private const int TIMEOUT = 30; //TODO move to config
        private HttpClient _httpClient;

        public JsonApiAdapter(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> QueryAsync(HttpMethod method, string url, params object[] paramters)
        {
            var response = await _httpClient.SendAsync(new HttpRequestMessage(method, url));
            var responseString = "";

            if(response.StatusCode == HttpStatusCode.OK)
            {
                responseString = await response.Content.ReadAsStringAsync();
            }

            return responseString;
        }
    }
}
