using System.Collections.Generic;
using System.Threading.Tasks;
using MeetingsOrganizer.Models;

namespace MeetingsOrganizer.UI.DataServices
{
    public interface IFriendDataService
    {
        Task<List<Friend>> GetAllAsync();
    }
}