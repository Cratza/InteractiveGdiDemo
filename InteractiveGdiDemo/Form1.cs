using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace InteractiveGdiDemo
{
    public partial class Form1 : Form
    {
        List<RectangleFigure> rectangleFigures;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            g = CreateGraphics();
            rectangleFigures = new List<RectangleFigure>()
            {
                new RectangleFigure(){X=0,Y=0,Height=100,Width=100,Actived=false},
                new RectangleFigure(){X=100,Y=100,Height=100,Width=100,Actived=false},
                new RectangleFigure(){X=200,Y=200,Height=100,Width=100,Actived=false},
                new RectangleFigure(){X=300,Y=300,Height=100,Width=100,Actived=false},
            };
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if(e.Graphics == g)
                Console.WriteLine("yes");

            rectangleFigures.ForEach(rec=> {
                rec.DrawMe(e.Graphics);
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.RotateTransform(60, MatrixOrder.Append);
            g.Clear(Color.Black);
            g.DrawLine(Pens.Red, new Point(500, 500), new Point(1000, 1000));
            Invalidate();
            //g.Transform = new Matrix(1, 0, 0, -1, ClientRectangle.Width / 2, ClientRectangle.Height / 2);
        }


        //public Form1()
        //{
        //    InitializeComponent();
        //    this.BackColor = Color.Black;

        //    this.DoubleBuffered = true;

        //    redPen = new Pen(Brushes.Red,3);

        //    entityObjs = new ArrayList() {
        //        new Rectangle(0,0,100,100),
        //        new Point(10,10),
        //        new Point(20,20),
        //        new Point(30,30),
        //    };

        //    matrix = new Matrix(1, 0, 0, 1, 10, 10);

        //    timer.Tick += (s, e) => { 
        //        rotateAngle += 1; 
        //        curTime = DateTime.Now;
        //        Invalidate();
        //    };

        //    timer.Start();

        //    m_Rect = new Rectangle(10, 10, 50, 30);
        //}

        //Graphics g;
        //Pen redPen;
        //ArrayList entityObjs;
        //Matrix matrix;
        //int rotateAngle = 0;
        //Timer timer = new Timer() { Interval =10, Enabled = true };
        //DateTime curTime;

        //private Rectangle m_Rect;
        //private Point m_LastMSPoint;


        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    e.Graphics.FillRectangle(SystemBrushes.ControlDark, this.m_Rect);
        //    e.Graphics.DrawRectangle(SystemPens.ControlDarkDark, this.m_Rect);
        //    //TextRenderer.DrawText(e.Graphics, curTime.ToString(), new Font("宋体", 10), new Point(500, 100), Color.AliceBlue);
        //    //e.Graphics.Transform = matrix;
        //    //e.Graphics.RotateTransform(rotateAngle>360?0:rotateAngle);
        //    //e.Graphics.DrawLine(redPen, new Point(10, 10),new Point(200, 200));
        //}

        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    base.OnMouseDown(e);
        //    this.m_LastMSPoint = e.Location;
        //}
        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    base.OnMouseMove(e);
        //    if (e.Button != MouseButtons.Left)
        //    {
        //        return;
        //    }
        //    this.m_Rect.Offset(e.Location.X - this.m_LastMSPoint.X, e.Location.Y - this.m_LastMSPoint.Y);
        //    //绘制新的图形 
        //    this.Invalidate();
        //    this.m_LastMSPoint = e.Location;
        //}





        //public partial class MoveRect : Form
        //{
        //    private Rectangle m_Rect;
        //    private Point m_LastMSPoint;
        //    public MoveRect()
        //    {
        //        InitializeComponent();
        //        this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        //        m_Rect = new Rectangle(10, 10, 50, 30);
        //    }
        //    protected override void OnPaint(PaintEventArgs e)
        //    {
        //        base.OnPaint(e);
        //        e.Graphics.FillRectangle(SystemBrushes.ControlDark, this.m_Rect);
        //        e.Graphics.DrawRectangle(SystemPens.ControlDarkDark, this.m_Rect);
        //    }
        //    protected override void OnMouseDown(MouseEventArgs e)
        //    {
        //        base.OnMouseDown(e);
        //        this.m_LastMSPoint = e.Location;
        //    }
        //    protected override void OnMouseMove(MouseEventArgs e)
        //    {
        //        base.OnMouseMove(e);
        //        if (e.Button != MouseButtons.Left)
        //        {
        //            return;
        //        }
        //        this.m_Rect.Offset(e.Location.X - this.m_LastMSPoint.X, e.Location.Y - this.m_LastMSPoint.Y);
        //        //绘制新的图形 
        //        this.Invalidate();
        //        this.m_LastMSPoint = e.Location;
        //    }
        //}

    }
}
