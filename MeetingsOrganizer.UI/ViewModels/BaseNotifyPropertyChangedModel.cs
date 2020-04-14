using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MeetingsOrganizer.UI.ViewModels
{
    public class BaseNotifyPropertyChangedModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // the sender is MainViewModel
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
