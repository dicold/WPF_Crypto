using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using WPF_Crypto.Models;

namespace WPF_Crypto.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            CurrentPage = new Views.Pages.Home();
        }

        #region Page changing

        private Page _currentPage;

        public Page CurrentPage
        {
            get => _currentPage;
            set
            {
                if (_currentPage == value)
                    return;

                _currentPage = value;
                RaisePropertiesChanged(nameof(CurrentPage));
            }
        }

        protected void RaisePropertiesChanged(params string[] propertyNames)
        {
            if (propertyNames == null || propertyNames.Length == 0)
            {
                RaisePropertyChanged(string.Empty);
                return;
            }

            foreach (string propertyName in propertyNames)
                RaisePropertyChanged(propertyName);
        }
        #endregion

        #region Navigation bar button commands
        public ICommand MainMenu_Click
        {
            get => new DelegateCommand(() => CurrentPage = new Views.Pages.Home());
        }

        public ICommand InfoMenu_Click
        {
            get => new DelegateCommand(() => CurrentPage = new Views.Info());
        }

        public static ICommand Exit_Click
        {
            get => new DelegateCommand(() => Application.Current.Shutdown());
        }
        #endregion
    }
}