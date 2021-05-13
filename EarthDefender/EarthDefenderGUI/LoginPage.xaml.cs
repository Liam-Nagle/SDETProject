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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        MainWindow _mainWindow;
        CRUDManager _crudmanager = new CRUDManager();
        public LoginPage()
        {
            InitializeComponent();
        }

        public LoginPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage());
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if(_crudmanager.LoginDetails(TextboxUsername.Text, PasswordBoxPassword.Password))
            {
                _crudmanager.SetSelectedUser(TextboxUsername.Text);
                if(_mainWindow != null)
                {
                    //If coming from the MainWindow close it.
                    MainMenuWindow mainMenuWindow = new MainMenuWindow(_crudmanager.SelectedUser.UserID);
                    mainMenuWindow.Show();
                    _mainWindow.Close();
                } else
                {
                    //If coming from another page switch to a page instead
                    NavigationService.Navigate(new MainMenuPage(_crudmanager.SelectedUser.UserID));
                }
            } else
            {
                MessageBox.Show("Wrong Username and Password! Please try again.");
            }
        }
    }
}
