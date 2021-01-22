using ProofOfConcept.AbstractDomain.Model;
using System;

namespace ProofOfConcept.Domain.Model
{
    internal class Entity : ICryptocurrencyIndicator
    {
        private string _cryptocurrencySymbol = "";
        
        public string CryptocurrencySymbol {
            get
            {
                return _cryptocurrencySymbol;
            }

            set 
            {
                if (string.IsNullOrEmpty(_cryptocurrencySymbol))
                {
                    _cryptocurrencySymbol = value;
                }
            }
        }
    }
}
