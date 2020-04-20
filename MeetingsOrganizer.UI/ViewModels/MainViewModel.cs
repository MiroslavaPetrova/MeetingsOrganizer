using MeetingsOrganizer.Models;
using MeetingsOrganizer.UI.DataServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MeetingsOrganizer.UI.ViewModels
{
    public partial class MainViewModel : BaseNotifyPropertyChangedModel
    {
        private IFriendDataService friendService;
        private Friend selectedFriend;

        public MainViewModel(IFriendDataService friendDataService)
        {
            this.Friends = new ObservableCollection<Friend>();
            this.friendService = friendDataService;
        }

        public ObservableCollection<Friend> Friends { get; set; }

        public async Task LoadAsync()
        {
            IEnumerable<Friend> allFriends = await friendService.GetAllAsync();
            Friends.Clear();    // so I wont have duplicates when reloading the friends

            foreach (var friend in allFriends)
            {
                Friends.Add(friend);
            }
        }

        public Friend SelectedFriend
        {
            get { return selectedFriend; }
            set
            {
                selectedFriend = value;
                OnPropertyChanged(); 
                //passes the member name/e.g. selectedFriend/ of the caller at runtime
            }
        }
    }
}
