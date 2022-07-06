using GalaSoft.MvvmLight;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_Crypto.Models;

namespace WPF_Crypto.ViewModels
{
    internal class ConvertViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public ConvertViewModel()
        {
            ASSETS = new();
        }

        #region Set item collection is the ComboBoxes

        private readonly ObservableCollection<AssetModel> tmp_assets = AssetStoreModel._allAssets;

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
        #endregion

        #region Get an an asset which we are converting
        private AssetModel _firstComboBox = new();
        public AssetModel FirstComboBox
        {
            get { return _firstComboBox; }
            set
            {
                _firstComboBox = value;
                RaisePropertyChanged("FirstComboBox");
            }
        }
        #endregion
        
        #region Get an an asset which we are getting
        private AssetModel _secondComboBox = new();
        public AssetModel SecondComboBox
        {
            get { return _secondComboBox; }
            set
            {
                _secondComboBox = value;
                RaisePropertyChanged("SecondComboBox");
            }
        }
        #endregion

        #region Get a count of crypto we are converting

        private string _count1;
        public string Count1
        {
            get => _count1;
            set
            {
                if (!string.Equals(_count1, value))
                {
                    _count1 = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region Set a count of crypto we are getting

        private string _count2;
        public string Count2
        {
            get => _count2;
            set
            {
                if (!string.Equals(_count2, value))
                {
                    _count2 = value;
                    OnPropertyChanged("Count2");
                }
            }
        }

        private void ConvertCrypto()
        {
            Count2 = ((Convert.ToDouble(_count1) * FirstComboBox.price) / SecondComboBox.price).ToString();

            return;
        }
        #endregion

        #region Converting button
        public ICommand ConvertClick { get => new DelegateCommand(ConvertCrypto); }
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
