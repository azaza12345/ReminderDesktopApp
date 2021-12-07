using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderDesktopApp.Models
{
    class Reminder : INotifyPropertyChanged
    {
        private string _title;
        private string _description;

        public int Id { get; set; }
        public DateTime DeadlineTime { get; set; }
        public string Title
        {
            get
            { return _title; }
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
            get
            {
                return _description;
            }
            set
            {
                if (_description == value)
                    return;
                
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
