using MeetingsOrganizer.Data;
using MeetingsOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsOrganizer.UI.DataServices
{
    public class FriendDataService : IFriendDataService
    {
        private readonly Func<MeetingsOrganizerDbContext> context;

        public FriendDataService(Func<MeetingsOrganizerDbContext> context)
        {
            this.context = context;
        }

        public async Task<Friend> GetByIdAsync(int friendId)
        {
            using (var ctx = context())
            {
                return await ctx.Friends.SingleOrDefaultAsync(f => f.Id == friendId);
                                                         //TODO await the ToListAsync() 
                                                        //so the ctx will not be disposed
            }                                           // BEFORE the methods returns !
        }
    }
}
