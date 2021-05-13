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
        public HighscorePage()
        {
            InitializeComponent();
        }

        private void ButtonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuPage());
        }
    }
}
