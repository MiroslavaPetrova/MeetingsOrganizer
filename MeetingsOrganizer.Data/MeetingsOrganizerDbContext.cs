using MeetingsOrganizer.Models;
using System.Data.Entity;

namespace MeetingsOrganizer.Data
{
    public class MeetingsOrganizerDbContext : DbContext
    {
        public DbSet<Friend> Friends { get; set; }

        public MeetingsOrganizerDbContext() :base("MeetingsOrganizerDb")
        {
        }
    }
}
