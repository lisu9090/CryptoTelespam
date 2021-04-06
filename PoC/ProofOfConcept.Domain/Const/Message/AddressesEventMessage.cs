using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Application.Const.Message
{
    internal class AddressesEventMessage
    {
        public const string ACTIVE_ADDRESSES_NOTIFICATION = "No Active Addresses event detected a {0} market. Active Addresses count is {1}.";
        public const string NEW_ADDRESSES_NOTIFICATION = "No New Addresses event detected at {0} market. New Addresses count is {1}.";
        public const string TOTAL_ADDRESSES_NOTIFICATION = "No Total Addresses event detected at {0} market. Total Addresses count is {1}.";
    }
}
