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

namespace SpaceInvadersGUI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        MainWindow _mainWindow;
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
            MainMenuWindow mainMenuWindow = new MainMenuWindow();
            mainMenuWindow.Show();
            _mainWindow.Close();
            //Needs to actually check login details
        }
    }
}
