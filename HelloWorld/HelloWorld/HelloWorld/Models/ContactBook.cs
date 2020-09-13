using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace HelloWorld.Models
{
    public class ContactBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string _firstName;
        [MaxLength(255)]
        public string FirstName 
        {
            get { return _firstName;  } 
            set
            {
                if (_firstName == value)
                    return;
                _firstName = value;

                OnPropertyChanged();
            }
        }

        private string _lastName;
        [MaxLength(255)]
        public string LastName
        {
            get { return _lastName; }
            set 
            {
                if (_lastName == value)
                    return;
                _lastName = value;

                OnPropertyChanged();
            }
        }

        [MaxLength(32)]
        public string Phone { get; set; }
        [MaxLength(128)]
        public string Email { get; set; }
        public bool Blocked { get; set; }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
