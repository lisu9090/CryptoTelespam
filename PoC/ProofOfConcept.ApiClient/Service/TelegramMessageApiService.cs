using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.ApiClient.Helper;
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
        private readonly ILogger<TelegramMessageApiService> _logger;
        private readonly HttpClient _httpClient;

        public TelegramMessageApiService(int timeout,
            string apiBase,
            string messageTargetParamName,
            string messageTarget,
            HttpClient httpClient,
            ILogger<TelegramMessageApiService> logger)
        {
            _timeout = timeout;
            _apiBase = apiBase;
            _messageTargetParamName = messageTargetParamName;
            _messageTarget = messageTarget;
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task SendAsync(string msg)
        {
            string uri = new UriBuilder(_apiBase, _messageTargetParamName, _messageTarget)
                .SetEndpoint("sendMessage")
                .AddParameter("text", msg)
                .Biuld();

            _logger.LogInformation(uri);

            HttpResponseMessage result = await _httpClient.PostAsync(uri, new ByteArrayContent(new byte[0]));

            if (!result.IsSuccessStatusCode)
            {
                _logger.LogError(result.ReasonPhrase);
            }
        }
    }
}