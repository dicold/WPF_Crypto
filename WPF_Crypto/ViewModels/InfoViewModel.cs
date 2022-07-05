using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using WPF_Crypto.Models;

namespace WPF_Crypto.ViewModels
{
    class InfoViewModel : ViewModelBase
    {
        public InfoViewModel()
        {
            Assets = new();
        }

        #region ComboBox List
        private ObservableCollection<string> _assets = new();
        private readonly ObservableCollection<Asset> tmp_assets = AssetStore._allAssets;

        public ObservableCollection<string> Assets
        {
            get => _assets;
            set
            {
                for (int i = 0; i < tmp_assets.Count; i++)
                {
                    string name = tmp_assets[i].name;
                    if (name != "")
                        _assets.Add(name);
                    string asset_id = tmp_assets[i].asset_id;
                    if (asset_id != "")
                        _assets.Add(asset_id);
                }
            }
        }
        #endregion
    }
}
