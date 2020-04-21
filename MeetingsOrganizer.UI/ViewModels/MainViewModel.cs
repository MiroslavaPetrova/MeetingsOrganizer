using System.Threading.Tasks;

namespace MeetingsOrganizer.UI.ViewModels
{
    public partial class MainViewModel : BaseNotifyPropertyChangedModel
    {
        //private readonly INavigationViewModel navigationViewModel;

        public MainViewModel(INavigationViewModel navigationViewModel,
            IFriendDetailsViewModel friendDetailsViewModel)
        {
            this.NavigationViewModel = navigationViewModel;
            this.FriendDetailsViewModel = friendDetailsViewModel;
        }

        public INavigationViewModel NavigationViewModel { get; }

        public IFriendDetailsViewModel FriendDetailsViewModel { get; }

        public async Task LoadAsync()
        {
            await this.NavigationViewModel.LoadAsync();
        }
    }
}
