using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using WPF_Crypto.Models;

namespace WPF_Crypto.ViewModels
{
    class InfoViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public InfoViewModel()
        {
            Assets = new ObservableCollection<AssetModel>(tmp_assets);
        }

        private readonly ObservableCollection<AssetModel> tmp_assets = AssetStoreModel._allAssets;

        #region Item filter

        private string _Filter;
        public string Filter
        {
            get => _Filter;
            set
            {
                if (Set(ref _Filter, value))
                    _AssetsViewSource?.View.Refresh();
            }
        }

        /// <summary>
        /// Filter for all assets
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FilterAssets(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(Filter))
                e.Accepted = true;
            else
            {
                AssetModel asset = (AssetModel)e.Item;
                e.Accepted = asset.asset_id.ToUpper().Contains(Filter.ToUpper()) || asset.name.ToUpper().Contains(Filter.ToUpper());
            }
        }
        #endregion

        #region Assets item collection

        private ObservableCollection<AssetModel> _Assets = new();
        public ObservableCollection<AssetModel> Assets
        {
            get => _Assets;
            set
            {
                if (Set(ref _Assets, value))
                {
                    _AssetsViewSource = new CollectionViewSource { Source = value };

                    _AssetsViewSource.View.Filter = item => true;
                    _AssetsViewSource.Filter += FilterAssets;
                    _AssetsViewSource.View.Refresh();

                    OnPropertyChanged(nameof(AssetsView));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? PropertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));

        private CollectionViewSource _AssetsViewSource;
        public ICollectionView? AssetsView => _AssetsViewSource?.View;

        private AssetModel _SelectedAsset;
        public AssetModel SelectedAsset
        {
            get => _SelectedAsset;
            set
            {
                Set(ref _SelectedAsset, value);
                TextInfo = CreateInfoText(_SelectedAsset);
                TextShop = CreateShopText(LoadMarketAsset(_SelectedAsset));
            } 
        }
        #endregion

        #region Information text about selected cryptocurrency

        private string _TextInfo;

        public string TextInfo
        {
            get => _TextInfo;
            set
            {
                _TextInfo = value;
                OnPropertyChanged("TextInfo");
            }
        }

        /// <summary>
        /// Creating a text with all information about selected cryptocurrency
        /// </summary>
        /// <param name="asset"></param>
        /// <returns></returns>
        public string CreateInfoText(AssetModel asset)
        {
            string res = "\t" + asset.asset_id + "\t" + asset.name
            + "\n\nPrice:\n\t" + asset.price
            + "$\nVolume:\n\t" + asset.volume_24h
            + "\nChange:\nFor 1 hour:     " + asset.change_1h
            + "%\nFor 24 hours:  " + asset.change_24h 
            + "%\nFor 7 days:      " + asset.change_7d + "%";

            return res;
        }
        #endregion

        #region Where to buy selected cryptocurrency

        private string _TextShop;

        public string TextShop
        {
            get => _TextShop;
            set
            {
                _TextShop = value;
                OnPropertyChanged("TextShop");
            }
        }
        /// <summary>
        /// Creating a text (website + price) about all available markets for selected cryptocurrency
        /// </summary>
        /// <param name="markets"></param>
        public string CreateShopText(List<MarketModel> markets)
        {
            string res = "";

            for (int i = 0; i < markets.Count; i++)
            {
                res += markets[i].exchange_id + ".com";
                if (markets[i].exchange_id.Length > 8)
                    res += "\t";
                else
                    res += "\t\t";
                res += markets[i].price_unconverted + "$\n";
            }

            return res;
        }

        /// <summary>
        /// Loading the list of markets for selected cryptocurrency
        /// </summary>
        /// <param name="asset"></param>
        public static List<MarketModel> LoadMarketAsset(AssetModel asset)
        {
            string url = "https://www.cryptingup.com/api/assets/" + asset.asset_id + "/markets";
            try
            {
                string JSON = new WebClient().DownloadString(url);
                var data = JsonConvert.DeserializeObject<MarketListModel>(JSON);
                return data.Markets.ToList();
            }
            catch (Exception exp)
            {
                throw new InvalidOperationException("Can`t get the data.", exp);
            }
        }
        #endregion
    }
}
