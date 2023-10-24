using PhoneBook.Domain;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PhoneBook
{
    public partial class MainWindow : Window
    {
        ContactsList list;
        public MainWindow()
        {
            list = new ContactsList();
            list.AddContact(new Contact("Даніїл Б.", "Хрустальна 9", "+0507760190", @"https://upload.wikimedia.org/wikipedia/commons/thumb/9/93/Google_Contacts_icon.svg/1200px-Google_Contacts_icon.svg.png"));
            list.AddContact(new Contact("Кіркач Микита", "Бикова 1", "+0506049250", @"https://upload.wikimedia.org/wikipedia/commons/thumb/4/4a/Eo_circle_blue_white_letter-h.svg/800px-Eo_circle_blue_white_letter-h.svg.png"));
            list.AddContact(new Contact("Вікторія", "Місяць", "+0501111111", @"https://play-lh.googleusercontent.com/brvU4qPe53XlBxt-fKrU9-ndyXicld2kh0s6p6F5naUfM90EUcJcXU3T3T2iFhBWoyk"));
            list.AddContact(new Contact("Вікторія", "Місяць", "+0501111111", @"https://play-lh.googleusercontent.com/brvU4qPe53XlBxt-fKrU9-ndyXicld2kh0s6p6F5naUfM90EUcJcXU3T3T2iFhBWoyk"));
            list.AddContact(new Contact("Вікторія", "Місяць", "+0501111111", @"https://play-lh.googleusercontent.com/brvU4qPe53XlBxt-fKrU9-ndyXicld2kh0s6p6F5naUfM90EUcJcXU3T3T2iFhBWoyk"));
            list.AddContact(new Contact("Вікторія", "Місяць", "+0501111111", @"https://play-lh.googleusercontent.com/brvU4qPe53XlBxt-fKrU9-ndyXicld2kh0s6p6F5naUfM90EUcJcXU3T3T2iFhBWoyk"));
            list.AddContact(new Contact("Вікторія", "Місяць", "+0501111111", @"https://play-lh.googleusercontent.com/brvU4qPe53XlBxt-fKrU9-ndyXicld2kh0s6p6F5naUfM90EUcJcXU3T3T2iFhBWoyk"));
            list.AddContact(new Contact("Вікторія", "Місяць", "+0501111111", @"https://play-lh.googleusercontent.com/brvU4qPe53XlBxt-fKrU9-ndyXicld2kh0s6p6F5naUfM90EUcJcXU3T3T2iFhBWoyk"));
            list.AddContact(new Contact("Вікторія", "Місяць", "+0501111111", @"https://play-lh.googleusercontent.com/brvU4qPe53XlBxt-fKrU9-ndyXicld2kh0s6p6F5naUfM90EUcJcXU3T3T2iFhBWoyk"));
            list.AddContact(new Contact("Вікторія", "Місяць", "+0501111111", @"https://play-lh.googleusercontent.com/brvU4qPe53XlBxt-fKrU9-ndyXicld2kh0s6p6F5naUfM90EUcJcXU3T3T2iFhBWoyk"));
            list.AddContact(new Contact("Вікторія", "Місяць", "+0501111111", @"https://play-lh.googleusercontent.com/brvU4qPe53XlBxt-fKrU9-ndyXicld2kh0s6p6F5naUfM90EUcJcXU3T3T2iFhBWoyk"));
            list.AddContact(new Contact("Вікторія", "Місяць", "+0501111111", @"https://play-lh.googleusercontent.com/brvU4qPe53XlBxt-fKrU9-ndyXicld2kh0s6p6F5naUfM90EUcJcXU3T3T2iFhBWoyk"));
            list.AddContact(new Contact("Вікторія", "Місяць", "+0501111111", @"https://play-lh.googleusercontent.com/brvU4qPe53XlBxt-fKrU9-ndyXicld2kh0s6p6F5naUfM90EUcJcXU3T3T2iFhBWoyk"));
            list.AddContact(new Contact("Вікторія", "Місяць", "+0501111111", @"https://play-lh.googleusercontent.com/brvU4qPe53XlBxt-fKrU9-ndyXicld2kh0s6p6F5naUfM90EUcJcXU3T3T2iFhBWoyk"));
            InitializeComponent();
            LVMain.ItemsSource = list.contacts;
        }

        private void LVMain_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (list.SelectedContact != null) MessageBox.Show($"Name - {list.SelectedContact?.Name}\nAdress - {list.SelectedContact?.Adress}");
        }
        private void LVMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sel = LVMain.SelectedItem;
            try
            {
                list.SelectedContact = sel as Contact;
            }
            catch
            {
                MessageBox.Show("Error with selection!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Call_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (list.SelectedContact != null)
            {
                LDialog.Content = list.SelectedContact.Number;
            }
        }

        private void Delete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (list.SelectedContact != null)
            {
                list.RemoveUser(list.SelectedContact);
                LVMain.ItemsSource = null;
                LVMain.ItemsSource = list.contacts;
            }
        }

        private void Add_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EditContact editContact = new EditContact(list, this);
            editContact.Show();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (TBSearch.Visibility == Visibility.Hidden && TBSearch.Text.Length == 0)
            {
                TBSearch.Visibility = Visibility.Visible;
                TBSearch.Focus();
                Grid.SetRowSpan(LVMain, 1);
            }
        }

        private void TBSearch_DataContextChanged(object sender, RoutedEventArgs e)
        {
            if (TBSearch.Text.Length == 0)
            {
                TBSearch.Visibility = Visibility.Hidden;
                Grid.SetRowSpan(LVMain, 2);
            }
        }
        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LVMain.ItemsSource = null;
            LVMain.ItemsSource= list.SortByName(TBSearch.Text);
        }
    }
}
