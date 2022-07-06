using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;

namespace WPF_Crypto.Models
{
    /// <summary>
    /// Loading and storing the full dataset of cryptocurrencies
    /// </summary>
    internal static class AssetStoreModel
    {
        public static ObservableCollection<AssetModel> _allAssets;

        public static ObservableCollection<AssetModel> AllAssets
        {
            get => _allAssets;
            set => _allAssets = value;
        }

        public static void CreateAsset()
        {
            AllAssets = new ObservableCollection<AssetModel>(LoadCryptoAsset());
        }

        public static List<AssetModel> LoadCryptoAsset()
        {
            string url = "https://www.cryptingup.com/api/assets";
            try
            {
                string JSON = new WebClient().DownloadString(url);
                var data = JsonConvert.DeserializeObject<AssetListModel>(JSON);
                return data.Assets.ToList();
            }
            catch (Exception exp)
            {
                throw new InvalidOperationException("Can`t get the data.", exp);
            }
        }
    }
}
