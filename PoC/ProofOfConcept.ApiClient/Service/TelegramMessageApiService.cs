﻿using ProofOfConcept.AbstractApiClient;
using ProofOfConcept.ApiClient.Helpers;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProofOfConcept.ApiClient.Service
{
    public class TelegramMessageApiService : IMessageApiService
    {
        private readonly int _timeout;
        private readonly string _apiBase;
        private readonly string _messageTargetParamName;
        private readonly string _messageTarget;
        private HttpClient _httpClient;

        public TelegramMessageApiService(int timeout, string apiBase, string messageTargetParamName, string messageTarget, HttpClient httpClient)
        {
            _timeout = timeout;
            _apiBase = apiBase;
            _messageTargetParamName = messageTargetParamName;
            _messageTarget = messageTarget;
            _httpClient = httpClient;
        }

        public async Task SendAsync(string msg)
        {
            var uri = new UriBuilder(_apiBase, _messageTargetParamName, _messageTarget)
                .SetEndpoint("/sendMessage")
                .AddParameter("text", msg)
                .Biuld();


            var result = await _httpClient.PostAsync(uri, new ByteArrayContent(new byte[0]));

            if (!result.IsSuccessStatusCode)
            {
                //todo log message
            }
        }
    }
}