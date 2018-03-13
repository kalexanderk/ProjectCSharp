using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question2
{


    public partial class Form1 : Form
    {
        Graphics drawArea;

        static bool checkval = false;
        static Point a = new Point(0, 0);
        static Point b = new Point(0, 0);
        static Point c = new Point(0, 0);
        static Point d = new Point(0, 0);
        Quadrangle figure = new Quadrangle(a.X, a.Y, b.X, b.Y, c.X, c.Y, d.X, d.Y);

        public Form1()
        {
            InitializeComponent();
            drawArea = drawingArea.CreateGraphics();
        }

        private void btnAngl_Click(object sender, EventArgs e)
        {
            double an = figure.AnglesQ(0);
            txtAnglA.Text = an.ToString("0.0000000");
            an = figure.AnglesQ(1);
            txtAnglB.Text = an.ToString("0.0000000");
            an = figure.AnglesQ(2);
            txtAnglC.Text = an.ToString("0.0000000");
            an = figure.AnglesQ(3);
            txtAnglD.Text = an.ToString("0.0000000");
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            txtArea.Clear();
            txtAnglA.Clear();
            txtAnglB.Clear();
            txtAnglC.Clear();
            txtAnglD.Clear();
            txtLenAB.Clear();
            txtLenBC.Clear();
            txtLenCD.Clear();
            txtLenDA.Clear();
            txtType.Clear();

            if ((txtAx.Text != "") && (txtAy.Text != "") && (txtBx.Text != "")
                && (txtBy.Text != "") && (txtCx.Text != "") && (txtCy.Text != "") &&
                (txtDx.Text != "") && (txtDy.Text != ""))
            {
                try
                {
                    double x = Convert.ToDouble(txtAx.Text);
                    double y = Convert.ToDouble(txtAy.Text);
                    a = new Point(x, y);
                    x = Convert.ToDouble(txtBx.Text);
                    y = Convert.ToDouble(txtBy.Text);
                    b = new Point(x, y);
                    x = Convert.ToDouble(txtCx.Text);
                    y = Convert.ToDouble(txtCy.Text);
                    c = new Point(x, y);
                    x = Convert.ToDouble(txtDx.Text);
                    y = Convert.ToDouble(txtDy.Text);
                    d = new Point(x, y);
                    checkval = true;
                }
                catch 
                {
                    MessageBox.Show("There's an error in your DATA.");
                    checkval = false;
                    btnArea.Enabled = false;
                    btnLen.Enabled = false;
                    btnAngl.Enabled = false;
                    btnGraph.Enabled = false;
                    btnType.Enabled = false;
                    drawArea.Clear(Color.White);
                }
            }
            if (checkval) 
            {
                figure = new Quadrangle(a.X, a.Y, b.X, b.Y, c.X, c.Y, d.X, d.Y);
                btnArea.Enabled = true;
                btnLen.Enabled = true;
                btnAngl.Enabled = true;
                btnGraph.Enabled = true;
                btnType.Enabled = true;
                drawArea.Clear(Color.White);
            }
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            double ar = figure.AreaQ();
            txtArea.Text = ar.ToString("0.0000");
        }


        private void btnLen_Click(object sender, EventArgs e)
        {
            txtLenAB.Text = figure.ABlen.ToString("0.0000000");
            txtLenBC.Text = figure.BClen.ToString("0.0000000");
            txtLenCD.Text = figure.CDlen.ToString("0.0000000");
            txtLenDA.Text = figure.DAlen.ToString("0.0000000");
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            Pen blackPen = new Pen(Color.Black);
            drawArea.DrawLine(blackPen, Convert.ToInt32(figure.A.X)+150, -Convert.ToInt32(figure.A.Y)+200, Convert.ToInt32(figure.B.X)+150, -Convert.ToInt32(figure.B.Y)+200);
            drawArea.DrawLine(blackPen, Convert.ToInt32(figure.B.X) + 150, -Convert.ToInt32(figure.B.Y) + 200, Convert.ToInt32(figure.C.X) + 150, -Convert.ToInt32(figure.C.Y) + 200);
            drawArea.DrawLine(blackPen, Convert.ToInt32(figure.C.X) + 150, -Convert.ToInt32(figure.C.Y) + 200, Convert.ToInt32(figure.D.X) + 150, -Convert.ToInt32(figure.D.Y) + 200);
            drawArea.DrawLine(blackPen, Convert.ToInt32(figure.D.X) + 150, -Convert.ToInt32(figure.D.Y) + 200, Convert.ToInt32(figure.A.X) + 150, -Convert.ToInt32(figure.A.Y) + 200);
        }

        private void btnType_Click(object sender, EventArgs e)
        {
            if (figure.IsParallelogram()) txtType.Text = "Parallelogram";
            else if (figure.IsRectangle()) txtType.Text = "Rectangle";
            else if (figure.IsRhombus()) txtType.Text = "Rhombus";
            else if (figure.IsSquare()) txtType.Text = "Square";
            else if (figure.IsTrapezoid()) txtType.Text = "Trapezoid";
            else txtType.Text = "Quadrangle";
        }



    }

    //----------------------------------------------------------------------------------------------------------

    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    //----------------------------------------------------------------------------------------------------------

    class Quadrangle
    {
        public Point A { set; get; }
        public Point B { set; get; }
        public Point C { set; get; }
        public Point D { set; get; }
        //additional variables for easier implementation
        private Point AD, AB, BC, CD;
        public double ABlen, BClen, CDlen, DAlen;
        //--------------------
        public Quadrangle(double ax, double ay, double bx, double by, double cx, double cy, double dx, double dy)
        {
            this.A = new Point(ax, ay);
            this.B = new Point(bx, by);
            this.C = new Point(cx, cy);
            this.D = new Point(dx, dy);
            this.AD = new Point(D.X - A.X, D.Y - A.Y);
            this.AB = new Point(B.X - A.X, B.Y - A.Y);
            this.BC = new Point(C.X - B.X, C.Y - B.Y);
            this.CD = new Point(D.X - C.X, D.Y - C.Y);
            this.ABlen = Math.Sqrt(Math.Pow(AB.X, 2) + Math.Pow(AB.Y, 2));
            this.DAlen = Math.Sqrt(Math.Pow(AD.X, 2) + Math.Pow(AD.Y, 2));
            this.BClen = Math.Sqrt(Math.Pow(BC.X, 2) + Math.Pow(BC.Y, 2));
            this.CDlen = Math.Sqrt(Math.Pow(CD.X, 2) + Math.Pow(CD.Y, 2));
        }
        //--------------------
        public double AnglesQ(int ii)
        {
            //for angleA
            if (ii==0)
            {
                return Math.Acos((AB.X * AD.X + AB.Y * AD.Y) / (this.ABlen * this.DAlen));
            }
            //for angleB
            else if (ii == 1)
            {
                return Math.Acos(((-AB.X) * BC.X + (-AB.Y) * BC.Y) / (this.ABlen * this.BClen));
            }
            //for angleC
            else if (ii == 2)
            {
                return Math.Acos(((-BC.X) * CD.X + (-BC.Y) * CD.Y) / (this.BClen * this.CDlen));
            }
            //for angleD
            else if (ii == 3)
            {
                return Math.Acos(((-AD.X) * (-CD.X) + (-AD.Y) * (-CD.Y)) / (this.CDlen * this.DAlen));
            }
            else return 0;
        }
        //--------------------
        public bool IsTrapezoid()
        {
            if ((this.ABlen * this.CDlen == Math.Abs(this.AB.X * this.CD.X + this.AB.Y * this.CD.Y)) && (this.ABlen != this.CDlen) &&
                ((AnglesQ(0) >= Math.PI / 2 && AnglesQ(1) >= Math.PI / 2) || (AnglesQ(2) >= Math.PI / 2 && AnglesQ(3) >= Math.PI / 2))) return true;
            if ((this.DAlen * this.BClen == Math.Abs(this.AD.X * this.BC.X + this.AD.Y * this.BC.Y)) && (this.DAlen != this.BClen) &&
                ((AnglesQ(1) >= Math.PI / 2 && AnglesQ(2) >= Math.PI / 2) || (AnglesQ(0) >= Math.PI / 2 && AnglesQ(3) >= Math.PI / 2))) return true;
            else return false;

        }
        //--------------------
        public bool IsRectangle()
        {
            if (this.IsSquare()) return false;
            else
            {
                if (AnglesQ(0) == AnglesQ(1) && AnglesQ(1) == AnglesQ(2) && AnglesQ(2) == AnglesQ(3)) return true;
                else return false;
            }
        }
        //--------------------
        public bool IsSquare()
        {
            if (AnglesQ(0) == AnglesQ(1) && AnglesQ(1) == AnglesQ(2) && AnglesQ(2) == AnglesQ(3) && (this.ABlen == this.BClen && this.BClen == this.CDlen && this.CDlen == this.DAlen)) return true;
            else return false;
        }
        //--------------------
        public bool IsParallelogram()
        {
            if (this.IsSquare()) return false;
            else if (this.IsRectangle()) return false;
            else if (this.IsRhombus()) return false;
            else
            {
                //AC
                double acxm, acym;
                double acx = Math.Abs(this.A.X - this.C.X) / 2;
                double acy = Math.Abs(this.A.Y - this.C.Y) / 2;
                if (this.A.X < this.C.X) acxm = this.A.X + acx;
                else acxm = this.C.X + acx;
                if (this.A.Y < this.C.Y) acym = this.A.Y + acy;
                else acym = this.C.Y + acy;
                //BD
                double bdxm, bdym;
                double bdx = Math.Abs(this.B.X - this.D.X) / 2;
                double bdy = Math.Abs(this.D.Y - this.B.Y) / 2;
                if (this.B.X < this.D.X) bdxm = this.B.X + bdx;
                else bdxm = this.D.X + bdx;
                if (this.B.Y < this.D.Y) bdym = this.B.Y + bdy;
                else bdym = this.D.Y + bdy;
                if ((bdxm == acxm) && (bdym == acym) && (this.ABlen == this.CDlen) && (this.DAlen == this.BClen) && (AnglesQ(0) == AnglesQ(2))) return true;
                else return false;
            }
        }
        //--------------------
        public bool IsRhombus()
        {
            if (this.IsSquare()) return false;
            else
            {
                //AC
                double acxm, acym;
                double acx = Math.Abs(this.A.X - this.C.X) / 2;
                double acy = Math.Abs(this.A.Y - this.C.Y) / 2;
                if (this.A.X < this.C.X) acxm = this.A.X + acx;
                else acxm = this.C.X + acx;
                if (this.A.Y < this.C.Y) acym = this.A.Y + acy;
                else acym = this.C.Y + acy;
                //BD
                double bdxm, bdym;
                double bdx = Math.Abs(this.B.X - this.D.X) / 2;
                double bdy = Math.Abs(this.D.Y - this.B.Y) / 2;
                if (this.B.X < this.D.X) bdxm = this.B.X + bdx;
                else bdxm = this.D.X + bdx;
                if (this.B.Y < this.D.Y) bdym = this.B.Y + bdy;
                else bdym = this.D.Y + bdy;
                if ((bdxm == acxm) && (bdym == acym) && (this.ABlen == this.CDlen) && (this.DAlen == this.BClen) && (AnglesQ(0) == AnglesQ(2)) && ((this.A.X - this.C.X) * (this.B.X - this.D.X) + (this.A.Y - this.C.Y) * (this.B.Y - this.D.Y) == 0)) return true;
                else return false;
            }
        }

        //--------------------
        public double AreaQ()
        {
            return 0.5 * this.DAlen * this.CDlen * Math.Sin(AnglesQ(3)) + 0.5 * this.ABlen * this.BClen * Math.Sin(AnglesQ(1));
        }
    }

}
