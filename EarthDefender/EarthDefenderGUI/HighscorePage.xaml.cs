using EarthDefenderBusiness;
using EarthDefenderModel;
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
    /// Interaction logic for Highscore.xaml
    /// </summary>
    public partial class HighscorePage : Page
    {
        CRUDManager _crudManager = new CRUDManager();
        Dictionary<int, Highscore> userHighscoreDict = new Dictionary<int, Highscore>();
        public HighscorePage()
        {
            InitializeComponent();
        }

        public HighscorePage(int userID)
        {
            InitializeComponent();
            _crudManager.SetSelectedUser(userID);
            InitaliseHighscores();
            ListViewHighscores.ItemsSource = userHighscoreDict;
        }

        private void ButtonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void InitaliseHighscores()
        {
            var allHighscores = _crudManager.RetrieveAllHighscores();
            var userHighscores = _crudManager.RetrieveAllUserHighscores();
            var userPositions = _crudManager.RetrieveUserHighscorePositions();

            //Adds above into a Dictionary so the Listview can have databindings
            for (int i = 0; i < userHighscores.Count(); i++)
            {
                userHighscoreDict.Add(userPositions[i] + 1, userHighscores[i]);
            }

            var top3 = _crudManager.RetrieveTop3Highscores();
            TextblockFirstPlace.Text = top3[0].ToString();
            TextblockSecondPlace.Text = top3[1].ToString();
            TextblockThirdPlace.Text = top3[2].ToString();
        }
    }
}
