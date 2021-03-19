using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Assignment9
{
    public class ContactViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string? _FirstName;
        private string? _LastName;
        private string? _PhoneNumber;
        private string? _EmailAddress;
        private string? _TwitterName;
        private DateTime _LastModified;

        public string? FirstName
        {
            get => _FirstName;
            set => SetProperty(ref _FirstName!, value!);
        }

        public string? LastName
        {
            get => _LastName;
            set => SetProperty(ref _LastName!, value!);
        }

        public string? PhoneNumber
        {
            get => _PhoneNumber;
            set => SetProperty(ref _PhoneNumber!, value!);
        }

        public string? EmailAddress
        {
            get => _EmailAddress;
            set => SetProperty(ref _EmailAddress!, value!);
        }

        public string? TwitterName
        {
            get => _TwitterName;
            set => SetProperty(ref _TwitterName!, value!);
        }

        public DateTime LastModified
        {
            get => _LastModified;
            set
            {
                _LastModified = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastModified)));
            }
        }

        private void SetProperty(ref string field, string newValue, [CallerMemberName] string propertyName = "")
        {
            if (String.Equals("", newValue.Trim()))
                newValue = "";

            if (!String.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}

