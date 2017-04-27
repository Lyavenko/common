using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveEllipses
{
    public class Ellipse:Shape
    {

        public float rx;
        public float ry;
        public Ellipse(Model m, float x, float y, float rx, float ry) 
            : base(m, x, y)
        {
            
            this.rx = rx;
            this.ry = ry;
        }
        public override bool isInside(System.Drawing.PointF p)
        {
            if (Sqr(p.X - position.X) / Sqr(rx) +
                Sqr(p.Y - position.Y) / Sqr(ry) < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool isOnBorder(System.Drawing.PointF p)
        {
            return false;
        }

        public override void Paint()
        {
            model.sp.DrawEllipse(this);
        }
    }
}
