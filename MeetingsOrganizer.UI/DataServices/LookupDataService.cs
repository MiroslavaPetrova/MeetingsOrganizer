using MeetingsOrganizer.Data;
using MeetingsOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsOrganizer.UI.DataServices
{
    public class LookupDataService : IFriendLookupDataService
    {
        private readonly Func<MeetingsOrganizerDbContext> context;

        public LookupDataService(Func<MeetingsOrganizerDbContext> context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<LookupItem>> GetFriendLookupAsync()
        {
            using (var ctx = context())
            {
                return await ctx.Friends
                    .Select(friend => new LookupItem
                    {
                        Id = friend.Id,
                        DisplayMember = friend.FirstName + " " + friend.LastName,
                    }
                    ).ToListAsync();

            }
        }
    }
}
