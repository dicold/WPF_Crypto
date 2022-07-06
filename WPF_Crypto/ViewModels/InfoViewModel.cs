using GalaSoft.MvvmLight;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WPF_Crypto.Models;
using WPF_Crypto.ViewModels.Base;

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

        #region Item collection

        private ObservableCollection<AssetModel> _Assets = new();
        public ObservableCollection<AssetModel> Assets
        {
            get => _Assets;
            set
            {
                if (Set(ref _Assets, value))
                {
                    _AssetsViewSource = new CollectionViewSource
                    {
                        Source = value
                    };

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
        public ICollectionView AssetsView => _AssetsViewSource?.View;

        private AssetModel _SelectedAsset;
        public AssetModel SelectedAsset { get => _SelectedAsset;
            set
            {
                Set(ref _SelectedAsset, value);
                TEXT = CreateText(_SelectedAsset);
            } 
        }
        #endregion

        #region Text creation
        private string _TEXT;

        public string TEXT
        {
            get => _TEXT;
            set
            {
                _TEXT = value;
                OnPropertyChanged("TEXT");
            }
        }

        public string CreateText(AssetModel asset)
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
    }
}
