using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Class1
    {
        public int razm = 15;
        public Color cl = Color.Yellow;
        Random r = new Random();
        public Point place = new Point();
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
        public List<Point> FillPoint
        {
            get
            {
                List<Point> result = new List<Point>();
                result.Add(place);
                result.Add(new Point(place.X, place.Y + razm));
                result.Add(new Point(place.X + razm, place.Y + razm));
                result.Add(new Point(place.X + razm, place.Y));
                return result;
            }
        }
        public void stepfigure()
        {
            place = new Point(place.X, place.Y + razm);
        }
        public Point middlethemostleft
        {
            get
            {
                Point mtml = new Point(place.X, place.Y + razm);
                return mtml;
            }
        }
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
    }
}
