using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Helpers
{
    class UriBuilder
    {
        private string _uriBase;
        private string _endpoint;
        private string _apiKeyParamName;
        private string _apiKey;
        private Dictionary<string, object> _parameters = new Dictionary<string, object>();

        public UriBuilder(string uriBase)
        {
            _uriBase = uriBase;
        }

        public UriBuilder(string uriBase, string apiKeyParamName, string apiKey) : this(uriBase)
        {
            _apiKeyParamName = apiKeyParamName;
            _apiKey = apiKey;
        }

        public UriBuilder SetEndpoint(string endpoint)
        {
            if (string.IsNullOrEmpty(endpoint))
            {
                throw new ArgumentException("Endpoint cannot be null or empty.");
            }

            _endpoint = FixSlashes(endpoint);

            return this;
        }

        public UriBuilder AddParameter(string key, object value)
        {
            if(string.IsNullOrEmpty(key) || value == null)
            {
                throw new ArgumentException("Key and value cannot be null or empty.");
            }

            _parameters.Add(key, value);

            return this;
        }

        public string Biuld()
        {
            var sb = new StringBuilder(_uriBase);

            sb.Append(_endpoint);

            if(_parameters.Count() > 0)
            {
                sb.Append("?");

                var paramString = string.Join("&", _parameters.Select(keyValue => $"{keyValue.Key}={keyValue.Value}"));

                sb.Append(paramString);
            }

            if (!string.IsNullOrEmpty(_apiKeyParamName))
            {
                sb.Append($"{_apiKeyParamName}={_apiKey}");
            }

            return sb.ToString();
        }

        private string FixSlashes(string input)
        {
            if (!input.StartsWith("/"))
            {
                input = "/" + input;
            }

            if (input.EndsWith("/"))
            {
                input = input.Substring(0, input.Length - 1);
            }

            return input;
        }
    }
}
