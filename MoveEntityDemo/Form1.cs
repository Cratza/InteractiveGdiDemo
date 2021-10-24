using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MoveEntityDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Size = new Size(404,429);
            rectangleFigures = new List<RectangleFigure>()
            {
                new RectangleFigure(){X=0,Y=0,Height=100,Width=100,Actived=false},
                new RectangleFigure(){X=100,Y=100,Height=100,Width=100,Actived=false},
                new RectangleFigure(){X=200,Y=200,Height=100,Width=100,Actived=false},
                new RectangleFigure(){X=300,Y=300,Height=100,Width=100,Actived=false},
                new RectangleFigure(){X=0,Y=200,Height=100,Width=100,Actived=false},
                new RectangleFigure(){X=100,Y=300,Height=100,Width=100,Actived=false},
                new RectangleFigure(){X=200,Y=0,Height=100,Width=100,Actived=false},
                new RectangleFigure(){X=300,Y=100,Height=100,Width=100,Actived=false},  
            };

            circleFigures = new List<CircleFigure>()
            {
                new CircleFigure(){X=0,Y=100,diameter=100,Actived = false},
                new CircleFigure(){X=0,Y=300,diameter=100,Actived = false},
                new CircleFigure(){X=100,Y=0,diameter=100,Actived = false},
                new CircleFigure(){X=100,Y=200,diameter=100,Actived = false},
                new CircleFigure(){X=200,Y=100,diameter=100,Actived = false},
                new CircleFigure(){X=200,Y=300,diameter=100,Actived = false},
                new CircleFigure(){X=300,Y=0,diameter=100,Actived = false},
                new CircleFigure(){X=300,Y=200,diameter=100,Actived = false},
            };

            this.KeyDown += (s,e) =>
            {
                if (e.KeyCode == Keys.Delete)
                {
                    rectangleFigures.RemoveAll(rect => rect.Actived == true);
                    circleFigures.RemoveAll(cic => cic.Actived == true);

                    Invalidate();
                }
            };
        }

        public void DrawCircle(Graphics g)
        {
            g.DrawEllipse(Pens.LightBlue, CenterX - 50, CenterY - 50, 100, 100);
        }

        public List<RectangleFigure> rectangleFigures { get; set; }
        public List<CircleFigure> circleFigures { get; set; }
        public double scaleFactor { get; set; } = 1.0;
        public float CenterX { get; set; }
        public float CenterY { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            CenterX = ClientRectangle.Width / 2;
            CenterY = ClientRectangle.Height / 2;
            base.OnPaint(e);
            rectangleFigures.ForEach(rect => rect.DrawMe(e.Graphics));
            circleFigures.ForEach(cic =>cic.DrawMe(e.Graphics));
            //DrawCircle(e.Graphics);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = e.Location;
                rectangleFigures.ForEach(rect => {
                    if (rect.IsExist(p)) {
                        rect.Actived = true;
                        Invalidate();
                    }
                    else
                    {
                        rect.Actived = false;
                    };
                });

                circleFigures.ForEach(cic => {
                    if (cic.IsExist(p))
                    {
                        cic.Actived = true;
                        Invalidate();
                    }
                    else
                    {
                        cic.Actived = false;
                    };
                });
            }
        }
    }
}
