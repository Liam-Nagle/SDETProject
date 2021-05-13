using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace EarthDefenderGUI
{
    class Bullet
    {
        Rectangle _rectangle = new Rectangle();
        public Rectangle Rectangle { get => _rectangle; set => _rectangle = value; }

        public Bullet(int width, int height, string tag, Brush fill, Brush stroke, int strokeThickness)
        {
            Rectangle.Width = width;
            Rectangle.Height = height;
            Rectangle.Tag = tag;
            Rectangle.Fill = fill;
            Rectangle.Stroke = stroke;
            Rectangle.StrokeThickness = strokeThickness;
        }
    }
}
