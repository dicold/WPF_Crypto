using Newtonsoft.Json;
using System.ComponentModel;

namespace WPF_Crypto.Models
{
    internal class AssetModel
    {
        public string asset_id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public double volume_24h { get; set; }
        public double change_1h { get; set; }
        public double change_24h { get; set; }
        public double change_7d { get; set; }
        public string status { get; set; }
    }
}
