using PhoneBook.Domain;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace PhoneBook
{
    /// <summary>
    /// Interaction logic for EditContact.xaml
    /// </summary>
    public partial class EditContact : Window
    {
        ContactsList list;
        MainWindow mw;
        public EditContact(ContactsList list, MainWindow mw)
        {
            InitializeComponent();
            this.list = list;
            this.mw = mw;
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var im = new BitmapImage(new Uri(TBPhoto.Text));
                list.AddContact(new Contact(TBName.Text,TBAdess.Text,TBNumber.Text,TBPhoto.Text));
                mw.LVMain.ItemsSource = null;
                mw.LVMain.ItemsSource = list.contacts;
                Close();
            }
            catch
            {
                MessageBox.Show("Wrong data!","Error!",MessageBoxButton.OK,MessageBoxImage.Error);
                TBAdess.Text = "";
                TBName.Text = "";
                TBNumber.Text = "";
                TBPhoto.Text = "";
            }
        }
    }
}
