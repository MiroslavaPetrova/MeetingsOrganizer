using System.Collections.Generic;
using System.Threading.Tasks;
using MeetingsOrganizer.Models;

namespace MeetingsOrganizer.UI.DataServices
{
    public interface IFriendLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetFriendLookupAsync();
    }
}