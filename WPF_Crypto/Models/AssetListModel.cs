using System.Collections.Generic;
using Newtonsoft.Json;

namespace WPF_Crypto.Models
{
    class AssetListModel
    {
        [JsonProperty("assets")]
        public List<AssetModel> Assets { get; set; }
    }
}
