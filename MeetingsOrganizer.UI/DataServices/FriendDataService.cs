using MeetingsOrganizer.Models;
using System.Collections.Generic;
namespace MeetingsOrganizer.UI.DataServices
{
    public class FriendDataService : IFriendDataService
    {
        public IEnumerable<Friend> GetAll()
        {
            yield return new Friend { FirstName = "Peter", LastName = "Pan" };
            yield return new Friend { FirstName = "Vivian", LastName = "Shields" };
            yield return new Friend { FirstName = "Japan", LastName = "Lasters" };
            yield return new Friend { FirstName = "Varna", LastName = "Livierung" };
            yield return new Friend { FirstName = "Liver", LastName = "Anderson" };
        }
    }
}
