using Autofac;
using MeetingsOrganizer.UI.Startup;
using System.Windows;
namespace MeetingsOrganizer.UI
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            //  Resolve goes to the Mainwindow ctor
            //  => MainViewModel 
            //  => IFriendDataService
            //  => builder.RegisterType<FriendDataService>().As<IFriendDataService>();
            var mainWindow = container.Resolve<MainWindow>();

            mainWindow.Show();
        }
    }
}
