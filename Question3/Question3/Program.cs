using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question3
{
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
            return Math.Sqrt(Math.Pow(xx, 2)+Math.Pow(yy,2));
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
            else {Console.WriteLine ("Error!"); return 0 ;}
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

    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(1, 2);
            Point p2 = new Point(4, 4);
            LineSegment ls1 = new LineSegment(p1, p2);
            Point p3 = new Point(2, 1);
            Point p4 = new Point(3, 5);
            LineSegment ls2 = new LineSegment(p3, p4);
            Console.WriteLine("Length: {0}", ls1.Length());
            Console.WriteLine("Angle: {0}", ls1.Angle());
            Console.WriteLine("Above line point ({0}, {1}): {2}", p4.X, p4.Y,ls1.AboveLine(p4));
            Console.WriteLine("Below line point ({0}, {1}): {2}", p3.X, p3.Y, ls1.BelowLine(p3));
            Console.WriteLine("Parallel to ls2: {0}", ls1.Parallel(ls2));
            Console.WriteLine("Meet in the middle with l2: {0}", ls1.MeetInTheMiddle(ls2));
            Console.WriteLine("ls2 meets ls1 at the end point of ls1: {0}", ls1.MeetAtTheEnd(ls2));
            Console.WriteLine("ls1 and ls2 do not meet: {0}", ls1.DoNotMeet(ls2));



        }
    }
}
