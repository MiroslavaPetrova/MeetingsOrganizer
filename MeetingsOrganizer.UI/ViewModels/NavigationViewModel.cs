using MeetingsOrganizer.Models;
using MeetingsOrganizer.UI.DataServices;
using MeetingsOrganizer.UI.Events;
using Prism.Events;
using System.Collections.ObjectModel;
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
            this.Friends = new ObservableCollection<LookupItem>();
        }

        public async Task LoadAsync()
        {
            var lookups = await this.friendLookupService.GetFriendLookupAsync();
            Friends.Clear();

            foreach (var item in lookups)
            {
                Friends.Add(item);
            }
        }

        public ObservableCollection<LookupItem> Friends { get; set; }

        private LookupItem selectedFriend;

        public LookupItem SelectedFriend
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
