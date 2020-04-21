using MeetingsOrganizer.Models;
using System.Threading.Tasks;

namespace MeetingsOrganizer.UI.DataServices
{
    public interface IFriendDataService
    {
        Task<Friend> GetByIdAsync(int friendId);
    }
}