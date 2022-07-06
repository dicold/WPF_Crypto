using System.Windows.Controls;
using WPF_Crypto.ViewModels;

namespace WPF_Crypto.Views
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Convert : Page
    {
        public Convert()
        {
            InitializeComponent();
            DataContext = new ConvertViewModel();
        }
    }
}
