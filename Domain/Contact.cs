using System.ComponentModel;
using static System.Net.WebRequestMethods;

namespace PhoneBook.Domain
{
    public class Contact : INotifyPropertyChanged
    {
        string? name;
        string? adress;
        string? number;
        string? photo;
        public Contact(string  name, string adress, string number, string photoSource = @"https://cdn-icons-png.flaticon.com/512/3135/3135715.png")
        {
            this.name = name;
            this.adress = adress;
            this.number = number;
            photo = photoSource;
        }
        public string? Name
        {
            get { return name;}
            set 
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }
        public string? Adress
        {
            get { return adress; }
            set
            {
                adress = value;
                NotifyPropertyChanged("Adress");
            }
        }
        public string? Number
        {
            get { return number; }
            set
            {
                number = value;
                NotifyPropertyChanged("Number");
            }
        }
        public string? Photo
        {
            get { return photo; }
            set
            {
                photo = value;
                NotifyPropertyChanged("Photo");
            }
        }
    public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
