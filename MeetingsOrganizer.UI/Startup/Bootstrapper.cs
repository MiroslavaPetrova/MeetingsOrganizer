using Autofac;
using MeetingsOrganizer.Data;
using MeetingsOrganizer.UI.DataServices;
using MeetingsOrganizer.UI.ViewModels;
using Prism.Events;

namespace MeetingsOrganizer.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<MeetingsOrganizerDbContext>().AsSelf(); 

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<FriendDetailsViewModel>().As<IFriendDetailsViewModel>();

            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
            builder.RegisterType<FriendDataService>().As<IFriendDataService>();


            return builder.Build();
        }
    }
}
