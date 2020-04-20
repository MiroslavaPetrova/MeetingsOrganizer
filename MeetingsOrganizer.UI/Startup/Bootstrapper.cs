using Autofac;
using MeetingsOrganizer.Data;
using MeetingsOrganizer.UI.DataServices;
using MeetingsOrganizer.UI.ViewModels;

namespace MeetingsOrganizer.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MeetingsOrganizerDbContext>().AsSelf(); 
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<FriendDataService>().As<IFriendDataService>();


            return builder.Build();
        }
    }
}
