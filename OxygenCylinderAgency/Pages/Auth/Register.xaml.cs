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

namespace OxygenCylinderAgency.Pages.Auth
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string un = user_name.Text;
            string fn = full_name.Text;
            string ps = password.Password;
            string cp = confirm_password.Password;
            if (ps == cp)
            {
                try
                {
                    DbQueryUtil.ExecuteQuery("INSERT INTO Users (user_name, full_name, password) VALUES ('" + un + "', '" + fn + "', '" + ps + "')");
                    MessageBox.Show("Registered Successfully!");
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Password Doesn\"t match!");
            }
        }
    }
}
