using System;
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

namespace EarthDefenderGUI
{
    class Enemy
    {
        ImageBrush _enemySkin = new ImageBrush();
        Rectangle _rectangle = new Rectangle();
        private string _path = Directory.GetCurrentDirectory();

        public Rectangle Rectangle { get => _rectangle; set => _rectangle = value; }

        public Enemy(int width, int height, string tag, int skinNumber)
        {
            Rectangle.Width = width;
            Rectangle.Height = height;
            Rectangle.Tag = tag;
            GetSkin(skinNumber);
            Rectangle.Fill = _enemySkin;

        }

        private void GetSkin(int skinNumber)
        {
            switch (skinNumber)
            {
                case 1:
                    _enemySkin.ImageSource = new BitmapImage(new Uri(_path + @"/../../../Images/invader1.gif", UriKind.Relative));
                    break;
                case 2:
                    _enemySkin.ImageSource = new BitmapImage(new Uri(_path + @"/../../../Images/invader2.gif", UriKind.Relative));
                    break;
                case 3:
                    _enemySkin.ImageSource = new BitmapImage(new Uri(_path + @"/../../../Images/invader3.gif", UriKind.Relative));
                    break;
                case 4:
                    _enemySkin.ImageSource = new BitmapImage(new Uri(_path + @"/../../../Images/invader4.gif", UriKind.Relative));
                    break;
                case 5:
                    _enemySkin.ImageSource = new BitmapImage(new Uri(_path + @"/../../../Images/invader5.gif", UriKind.Relative));
                    break;
                case 6:
                    _enemySkin.ImageSource = new BitmapImage(new Uri(_path + @"/../../../Images/invader6.gif", UriKind.Relative));
                    break;
                case 7:
                    _enemySkin.ImageSource = new BitmapImage(new Uri(_path + @"/../../../Images/invader7.gif", UriKind.Relative));
                    break;
                case 8:
                    _enemySkin.ImageSource = new BitmapImage(new Uri(_path + @"/../../../Images/invader8.gif", UriKind.Relative));
                    break;
            }

        }
    }
}

