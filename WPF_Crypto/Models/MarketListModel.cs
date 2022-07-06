using System.Collections.Generic;
using Newtonsoft.Json;

namespace WPF_Crypto.Models
{
    internal class MarketListModel
    {
        [JsonProperty("markets")]
        public List<MarketModel> Markets { get; set; }
    }
}