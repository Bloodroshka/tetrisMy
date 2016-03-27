using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class TTTTTT : FIGURE
    {
        public override List<Point> FillPoint
        {
            get
            {
                List<Point> result = new List<Point>();
                switch (state)
                {
                    case (0):
                        result.Add(place);
                        result.Add(new Point(place.X, place.Y + razm));
                        result.Add(new Point(place.X - razm, place.Y + razm));
                        result.Add(new Point(place.X + razm, place.Y + razm));
                        break;
                    case (1):
                        result.Add(place);
                        result.Add(new Point(place.X, place.Y + razm));
                        result.Add(new Point(place.X + razm, place.Y + razm));
                        result.Add(new Point(place.X, place.Y + razm + razm));
                        break;
                    case (2):
                        result.Add(place);
                        result.Add(new Point(place.X, place.Y + razm));
                        result.Add(new Point(place.X - razm, place.Y));
                        result.Add(new Point(place.X + razm, place.Y));
                        break;
                    case (3):
                        result.Add(place);
                        result.Add(new Point(place.X, place.Y + razm));
                        result.Add(new Point(place.X - razm, place.Y + razm));
                        result.Add(new Point(place.X, place.Y + razm + razm));
                        break;

                }
                return result;
            }
        }
        public override void rotate()
        {
            state = (state + 1) % 4;
        }
    }
}
