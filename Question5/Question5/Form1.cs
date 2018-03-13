using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question5
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
        LineSegment ls1;
        LineSegment ls2;
        LineSegment ls3;
        LineSegment ls4;

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
            drawArea.Clear(Color.White);

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
                    drawArea.Clear(Color.White);
                }
            }
            if (checkval)
            {
                figure = new Quadrangle(a.X, a.Y, b.X, b.Y, c.X, c.Y, d.X, d.Y);
                ls1 = new LineSegment(figure.A, figure.D);
                ls2 = new LineSegment(figure.B, figure.C);
                ls3 = new LineSegment(figure.A, figure.B);
                ls4 = new LineSegment(figure.C, figure.D);
                if (ls1.DoNotMeet(ls2) && ls3.DoNotMeet(ls4))
                {
                    btnArea.Enabled = false;
                    btnLen.Enabled = false;
                    btnAngl.Enabled = false;
                    btnGraph.Enabled = false;
                    checkval = false;
                    MessageBox.Show("Quadrangle not of the type2!");
                }
                else
                {
                    figure.ADtype = false;
                    figure.ABtype = false;
                    btnArea.Enabled = true;
                    btnLen.Enabled = true;
                    btnAngl.Enabled = true;
                    btnGraph.Enabled = true;
                    if (!ls1.DoNotMeet(ls2))
                    {
                        figure.ADtype = true;
                        figure.ABtype = false;
                    }
                    if (!ls3.DoNotMeet(ls4))
                    {
                        figure.ABtype = true;
                        figure.ADtype = false;
                    }
                }
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
            drawArea.DrawLine(blackPen, Convert.ToInt32(figure.A.X) + 150, -Convert.ToInt32(figure.A.Y) + 150, Convert.ToInt32(figure.B.X) + 150, -Convert.ToInt32(figure.B.Y) + 150);
            drawArea.DrawLine(blackPen, Convert.ToInt32(figure.B.X) + 150, -Convert.ToInt32(figure.B.Y) + 150, Convert.ToInt32(figure.C.X) + 150, -Convert.ToInt32(figure.C.Y) + 150);
            drawArea.DrawLine(blackPen, Convert.ToInt32(figure.C.X) + 150, -Convert.ToInt32(figure.C.Y) + 150, Convert.ToInt32(figure.D.X) + 150, -Convert.ToInt32(figure.D.Y) + 150);
            drawArea.DrawLine(blackPen, Convert.ToInt32(figure.D.X) + 150, -Convert.ToInt32(figure.D.Y) + 150, Convert.ToInt32(figure.A.X) + 150, -Convert.ToInt32(figure.A.Y) + 150);
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
        private Point _a, _b, _c, _d;
        public bool ABtype;
        public bool ADtype;
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
            if (ii == 0)
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

        double CrossProduct(Point A, Point B)
        {
            return A.X * B.Y - B.X * A.Y;
        }
        //--------------------
        public double AreaQ()
        {
            double arrr =0;
            Point inter = new Point(0, 0);
            if (this.ADtype && !this.ABtype)
            {
                Point r = new Point(this.B.X - this.C.X, this.B.Y - this.C.Y);
                Point s = new Point(this.A.X - this.D.X, this.A.Y - this.D.Y);
                Point qp = new Point(this.D.X - this.C.X, this.D.Y - this.C.Y);
                if ((CrossProduct(r, s) != 0) && (CrossProduct(qp, s) / CrossProduct(r, s) >= 0) &&
                    (CrossProduct(qp, s) / CrossProduct(r, s) <= 1) &&
                    (CrossProduct(qp, r) / CrossProduct(r, s) >= 0) &&
                    (CrossProduct(qp, r) / CrossProduct(r, s) <= 1))
                {
                    inter = new Point(this.C.X + CrossProduct(qp, s) / CrossProduct(r, s) * r.X, this.C.Y + CrossProduct(qp, s) / CrossProduct(r, s) * r.Y);
                }
                arrr = Math.Sqrt((inter.X - this.C.X) * (inter.X - this.C.X) + (inter.Y - this.C.Y) * (inter.Y - this.C.Y)) * CDlen * 0.5 * Math.Sin(AnglesQ(2)) +
       Math.Sqrt((inter.X - this.A.X) * (inter.X - this.A.X) + (inter.Y - this.A.Y) * (inter.Y - this.A.Y)) * ABlen * 0.5 * Math.Sin(AnglesQ(0));
            }
            if (!this.ADtype && this.ABtype)
            {
                Point r = new Point(this.C.X - this.D.X, this.C.Y - this.D.Y);
                Point s = new Point(this.B.X - this.A.X, this.B.Y - this.A.Y);
                Point qp = new Point(this.A.X - this.D.X, this.A.Y - this.D.Y);
                if ((CrossProduct(r, s) != 0) && (CrossProduct(qp, s) / CrossProduct(r, s) >= 0) &&
                    (CrossProduct(qp, s) / CrossProduct(r, s) <= 1) &&
                    (CrossProduct(qp, r) / CrossProduct(r, s) >= 0) &&
                    (CrossProduct(qp, r) / CrossProduct(r, s) <= 1))
                {
                    inter = new Point(this.A.X + CrossProduct(qp, s) / CrossProduct(r, s) * r.X, this.A.Y + CrossProduct(qp, s) / CrossProduct(r, s) * r.Y);
                }
                arrr = Math.Sqrt((inter.X - this.D.X) * (inter.X - this.D.X) + (inter.Y - this.D.Y) * (inter.Y - this.D.Y)) * DAlen * 0.5 * Math.Sin(AnglesQ(3)) +
       Math.Sqrt((inter.X - this.B.X) * (inter.X - this.B.X) + (inter.Y - this.B.Y) * (inter.Y - this.B.Y)) * BClen * 0.5 * Math.Sin(AnglesQ(1));
            }
            return arrr;
        }
    }


    class LineSegment
    {
        private Point _a, _b;
        public Point A { get; set; }
        public Point B { get; set; }
        private double _slope;
        public double Slope
        {
            get;
            set;
        }
        public LineSegment(Point a, Point b)
        {
            this.A = new Point(a.X, a.Y);
            this.B = new Point(b.X, b.Y);
        }
        public double Length()
        {
            double xx = this.B.X - this.A.X;
            double yy = this.B.Y - this.A.Y;
            return Math.Sqrt(Math.Pow(xx, 2) + Math.Pow(yy, 2));
        }
        public double Angle()
        {
            if (this.A.X != this.B.X)
            {
                if (this.B.X > this.A.X)
                    this.Slope = (this.B.Y - this.A.Y) / (this.B.X - this.A.X);
                else this.Slope = (this.A.Y - this.B.Y) / (this.A.X - this.B.X);
                return Math.PI / 2 - Math.Atan(this.Slope);
            }
            else if (this.A.Y != this.B.Y) return 0;
            else { Console.WriteLine("Error!"); return 0; }
        }
        public bool AboveLine(Point R)
        {
            if (Math.Sin(this.Angle()) != 0)
            {
                if (this.A.X != this.B.X)
                    if (this.B.X > this.A.X)
                        this.Slope = (this.B.Y - this.A.Y) / (this.B.X - this.A.X);
                    else this.Slope = (this.A.Y - this.B.Y) / (this.A.X - this.B.X);
                double y_temp = this.Slope * (R.X - A.X) + A.Y;
                if (R.Y > y_temp) return true;
                else return false;
            }
            else return false;
        }
        public bool BelowLine(Point R)
        {
            if (Math.Sin(this.Angle()) != 0) return !this.AboveLine(R);
            else return false;
        }
        public bool OnLeft(Point R)
        {
            if (Math.Sin(this.Angle()) == 0)
                if (R.X < A.X) return true;
                else return false;
            else return false;
        }
        public bool OnRight(Point R)
        {
            if (Math.Sin(this.Angle()) == 0)
                if (R.X > A.X) return true;
                else return false;
            else return false;
        }
        public bool Parallel(LineSegment L2)
        {
            if (this.Angle() == L2.Angle()) return true;
            else return false;
        }
        public bool MeetInTheMiddle(LineSegment L2)
        {
            //intersect exactly in the middle of each other?
            //for this
            double abxm, abym;
            double abx = Math.Abs(this.A.X - this.B.X) / 2;
            double aby = Math.Abs(this.A.Y - this.B.Y) / 2;
            if (this.A.X < this.B.X) abxm = this.A.X + abx;
            else abxm = this.B.X + abx;
            if (this.A.Y < this.B.Y) abym = this.A.Y + aby;
            else abym = this.B.Y + aby;
            //for L2
            double abxm2, abym2;
            double abx2 = Math.Abs(L2.A.X - L2.B.X) / 2;
            double aby2 = Math.Abs(L2.A.Y - L2.B.Y) / 2;
            if (L2.A.X < L2.B.X) abxm2 = L2.A.X + abx2;
            else abxm2 = L2.B.X + abx2;
            if (L2.A.Y < L2.B.Y) abym2 = L2.A.Y + aby2;
            else abym2 = L2.B.Y + aby2;

            if ((abxm == abxm2) && (abym == abym2)) return true;
            else return false;
        }
        public bool MeetAtTheEnd(LineSegment L2)
        {
            //L2 intersects with this line exactly at the end of this line?
            if (L2.A.X != L2.B.X)
            {
                if (L2.B.X > L2.A.X)
                    L2.Slope = (L2.B.Y - L2.A.Y) / (L2.B.X - L2.A.X);
                else L2.Slope = (L2.A.Y - L2.B.Y) / (L2.A.X - L2.B.X);
                if ((this.A.Y - L2.A.Y == L2.Slope * (this.A.X - L2.A.X)) ||
                    (this.B.Y - L2.A.Y == L2.Slope * (this.B.X - L2.A.X))) return true;
                else return false;
            }
            else if (L2.A.Y != L2.B.Y)
                if (this.A.X == L2.A.X || this.B.X == L2.A.X) return true;
                else return false;
            else if ((this.A.X == L2.A.X && this.A.Y == L2.A.Y) || (this.B.X == L2.A.X && this.B.Y == L2.A.Y)) return true;
            else return false;
        }
        double CrossProduct(Point A, Point B)
        {
            return A.X * B.Y - B.X * A.Y;
        }
        public bool DoNotMeet(LineSegment L2)
        {
            //Do not intersect?
            Point r = new Point(this.B.X - this.A.X, this.B.Y - this.A.Y);
            Point s = new Point(L2.B.X - L2.A.X, L2.B.Y - L2.A.Y);
            Point qp = new Point(L2.A.X - this.A.X, L2.A.Y - this.A.Y);
            if (CrossProduct(r, s) == 0) return true;
            else if ((CrossProduct(r, s) != 0) && (CrossProduct(qp, s) / CrossProduct(r, s) >= 0) &&
                (CrossProduct(qp, s) / CrossProduct(r, s) <= 1) &&
                (CrossProduct(qp, r) / CrossProduct(r, s) >= 0) &&
                (CrossProduct(qp, r) / CrossProduct(r, s) <= 1))
            {
                Point inter = new Point(this.A.X + CrossProduct(qp, s) / CrossProduct(r, s) * r.X, this.A.Y + CrossProduct(qp, s) / CrossProduct(r, s) * r.Y);
                Console.WriteLine("(They intersect in the point ({0},{1}).)", inter.X, inter.Y);
                return false;
            }
            else return true;
        }
    }


}
