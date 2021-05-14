﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace EarthDefenderGUI
{
    public class GameEngine
    {
        int totalEnemies;
        int bulletTimer = 200;
        int bulletTimerLimit = 90;
        int enemySpeed = 6;
        bool goLeft = false;
        bool goRight = false;
        List<Rectangle> itemsToRemove = new List<Rectangle>();
        DispatcherTimer dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal);
        Canvas _canvas = new Canvas();
        Rectangle player1;
        Rect collisionPlayer;
        ImageBrush playerSkin = new ImageBrush();
        Label enemiesLeft;
        private string _path = Directory.GetCurrentDirectory();

        public GameEngine(Canvas gameCanvas, Label enemiesLeft, Rectangle player)
        {
            playerSkin.ImageSource = new BitmapImage(new Uri(_path + @"/../../../Images/player.png", UriKind.Relative));
            player1 = player;
            player1.Fill = playerSkin;
            _canvas = gameCanvas;
            this.enemiesLeft = enemiesLeft;
            dispatcherTimer.Tick += Start;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(20);
            dispatcherTimer.Start();
            SpawnEnemies(30);
        }

        public void Start(object sender, EventArgs e)
        {
            MovementHandle();

            bulletTimer -= 3;

            if(bulletTimer <= 0)
            {
                //Places bullet the enemies shoot above the player
                //Change this to actually shoot from the enemies
                EnemyShoot((Canvas.GetLeft(player1) + 20), 10);
                bulletTimer = bulletTimerLimit;
            }

            if(totalEnemies < 10)
            {
                enemySpeed = 20;
            }

            CollisionCheck();

            foreach(Rectangle y in itemsToRemove)
            {
                _canvas.Children.Remove(y);
            }

            if(totalEnemies < 1)
            {
                dispatcherTimer.Stop();
                MessageBox.Show("You Win!");
            }

        }

        public void Move(int move)
        {
            if(move == 1)
            {
                goLeft = true;
            }
            if(move == 2)
            {
                goRight = true;
            }
            if(move == 3)
            {
                goLeft = false;
            }
            if(move == 4)
            {
                goRight = false;
            }
        }

        public void PlayerShoot()
        {
            itemsToRemove.Clear();
            Bullet newBullet = new Bullet(5, 20, "bullet", Brushes.White, Brushes.Red, 1);
            Canvas.SetTop(newBullet.Rectangle, Canvas.GetTop(player1) - newBullet.Rectangle.Height);
            Canvas.SetLeft(newBullet.Rectangle, Canvas.GetLeft(player1) + player1.Width / 2);
            _canvas.Children.Add(newBullet.Rectangle);
        }

        public void EnemyShoot(double x, double y)
        {
            Bullet newBullet = new Bullet(15, 40, "enemyBullet", Brushes.Yellow, Brushes.Black, 5);
            Canvas.SetTop(newBullet.Rectangle, y);
            Canvas.SetLeft(newBullet.Rectangle, x);
            _canvas.Children.Add(newBullet.Rectangle);
        }

        public void SpawnEnemies(int amount)
        {
            int left = 0;
            totalEnemies = amount;

            for(int i = 0; i < amount; i++)
            {
                int randomSkin = new Random().Next(1, 8);
                Enemy newEnemy = new Enemy(45, 45, "enemy", randomSkin);

                Canvas.SetTop(newEnemy.Rectangle, 10);
                Canvas.SetLeft(newEnemy.Rectangle, left);
                _canvas.Children.Add(newEnemy.Rectangle);

                left -= 60;
            }
        }

        private void MovementHandle()
        {
            collisionPlayer =  new Rect(Canvas.GetLeft(player1), Canvas.GetTop(player1), player1.Width, player1.Height);
            enemiesLeft.Content = "Invaders Left:" + totalEnemies;

            if (goLeft && Canvas.GetLeft(player1) > 0)
            {
                Canvas.SetLeft(player1, Canvas.GetLeft(player1) - 10);
            }
            else if (goRight && Canvas.GetLeft(player1) + 80 < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(player1, Canvas.GetLeft(player1) + 10);
            }
        }

        private void CollisionCheck()
        {
            foreach (var x in _canvas.Children.OfType<Rectangle>())
            {
                if ((string)x.Tag == "bullet")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) - 20);

                    Rect bullet = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (Canvas.GetTop(x) < 10)
                    {
                        itemsToRemove.Add(x);
                    }

                    foreach (var y in _canvas.Children.OfType<Rectangle>())
                    {
                        if ((string)y.Tag == "enemy")
                        {
                            Rect enemy = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);

                            if (bullet.IntersectsWith(enemy))
                            {
                                itemsToRemove.Add(x);
                                itemsToRemove.Add(y);
                                totalEnemies--;
                            }
                        }
                    }

                }

                if ((string)x.Tag == "enemy")
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) + enemySpeed);

                    if (Canvas.GetLeft(x) > 870)
                    {
                        Canvas.SetLeft(x, -80);
                        Canvas.SetTop(x, Canvas.GetTop(x) + (x.Height + 10));
                    }

                    Rect enemy = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (collisionPlayer.IntersectsWith(enemy))
                    {
                        dispatcherTimer.Stop();
                        MessageBox.Show("You Lose"); //Some Code here to "Restart" the game with faster enemy speed
                    }
                }

                if ((string)x.Tag == "enemyBullet")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) + 10);

                    if (Canvas.GetTop(x) > 530)
                    {
                        itemsToRemove.Add(x);
                    }

                    Rect enemyBullets = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (enemyBullets.IntersectsWith(collisionPlayer))
                    {
                        dispatcherTimer.Stop();
                        MessageBox.Show("You Lose");
                    }
                }
            }
        }
    }
}
