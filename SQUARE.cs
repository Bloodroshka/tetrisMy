using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class SQUARE : FIGURE
    {
        public override List<Point> FillPoint
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
    }
}
