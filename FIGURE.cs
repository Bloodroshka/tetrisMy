using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class FIGURE
    {
        //поля
        public int razm
        {
            get { return 15; }
        }
        public Color cl = Color.Yellow;
        public Point place = new Point();
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
