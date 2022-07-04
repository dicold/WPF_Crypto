using System.Windows.Controls;
using WPF_Crypto.ViewModels;

namespace WPF_Crypto.Views.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            DataContext = new HomeViewModel();
        }
    }
}
