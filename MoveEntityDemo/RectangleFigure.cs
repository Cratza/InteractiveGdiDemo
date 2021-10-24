using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MoveEntityDemo
{
    /// <summary>
    /// 矩形对象
    /// </summary>
    public class RectangleFigure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public bool Actived { get; set; }

        public bool IsExist(Point p)
        {
            Rectangle rectangle = new Rectangle(this.X, this.Y, this.Width, this.Height);
            return rectangle.Contains(p);
        }

        public void MouseMove(Point p)
        {
            Actived = IsExist(p);
        }

        public void DrawMe(Graphics g)
        {
            Pen p = new Pen(Color.Black,3);
            g.FillRectangle(p.Brush, this.X, this.Y, this.Width, this.Height);
            if (Actived)
            {
                p.Color = Color.Red;
                g.DrawRectangle(p, this.X, this.Y, this.Width, this.Height);
            }
        }
    }

    /// <summary>
    /// 圆形对象
    /// </summary>
    public class CircleFigure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int diameter { get; set; }

        public bool Actived { get; set; }

        public bool IsExist(Point p)
        {
            return (p.X - X-diameter*0.5) * (p.X - X - diameter * 0.5) + (p.Y - Y - diameter * 0.5) * (p.Y - Y - diameter * 0.5) <= diameter * diameter/4;
        }

        public void MouseMove(Point p)
        {
            Actived = IsExist(p);
        }

        public void DrawMe(Graphics g)
        {
            Pen p = new Pen(Color.LightGreen, 3);
            g.FillEllipse(p.Brush, this.X, this.Y, this.diameter, this.diameter);
            if (Actived)
            {
                p.Color = Color.LightPink;
                g.DrawEllipse(p, this.X, this.Y, this.diameter, this.diameter);
            }
        }
    }
}
