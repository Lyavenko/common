using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveEllipses
{
    abstract public class Shape
    {
        public readonly Model model;

        public Shape(Model parent,float x,float y)
        {
            this.position = new PointF(x, y);

            model = parent;
        }
        protected static float Sqr(float x)
        {
            return x * x;
        }

        public PointF position;
        abstract public void Paint();
        abstract public bool isInside(PointF p);
        abstract public bool isOnBorder(PointF p);

        public void MoveBy(float dx, float dy)
        {
            position = new PointF(position.X + dx, position.Y + dy);
        }
    }
}
