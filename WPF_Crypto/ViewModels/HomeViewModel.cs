using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using WPF_Crypto.Models;

namespace WPF_Crypto.ViewModels
{
    class HomeViewModel : ViewModelBase
    {
        public HomeViewModel()
        {
            Asset10 = new ObservableCollection<AssetModel>();
            _view = new ListCollectionView(_asset10);
        }

        #region Get a Top 10

        private ObservableCollection<AssetModel> _asset10 = new();
        public ObservableCollection<AssetModel> Asset10
        {
            get => _asset10;
            set
            {
                for (int i = 0; i < 10; i++)
                    _asset10.Add(AssetStoreModel._allAssets[i]);
            }
        }
        #endregion

        #region List => ListCollection

        private ListCollectionView _view;

        public ICollectionView View
        {
            get => _view;
        }
        #endregion
    }
}
