using GalaSoft.MvvmLight;
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
using WPF_Crypto.Models;

namespace WPF_Crypto.ViewModels
{
    class HomeViewModel : ViewModelBase
    {
        public HomeViewModel()
        {
            Top10Cryptos = new ObservableCollection<Asset>(LoadCryptoAsset());
            _view = new ListCollectionView(_top10cryptos);
        }

        #region Loading the asset of cryptocurrencies (top 10)

        private ObservableCollection<Asset> _top10cryptos;

        public ObservableCollection<Asset> Top10Cryptos
        {
            get => _top10cryptos;
            set => _top10cryptos = value;
        }
        public List<Asset> LoadCryptoAsset()
        {
            string url = "https://www.cryptingup.com/api/assets?size=10";
            try
            {
                string JSON = new WebClient().DownloadString(url);
                var data = JsonConvert.DeserializeObject<AssetList>(JSON);
                return data.Assets.ToList();
            }
            catch(Exception exp)
            {
                throw new InvalidOperationException("Can`t get the data.", exp);
            }
        }
        #endregion

        #region List => Collection

        private ListCollectionView _view;

        public ICollectionView View
        {
            get => _view;
        }
        #endregion
    }
}
