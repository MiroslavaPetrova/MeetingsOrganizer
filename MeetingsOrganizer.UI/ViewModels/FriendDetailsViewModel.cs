using MeetingsOrganizer.Models;
using MeetingsOrganizer.UI.DataServices;
using MeetingsOrganizer.UI.Events;
using Prism.Events;
using System;
using System.Threading.Tasks;

namespace MeetingsOrganizer.UI.ViewModels
{
    public class FriendDetailsViewModel : BaseNotifyPropertyChangedModel, IFriendDetailsViewModel
    {
        private readonly IFriendDataService friendDataService;
        private readonly IEventAggregator eventAggregator;

        public FriendDetailsViewModel(IFriendDataService friendDataService,
            IEventAggregator eventAggregator)
        {
            this.friendDataService = friendDataService;
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<OpenUpFriendDetailsViewEvent>()
                .Subscribe(OnOpenFriendDetailsView);
        }

        private async void OnOpenFriendDetailsView(int friendId)
        {
            await LoadAsync(friendId);
        }

        public async Task LoadAsync(int friendId)
        {
            this.Friend = await this.friendDataService.GetByIdAsync(friendId);
        }

        private Friend friend;

        public Friend Friend
        {
            get { return this.friend; }
            private set
            {
                this.friend = value;
                OnPropertyChanged();
            }
        }
    }
}
