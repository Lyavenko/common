using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveEllipses
{
    public class Model
    {
        public IShapesPainter sp;

        public Shape SelectedShape
        {
            private set;
            get;
        }

        public void addEllipse(float x, float y, float rx, float ry)
        {
            shapes.Add(new Ellipse(this, x, y, rx, ry));
        }
        public void addRectangle(float x, float y, float w, float h)
        {
            shapes.Add(new Rectangle(this, x, y, w, h));
        }

        public Model(IShapesPainter sp)
        {
            this.sp = sp;
        }

        public void Paint()
        {
            foreach (Shape s in shapes)
            {
                s.Paint();
            }
        }

        public Shape SelectShape(float x, float y)
        {
            Shape candidate = null;
            foreach (Shape s in shapes)
            {
                if (s.isInside(new PointF(x, y)))
                {
                    candidate = s;
                }
            }
            SelectedShape = candidate;
            return SelectedShape;
        }

        public List<Shape> shapes = new List<Shape>();



        internal void MoveSelectionToFront()
        {
            int index = shapes.IndexOf(SelectedShape);
            if (index == shapes.Count - 1)
            {
                return;
            }
            var temp = shapes[index];
            shapes[index] = shapes[index + 1];
            shapes[index + 1] = temp;
        }
    }
}
