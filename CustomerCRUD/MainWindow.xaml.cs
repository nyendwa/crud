using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomerCRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Users> DatabaseUsers { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }
        public void Create()
        {
            using(DataContext context=new DataContext())
            {
                var name=NameTextBox.Text;
                var contact = ContactTextBox.Text;
                var email=EmailTextBox.Text;
                var address=AddressTextBox.Text;

               if(name != null && address!=null && email!=null && contact!=null)
               {
                    context.User.Add(new Users()
                    {
                        Name = name,
                        Contact = contact,
                        Email = email,
                        Address = address

                    });
                    context.SaveChanges();
               }
            }
        }
        public void Read()
        {
            using (DataContext context = new DataContext())
            {
               DatabaseUsers= context.User.ToList();
               Itemslist.ItemsSource= DatabaseUsers;
            }
        }
        public void Update()
        {
            using (DataContext context = new DataContext())
            {
                Users selectedUser=Itemslist.SelectedItem as Users;

                var name = NameTextBox.Text;
                var contact = ContactTextBox.Text;
                var email = EmailTextBox.Text;
                var address = AddressTextBox.Text;

                if (name != null && address != null && email != null && contact != null)
                {
                    Users user=context.User.Find(selectedUser.ID);
                    user.Name = name;
                    user.Contact = contact;
                    user.Email = email;
                    user.Address = address;

                    context.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            Users selectedUser = Itemslist.SelectedItem as Users;
            if(selectedUser!= null)
            {
                using (DataContext context = new DataContext())
                {
                    Users user = context.User.Single(x=>x.ID==selectedUser.ID);
                    context.Remove(user);
                    context.SaveChanges();
                }

            }


             
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Itemslist.Items.Clear();
        }
    }
}
