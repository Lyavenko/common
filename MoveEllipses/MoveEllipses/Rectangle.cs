using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveEllipses
{
    public class Rectangle: Shape
    {
        public float width;
        public float height;
        public Rectangle(Model m, float x, float y, float width, float height) 
            : base(m, x, y)
        {

            this.width = width;
            this.height = height;
        }
        public override bool isInside(System.Drawing.PointF p)
        {
            if ((p.X > position.X) && (p.X < position.X + width) &&
                (p.Y > position.Y) && (p.Y < position.Y + height))
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
            model.sp.DrawRectangle(this);
        }
    }
}
