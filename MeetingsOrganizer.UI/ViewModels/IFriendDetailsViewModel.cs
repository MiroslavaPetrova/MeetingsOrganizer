using System.Threading.Tasks;

namespace MeetingsOrganizer.UI.ViewModels
{
    public interface IFriendDetailsViewModel
    {
        Task LoadAsync(int friendId);
    }
}