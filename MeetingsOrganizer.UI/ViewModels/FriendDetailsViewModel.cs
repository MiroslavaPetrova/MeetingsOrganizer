using MeetingsOrganizer.UI.DataServices;
using MeetingsOrganizer.UI.Events;
using MeetingsOrganizer.UI.Wrapper;
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
        private FriendWrapper friend;

        public FriendDetailsViewModel(IFriendDataService friendDataService,
            IEventAggregator eventAggregator)
        {
            this.friendDataService = friendDataService;
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<OpenUpFriendDetailsViewEvent>()
                .Subscribe(OnOpenFriendDetailsView);
            this.SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private async void OnOpenFriendDetailsView(int friendId)
        {
            await LoadAsync(friendId);
        }

        public async Task LoadAsync(int friendId)
        {
            var friend = await this.friendDataService.GetByIdAsync(friendId);
            this.Friend = new FriendWrapper(friend);
        }

        public FriendWrapper Friend
        {
            get { return this.friend; }
            private set
            {
                this.friend = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        private async void OnSaveExecute()
        {
            await this.friendDataService.SaveAync(this.Friend.Model);
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
    }
}
