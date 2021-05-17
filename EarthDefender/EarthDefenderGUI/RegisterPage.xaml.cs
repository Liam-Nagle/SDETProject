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

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            if(NullCheck() && (PasswordBoxRegister.Password == PasswordConfirmBoxRegister.Password))
            {
                if(_crudmanager.CheckIfUsernameExists(TextBoxUsernameRegister.Text))
                {
                    MessageBox.Show("Username already exists! Choose a new one!");
                } else
                {
                    _crudmanager.CreateUser(TextBoxFirstNameRegister.Text, TextBoxLastNameRegister.Text, TextBoxUsernameRegister.Text, PasswordBoxRegister.Password);
                    NavigationService.GoBack();
                }
            }
            else if(NullCheck() == false)
            {
                MessageBox.Show("Please make sure you have filled in all the fields correctly!");
            }
            else
            {
                MessageBox.Show("Please make sure both the passwords are the same!");
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private bool NullCheck()
        {
            if(TextBoxFirstNameRegister.Text == "" || 
                TextBoxLastNameRegister.Text == "" || 
                TextBoxUsernameRegister.Text == "" || 
                PasswordBoxRegister.Password == "" || 
                PasswordConfirmBoxRegister.Password == "")
            {
                return false;
            } else
            {
                return true;
            }
        }
    }
}
