using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WPF_Crypto.Models
{
    class AssetList
    {
        [JsonProperty("assets")]
        public List<Asset> Assets { get; set; }
    }
}
