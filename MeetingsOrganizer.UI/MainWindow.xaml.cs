using MeetingsOrganizer.UI.ViewModels;
using System.Windows;

namespace MeetingsOrganizer.UI
{
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;

        public MainWindow(MainViewModel model)
        {
            InitializeComponent();
            viewModel = model;
            DataContext = viewModel;
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel.Load();
        }
    }
}
