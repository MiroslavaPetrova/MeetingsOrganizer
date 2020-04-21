namespace MeetingsOrganizer.Data.Migrations
{
    using MeetingsOrganizer.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MeetingsOrganizer.Data.MeetingsOrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MeetingsOrganizer.Data.MeetingsOrganizerDbContext context)
        {
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Friends.AddOrUpdate(
            friend => friend.FirstName,     // TODO: no duplicates by FirstName
            new Friend { FirstName = "Peter", LastName = "Silhouette" }, //TODO dbLoads = checked
            new Friend { FirstName = "Vivian", LastName = "Shields" },
            new Friend { FirstName = "Japan", LastName = "Lasters" },
            new Friend { FirstName = "Varna", LastName = "Livierung" },
            new Friend { FirstName = "Liver", LastName = "Anderson" }
            );
        }
    }
}
