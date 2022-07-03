using GalaSoft.MvvmLight;
using Prism.Commands;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF_Crypto.ViewModels
{
    class MainViewModel : ViewModelBase
    {
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

        public MainViewModel()
        {
            CurrentPage = new Views.Main();
        }

        #region Button commands
        public ICommand MainMenu_Click
        {
            get => new DelegateCommand(() => CurrentPage = new Views.Main());
        }

        public ICommand InfoMenu_Click
        {
            get => new DelegateCommand(() => CurrentPage = new Views.Info());
        }

        public ICommand Exit_Click
        {
            get => new DelegateCommand(() => Application.Current.Shutdown());
        }
        #endregion
    }
}