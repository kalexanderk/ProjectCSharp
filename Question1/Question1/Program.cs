using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Question1
{
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
        private Point A, B, C, D;
        //additional variables for easier implementation
        private Point AD, AB, BC, CD;
        private double ABlen, BClen, CDlen, DAlen;
        //--------------------
        public Quadrangle()
        {

            double x = 0, y = 0; bool checkval; string[] list_n = new string[4] { "A", "B", "C", "D" };

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("    Input coordinates of "+list_n[i]);
                do
                {
                    Console.Write("    x: ");
                    try
                    {
                        x = Convert.ToDouble(Console.ReadLine());
                        checkval = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("    Please, input x again.");
                        checkval = false;
                    }
                } while (checkval == false);
                do
                {
                    Console.Write("    y: ");
                    try
                    {
                        y = Convert.ToDouble(Console.ReadLine());
                        checkval = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("    Please, input y again.");
                        checkval = false;
                    }
                } while (checkval == false);

                switch (i)
                {
                    case 0: this.A = new Point(x, y); break;
                    case 1: this.B = new Point(x, y); break;
                    case 2: this.C = new Point(x, y); break;
                    case 3: this.D = new Point(x, y); break;
                }
                
            }
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
        private double AnglesQ(Point poi)
        {
            //for angleA
            if (poi == this.A)
            {
                return Math.Acos((AB.X * AD.X + AB.Y * AD.Y) / (this.ABlen * this.DAlen));
            }
            //for angleB
            else if (poi == this.B)
            {
                return Math.Acos(((-AB.X) * BC.X + (-AB.Y) * BC.Y) / (this.ABlen * this.BClen));
            }
            //for angleC
            else if (poi == this.C)
            {
                return Math.Acos(((-BC.X) * CD.X + (-BC.Y) * CD.Y) / (this.BClen * this.CDlen));
            }
            //for angleD
            else if (poi == this.D)
            {
                return Math.Acos(((-AD.X) * (-CD.X) + (-AD.Y) * (-CD.Y)) / (this.CDlen * this.DAlen));
            }
            else return 0;
        }
        //--------------------
        public bool IsTrapezoid()
        {
            if ((this.ABlen*this.CDlen==Math.Abs(this.AB.X*this.CD.X+this.AB.Y*this.CD.Y)) && (this.ABlen != this.CDlen) &&
                ((AnglesQ(A)>=Math.PI/2 && AnglesQ(B)>=Math.PI/2) || (AnglesQ(C)>=Math.PI/2 && AnglesQ(D)>=Math.PI/2))) return true;
            if ((this.DAlen * this.BClen == Math.Abs(this.AD.X * this.BC.X + this.AD.Y * this.BC.Y)) && (this.DAlen != this.BClen)&&
                ((AnglesQ(B) >= Math.PI / 2 && AnglesQ(C) >= Math.PI / 2) || (AnglesQ(A) >= Math.PI / 2 && AnglesQ(D) >= Math.PI / 2))) return true;
            else return false;

        }
        //--------------------
        public bool IsRectangle()
        {
            if (this.IsSquare()) return false;
            else
            {
                if (AnglesQ(this.A) == AnglesQ(this.B) && AnglesQ(this.B) == AnglesQ(this.C) && AnglesQ(this.C) == AnglesQ(this.D)) return true;
                else return false;
            }
        }
        //--------------------
        public bool IsSquare()
        {
            if (AnglesQ(this.A) == AnglesQ(this.B) && AnglesQ(this.B) == AnglesQ(this.C) && AnglesQ(this.C) == AnglesQ(this.D) && (this.ABlen == this.BClen && this.BClen == this.CDlen && this.CDlen == this.DAlen)) return true;
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
                if ((bdxm == acxm) && (bdym == acym) && (this.ABlen == this.CDlen) && (this.DAlen == this.BClen) && (AnglesQ(A) == AnglesQ(C))) return true;
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

                if ((bdxm == acxm) && (bdym == acym) && (this.ABlen == this.CDlen) && (this.DAlen == this.BClen) && (AnglesQ(A) == AnglesQ(C)) && ((this.A.X - this.C.X) * (this.B.X - this.D.X) + (this.A.Y - this.C.Y) * (this.B.Y - this.D.Y) == 0)) return true;
                else return false;
            }
        }
        //--------------------
        public double AreaQ()
        {
            return 0.5 * this.DAlen * this.CDlen * Math.Sin(AnglesQ(this.D)) + 0.5 * this.ABlen * this.BClen * Math.Sin(AnglesQ(this.B));
        }
    }

//----------------------------------------------------------------------------------------------------------

    class Program
    {
        static void Main(string[] args)
        {
            Quadrangle[] f = new Quadrangle[4];
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("    #{0}", i + 1);
                f[i] = new Quadrangle();
                if (f[i].IsSquare()) Console.WriteLine("    This is a square.");
                else if (f[i].IsRectangle()) Console.WriteLine("    This is a rectangle.");
                else if (f[i].IsRhombus()) Console.WriteLine("    This is a rhombus.");
                else if (f[i].IsTrapezoid()) Console.WriteLine("    This is a trapezoid.");
                else if (f[i].IsParallelogram()) Console.WriteLine("    This is a parallelogram.");
                else Console.WriteLine("    This is a quadrangle.");
                Console.WriteLine("    The area is: {0}\n",f[i].AreaQ());
            }
        }
    }
}
