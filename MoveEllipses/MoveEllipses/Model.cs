using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveEllipses
{
    public class Model
    {
        public IShapesPainter sp;

        public void addEllipse(float x, float y, float rx, float ry) {
            shapes.Add(new Ellipse(this,x,y,rx,ry));
        }

        public Model(IShapesPainter sp)
        {
            this.sp = sp;
        }


        public List<Shape> shapes = new List<Shape>();


    }
}
