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
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        CRUDManager _crudManager = new CRUDManager();
        public MainMenuPage(int userID)
        {
            InitializeComponent();
            _crudManager.SetSelectedUser(userID);
            TextblockUsername.Text = "Welcome! " + _crudManager.SelectedUser.FirstName;
        }

        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void ButtonHighscore_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HighscorePage(_crudManager.SelectedUser.UserID));
        }

        private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GamePage(_crudManager.SelectedUser.UserID));
        }

        private void ButtonLogout_Clicked(object sender, RoutedEventArgs e)
        {
            if (MessageBox
                .Show("You are about to logout. Are you sure?",
                "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                NavigationService.Navigate(new LoginPage());
            }
        }
    }
}
