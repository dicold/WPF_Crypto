namespace WPF_Crypto.Models
{
    internal class MarketModel
    {
        public string exchange_id { get; set; }
        public string symbol { get; set; }
        public string base_asset { get; set; }
        public string quote_asset { get; set; }
        public string price_unconverted { get; set; }
        public string price { get; set; }
        public string change_24h { get; set; }
        public string spread { get; set; }
        public string volume_24h { get; set; }
    }
}
