using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Assignment9
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ContactViewModel> Contacts { get; } = new();
        public RelayCommand NewContactCommand { get; }
        public RelayCommand EditContactCommand { get; }
        public RelayCommand SaveContactCommand { get; }
        public RelayCommand DeleteContactCommand { get; }


        private bool _IsBeingEdited;
        private ContactViewModel _SelectedContact;

        public MainWindowViewModel()
        {
            NewContactCommand = new RelayCommand(NewContact, () => true);
            EditContactCommand = new RelayCommand(EditContact, () => true);
            SaveContactCommand = new RelayCommand(SaveContact, () => true);
            DeleteContactCommand = new RelayCommand(DeleteContact, CanDeleteContact);

            Contacts.Add(new()
            {
                FirstName = "David",
                LastName = "Bowie",
                PhoneNumber = "020-859-3018",
                EmailAddress = "Bowie@rockstar.com",
                TwitterName = "@AladdinSane",
                LastModified = DateTime.Now
            });

            Contacts.Add(new()
            {
                FirstName = "Siouxsie",
                LastName = "Sioux",
                PhoneNumber = "020-673-4851",
                EmailAddress = "Siouxsie@gothic.com",
                TwitterName = "@Banshees",
                LastModified = DateTime.Now
            });

            Contacts.Add(new()
            {
                FirstName = "Freddy",
                LastName = "Mercury",
                PhoneNumber = "020-823-9400",
                EmailAddress = "Mercury@piano.com",
                TwitterName = "@Queen",
                LastModified = DateTime.Now
            });

        }
        public ContactViewModel SelectedContact
        {
            get => _SelectedContact;
            set => SetProperty(ref _SelectedContact, value);
        }


        public bool IsBeingEdited
        {
            get => _IsBeingEdited;
            set => SetProperty(ref _IsBeingEdited, value);
        }

        private void NewContact()
        {
            ContactViewModel NewContact = new ContactViewModel() { FirstName = "Temp", LastName = "Name", LastModified = DateTime.Now };

            Contacts.Add(NewContact);

            SelectedContact = NewContact;

            IsBeingEdited = true;
        }

        private void EditContact()
        {
            IsBeingEdited = true;
        }

        private void SaveContact()
        {
            if (Contacts.Count != 0)
            {
                IsBeingEdited = false;
                SelectedContact.LastModified = DateTime.Now;
            }
        }

        public bool CanDeleteContact()
        {
            if (Contacts.Count > 0)
                return true;

            else
                return false;
        }

        public void DeleteContact()
        {
            Contacts.Remove(SelectedContact);

            if (Contacts.Count > 0)
                SelectedContact = Contacts.First();
        }

        private bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = "")
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            else
                return false;
        }
    }
}

