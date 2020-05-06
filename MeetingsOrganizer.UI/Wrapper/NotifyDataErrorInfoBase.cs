using MeetingsOrganizer.UI.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MeetingsOrganizer.UI.Wrapper
{
    public class NotifyDataErrorInfoBase : BaseNotifyPropertyChangedModel, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> errorsByPropertyName
           = new Dictionary<string, List<string>>();

        public bool HasErrors => errorsByPropertyName.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return this.errorsByPropertyName.ContainsKey(propertyName)
                ? errorsByPropertyName[propertyName]
                : null;
        }

        //TODO raises the errorsChangedEvent
        protected virtual void OnErrorsChanged(string propertyName)
        {
            this.ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected void AddError(string propertyName, string error)
        {
            //TODO stores the error in the List of the propName in the dictionary
            if (!this.errorsByPropertyName.ContainsKey(propertyName))
            {
                this.errorsByPropertyName[propertyName] = new List<string>();
            }
            if (!this.errorsByPropertyName[propertyName].Contains(error))
            {
                this.errorsByPropertyName[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        protected void ClearErrors(string propertyName)
        {
            if (this.errorsByPropertyName.ContainsKey(propertyName))
            {
                this.errorsByPropertyName.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }
    }
}

