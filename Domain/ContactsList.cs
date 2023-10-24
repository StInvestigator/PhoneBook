using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PhoneBook.Domain
{
    public class ContactsList : INotifyPropertyChanged
    {
        public List<Contact>? contacts = null;
        Contact selectedContact;
        public Contact SelectedContact
        {
            get { return selectedContact; }
            set 
            {
                selectedContact = value;
                NotifyPropertyChanged("SelectedContact");
            }
        }
        public ContactsList() 
        {
            contacts = new List<Contact>();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddContact(Contact contact)
        {
            contacts?.Add(contact);
        }
        public void RemoveUser(Contact contact)
        {
            contacts?.Remove(contact);
        }
        public void RemoveUser(int index)
        {
            contacts?.RemoveAt(index);
        }
        public List<Contact>? SortByName(string partialName)
        {
            partialName = partialName.ToLower();
            return contacts?.Where(g => g.Name.ToLower().Contains(partialName)).ToList();
        }
    }
}
