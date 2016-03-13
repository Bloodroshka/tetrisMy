using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    abstract class FIGURE
    {
        //поля
        public int razm
        {
            get { return 15; }
        }
        public Color cl = Color.Yellow;
        public Point place = new Point(15, 0);
        public Point right
        {
            get
            {
                Point a = place;
                foreach (Point p in FillPoint)
                {
                    if (p.X > a.X)
                    {
                        a = p;
                    }
                }

                return a;
            }
        }
        public abstract List<Point> FillPoint
        {
            get;
        }
        public Point middlethemostleft
        {
            get
            {
                Point mtml = new Point(place.X, place.Y + razm);
                return mtml;
            }
        }
        public Point snt
        {
            get
            {
                Point a = place;
                foreach (Point p in FillPoint)
                {
                    if (p.Y > a.Y)
                    {
                        a = p;
                    }
                }

                return a;
            }
        }
        public Point slt
        {
            get
            {
                Point a = place;
                foreach (Point p in FillPoint)
                {
                    if (p.X < a.X)
                    {
                        a = p;
                    }
                }

                return a;
            }
        }
        //методы
        public void drawfigure(Graphics holst)
        {
            Pen pn = new Pen(Color.Crimson, 2);
            SolidBrush br = new SolidBrush(cl);
            foreach (Point pt in FillPoint)
            {
                holst.FillRectangle(br, pt.X, pt.Y, razm, razm);
                holst.DrawRectangle(pn, pt.X, pt.Y, razm, razm);
            }
        }
        
        public void stepfigure()
        {
            place = new Point(place.X, place.Y + razm);
        }
       
    }
}
