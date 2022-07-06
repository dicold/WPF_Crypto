using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Crypto.Models;

namespace WPF_Crypto.ViewModels
{
    internal class ConvertViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public ConvertViewModel()
        {
            ASSETS = new();
        }

        private readonly ObservableCollection<AssetModel> tmp_assets = AssetStoreModel._allAssets;

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<AssetModel> _ASSETS = new();
        public ObservableCollection<AssetModel> ASSETS
        {
            get => _ASSETS;
            set
            {
                for (int i = 0; i < tmp_assets.Count; i++)
                {
                    _ASSETS.Add(tmp_assets[i]);
                }
            }
        }

        private AssetModel firstPortfolioToCompare;
        public AssetModel FirstPortfolioToCompare
        {
            get { return firstPortfolioToCompare; }
            set
            {
                firstPortfolioToCompare = value;
                RaisePropertyChanged("FirstPortfolioToCompare");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
