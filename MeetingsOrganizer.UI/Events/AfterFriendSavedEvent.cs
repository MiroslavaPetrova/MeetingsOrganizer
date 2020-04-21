using Prism.Events;

namespace MeetingsOrganizer.UI.Events
{
    public class AfterFriendSavedEvent : PubSubEvent<AfterFriendSavedEventArgs>
    {
    }

    public class AfterFriendSavedEventArgs
    {
        public int Id { get; set; }

        public string DisplayMember { get; set; }
    }
}
