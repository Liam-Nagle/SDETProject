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
using System.Windows.Threading;

namespace EarthDefenderGUI
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        GameEngine _gameEngine;
        int left = 1;
        int right = 2;
        int leftup = 3;
        int rightup = 4;
        public GamePage()
        {
            InitializeComponent();
            _gameEngine = new GameEngine(GameCanvas, LabelEnemiesLeft, RectanglePlayer);
        }

        private void Canvas_KeyisDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Left)
            {
                _gameEngine.Move(left);
            }
            if(e.Key == Key.Right)
            {
                _gameEngine.Move(right);
            }
        }

        private void Canvas_KeyisUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                _gameEngine.Move(leftup);
            }
            if (e.Key == Key.Right)
            {
                _gameEngine.Move(rightup);
            }

            if(e.Key == Key.Space)
            {
                _gameEngine.PlayerShoot();
            }
        }

        private void Control(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyDown += Canvas_KeyisDown;
            window.KeyUp += Canvas_KeyisUp;
        }
    }
}
