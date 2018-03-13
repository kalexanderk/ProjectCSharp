using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question4
{
    public partial class Form1 : Form
    {
        Graphics drawArea;
        public Form1()
        {
            InitializeComponent();
            drawArea = drawingArea.CreateGraphics();
        }

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


        public int count = 0;
        Point p1, p2, p3, p4, pp;
        LineSegment ls1, ls2;

        private void btnAddLS_Click(object sender, EventArgs e)
        {
            if(txtAx.Text != "" && txtAy.Text != "" && txtBx.Text != "" && txtBy.Text != "")
                try
                {
                    double x_tem = Convert.ToDouble(txtAx.Text);
                    x_tem = Convert.ToDouble(txtAy.Text);
                    x_tem = Convert.ToDouble(txtBx.Text);
                    x_tem = Convert.ToDouble(txtBy.Text);
                    listBoxAx.Items.Add(txtAx.Text);
                    listBoxAy.Items.Add(txtAy.Text);
                    listBoxBx.Items.Add(txtBx.Text);
                    listBoxBy.Items.Add(txtBy.Text);
                    txtAx.Clear();
                    txtAy.Clear();
                    txtBx.Clear();
                    txtBy.Clear();
                    btnApply.Enabled = true;
                    count++;
                    listBoxSL1.Items.Add(count.ToString());
                    listBoxSL2.Items.Add(count.ToString());
                }
                catch
                {
                    MessageBox.Show("Error in your DATA!");
                }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            count = 0;
            listBoxAx.Items.Clear();
            listBoxAy.Items.Clear();
            listBoxBx.Items.Clear();
            listBoxBy.Items.Clear();
            listBoxSL1.Items.Clear();
            listBoxSL2.Items.Clear();
            drawArea.Clear(Color.White);
            txtPx.Clear();
            txtPy.Clear();
            txtLen.Clear();
            txtAngle.Clear();
            txtAbove.Clear();
            txtLeft.Clear();
            txtParal.Clear();
            txtMiddle.Clear();
            txtEnd.Clear();
            btnApply.Enabled = false;
            btnLen.Enabled = false;
            btnAngle.Enabled = false;
            btnAbove.Enabled = false;
            btnLeft.Enabled = false;
            btnParal.Enabled = false;
            btnMiddle.Enabled = false;
            btnEnd.Enabled = false;
            bthGraph.Enabled = false;
        }

        private void btnLen_Click(object sender, EventArgs e)
        {
            txtLen.Text = ls1.Length().ToString();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (listBoxSL1.SelectedItems.Count == 1 && listBoxSL1.SelectedItems.Count == 1 &&
                txtPx.Text != "" && txtPy.Text != "")
            {
                int ind_SL1 = Convert.ToInt32(listBoxSL1.SelectedItem);
                int ind_SL2 = Convert.ToInt32(listBoxSL2.SelectedItem);
                double aa, bb;
                aa=Convert.ToDouble(listBoxAx.Items[ind_SL1-1]);
                bb=Convert.ToDouble(listBoxAy.Items[ind_SL1-1]);
                p1 = new Point(aa,bb);
                aa=Convert.ToDouble(listBoxBx.Items[ind_SL1-1]);
                bb = Convert.ToDouble(listBoxBy.Items[ind_SL1 - 1]);
                p2 = new Point(aa, bb);
                aa = Convert.ToDouble(listBoxAx.Items[ind_SL2- 1]);
                bb = Convert.ToDouble(listBoxAy.Items[ind_SL2- 1]);
                p3 = new Point(aa,bb);
                aa = Convert.ToDouble(listBoxBx.Items[ind_SL2 - 1]);
                bb = Convert.ToDouble(listBoxBy.Items[ind_SL2 - 1]);
                p4 = new Point(aa,bb);

                ls1 = new LineSegment(p1, p2);
                ls2 = new LineSegment(p3, p4);

                pp = new Point(Convert.ToDouble(txtPx.Text), Convert.ToDouble(txtPy.Text));
                btnLen.Enabled = true;
                btnAngle.Enabled = true;
                btnAbove.Enabled = true;
                btnLeft.Enabled = true;
                btnParal.Enabled = true;
                btnMiddle.Enabled = true;
                btnEnd.Enabled = true;
                bthGraph.Enabled = true;
                drawArea.Clear(Color.White);
            }

        }

        private void btnAngle_Click(object sender, EventArgs e)
        {
            txtAngle.Text = ls1.Angle().ToString();
        }

        private void btnAbove_Click(object sender, EventArgs e)
        {
            bool tf = ls1.AboveLine(pp);
            txtAbove.Text = tf.ToString();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            bool tf = ls1.OnLeft(pp);
            txtLeft.Text = tf.ToString();
        }

        private void btnParal_Click(object sender, EventArgs e)
        {
            bool tf = ls1.Parallel(ls2);
            txtParal.Text = tf.ToString();
        }

        private void btnMiddle_Click(object sender, EventArgs e)
        {
            bool tf = ls1.MeetInTheMiddle(ls2);
            txtMiddle.Text = tf.ToString();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            bool tf = ls1.MeetAtTheEnd(ls2);
            txtEnd.Text = tf.ToString();
        }

        private void bthGraph_Click(object sender, EventArgs e)
        {
            Pen blackPen = new Pen(Color.Black);
            drawArea.DrawLine(blackPen, Convert.ToInt32(ls1.A.X) + 150, -Convert.ToInt32(ls1.A.Y) + 200, Convert.ToInt32(ls1.B.X) + 150, -Convert.ToInt32(ls1.B.Y) + 200);
            drawArea.DrawLine(blackPen, Convert.ToInt32(ls2.A.X) + 150, -Convert.ToInt32(ls2.A.Y) + 200, Convert.ToInt32(ls2.B.X) + 150, -Convert.ToInt32(ls2.B.Y) + 200);
          
        }

    }
}
