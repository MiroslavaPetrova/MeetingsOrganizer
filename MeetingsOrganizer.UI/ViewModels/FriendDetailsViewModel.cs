using MeetingsOrganizer.Models;
using MeetingsOrganizer.UI.DataServices;
using MeetingsOrganizer.UI.Events;
using Prism.Commands;
using Prism.Events;
using System.Threading.Tasks;
using System.Windows.Input;

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
            this.SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private async void OnSaveExecute()
        {
            await this.friendDataService.SaveAync(friend);
            this.eventAggregator.GetEvent<AfterFriendSavedEvent>()
                .Publish(new AfterFriendSavedEventArgs
                {
                    Id = this.Friend.Id,
                    DisplayMember = $"{this.Friend.FirstName} {this.Friend.LastName}"
                });
        }

        private bool OnSaveCanExecute()
        {
            return true;
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

        public ICommand SaveCommand { get; }
    }
}
