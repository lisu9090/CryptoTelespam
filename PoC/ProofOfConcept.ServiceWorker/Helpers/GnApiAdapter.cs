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
    class GnApiAdapter : IRestApiAdapter
    {

        private const int TIMEOUT = 30; //TODO move to config
        private HttpClient _httpClient;

        public GnApiAdapter(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<string> GetNuplAsync(string asset, int sinceTimeStamp = int.MinValue, int untilTimeStamp = int.MaxValue, string interval = "24h", string format = "JSON")
        {

            throw new NotImplementedException();
        }

        //public async Task<string> QueryAsync(HttpMethod method, string url, params object[] paramters)
        //{

        //    var uri = "https://api.glassnode.com/v1/metrics/indicators/net_unrealized_profit_loss";

        //    var response = await _httpClient.SendAsync(new HttpRequestMessage(method, url));
        //    var responseString = "";

        //    if(response.StatusCode == HttpStatusCode.OK)
        //    {
        //        responseString = await response.Content.ReadAsStringAsync();
        //    }

        //    return responseString;
        //}
    }
}
