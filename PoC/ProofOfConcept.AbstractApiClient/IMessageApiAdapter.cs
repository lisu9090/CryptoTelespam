using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.AbstractApiClient
{
    public interface IMessageApiAdapter
    {
        Task SendAsync(string msg);
    }
}
