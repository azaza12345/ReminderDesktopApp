using System;
using System.ComponentModel;

namespace Reminder.Entities
{
    public sealed class TaskToDo : INotifyPropertyChanged
    {
        private string _title;
        private string _description;

        public int Id { get; set; }
        public DateTime DeadlineTime { get; set; }
        public string Title
        {
            get => _title;
            set
            {
                if (_title == value)
                    return;

                _title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                if (_description == value)
                    return;

                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}