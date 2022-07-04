using System.Windows.Controls;
using WPF_Crypto.ViewModels;

namespace WPF_Crypto.Views
{
    /// <summary>
    /// Interaction logic for Info.xaml
    /// </summary>
    public partial class Info : Page
    {
        public Info()
        {
            InitializeComponent();
            DataContext = new InfoViewModel();
        }
    }
}
