namespace MeetingsOrganizer.UI.ViewModels
{
    public class NavigationItemViewModel : BaseNotifyPropertyChangedModel
    {
        private string displayMember;

        public NavigationItemViewModel(int id, string displayMember)
        {
            this.Id = id;
            this.DisplayMember = displayMember;
        }

        public int Id { get; }

        public string DisplayMember
        {
            get { return this.displayMember; }
            set
            {
                this.displayMember = value;
                OnPropertyChanged();
            }
        }

    }
}
