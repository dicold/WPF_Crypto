using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF_Crypto.ViewModels
{
    class InfoViewModel : ViewModelBase
    {
        public ICommand Test_Click
        {
            get { return new RelayCommand(() => MessageBox.Show("Test")); }
        }
    }
}
