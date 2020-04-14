using System.Collections.Generic;
using MeetingsOrganizer.Models;

namespace MeetingsOrganizer.UI.DataServices
{
    public interface IFriendDataService
    {
        IEnumerable<Friend> GetAll();
    }
}