using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Abstract
{
    interface IRestApiAdapter
    {
        Task<string> QueryAsync(HttpMethod method, string url, params object[] paramters);
    }
}
