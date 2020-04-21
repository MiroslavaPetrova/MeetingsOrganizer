using MeetingsOrganizer.UI.DataServices;
using MeetingsOrganizer.UI.Events;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsOrganizer.UI.ViewModels
{
    public class NavigationViewModel : BaseNotifyPropertyChangedModel, INavigationViewModel
    {
        private readonly IFriendLookupDataService friendLookupService;
        private readonly IEventAggregator eventAggregator;

        public NavigationViewModel(IFriendLookupDataService friendLookupService,
            IEventAggregator eventAggregator)
        {
            this.friendLookupService = friendLookupService;
            this.eventAggregator = eventAggregator;
            this.Friends = new ObservableCollection<NavigationItemViewModel>();
            this.eventAggregator.GetEvent<AfterFriendSavedEvent>().Subscribe(AfterFriendSaved);
        }

        private void AfterFriendSaved(AfterFriendSavedEventArgs frinedArgs)
        {
            var lookupItem = this.Friends.Single(item => item.Id == frinedArgs.Id);
            lookupItem.DisplayMember = frinedArgs.DisplayMember;
        }

        public async Task LoadAsync()
        {
            var lookups = await this.friendLookupService.GetFriendLookupAsync();
            Friends.Clear();

            foreach (var item in lookups)
            {
                Friends.Add(new NavigationItemViewModel(item.Id, item.DisplayMember));
            }
        }

        public ObservableCollection<NavigationItemViewModel> Friends { get; set; }

        private NavigationItemViewModel selectedFriend;

        public NavigationItemViewModel SelectedFriend
        {
            get { return this.selectedFriend; }
            set
            {
                this.selectedFriend = value;
                OnPropertyChanged();

                if(this.selectedFriend != null)
                {
                    this.eventAggregator.GetEvent<OpenUpFriendDetailsViewEvent>()
                        .Publish(this.selectedFriend.Id);
                }
            }
        }
    }
}
