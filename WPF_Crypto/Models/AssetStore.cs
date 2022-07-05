using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPF_Crypto.Models
{
    /// <summary>
    /// Loading and storing the full dataset of cryptocurrencies
    /// </summary>
    internal static class AssetStore
    {
        public static ObservableCollection<Asset> _allAssets;

        public static ObservableCollection<Asset> AllAssets
        {
            get => _allAssets;
            set => _allAssets = value;
        }

        public static void CreateAsset()
        {
            AllAssets = new ObservableCollection<Asset>(LoadCryptoAsset());
        }

        public static List<Asset> LoadCryptoAsset()
        {
            string url = "https://www.cryptingup.com/api/assets";
            try
            {
                string JSON = new WebClient().DownloadString(url);
                var data = JsonConvert.DeserializeObject<AssetList>(JSON);
                return data.Assets.ToList();
            }
            catch (Exception exp)
            {
                throw new InvalidOperationException("Can`t get the data.", exp);
            }
        }
    }
}
