using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Register());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = DbQueryUtil.ExecuteQuery("SELECT * FROM Users WHERE (user_name='"+user_name.Text+"' AND password='"+password.Password+"')", false);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if(count > 0)
            {
                Dashboard d = new Dashboard();
                d.Show();
                var myWindow = Window.GetWindow(this);
                myWindow.Close();
            }
            else
            {
                MessageBox.Show("Incorrect UserName or Password");
            }
        }
    }
}
