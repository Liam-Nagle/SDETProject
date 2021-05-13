using EarthDefenderBusiness;
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

namespace EarthDefenderGUI
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        CRUDManager _crudmanager = new CRUDManager();
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(NullCheck() && PasswordBoxRegister.Password == PasswordConfirmBoxRegister.Password)
            {
                _crudmanager.CreateUser(TextBoxFirstNameRegister.Text, TextBoxLastNameRegister.Text, TextBoxUsernameRegister.Text, PasswordBoxRegister.Password);
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Please make sure your Passwords are the same!");
            }
        }

        private bool NullCheck()
        {
            if(TextBoxFirstNameRegister.Text == null || 
                TextBoxLastNameRegister.Text == null || 
                TextBoxUsernameRegister.Text == null || 
                PasswordBoxRegister.Password == null || 
                PasswordConfirmBoxRegister.Password == null)
            {
                return false;
            } else
            {
                return true;
            }
        }
    }
}
