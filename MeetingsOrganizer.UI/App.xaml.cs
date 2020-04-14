using MeetingsOrganizer.UI.DataServices;
using MeetingsOrganizer.UI.ViewModels;
using System.Windows;
namespace MeetingsOrganizer.UI
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(
                new MainViewModel(
                    new FriendDataService()));

            mainWindow.Show();
        }
    }
}
