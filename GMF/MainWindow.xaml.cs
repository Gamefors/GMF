using GMF.Directory.ViewModel;
using System.Windows;

namespace GMF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainContentViewModel();
        }
    }
}
