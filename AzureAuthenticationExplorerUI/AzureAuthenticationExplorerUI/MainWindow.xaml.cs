using System.Windows;

using AzureAuthenticationExplorerUI.ViewModels;

namespace AzureAuthenticationExplorerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           ViewModel viewModel = new ViewModel();
            this.DataContext = viewModel;
        }
    }
}
