using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDI_MVC
{
    class Model
    {
        public PointF position;
        public float vx;
        public float vy; // px / s
        IMovingStarView msv;
        public Model(IMovingStarView msv)
        {
            position = new PointF(100, 100);
            vx = 0;
            vy = 0;
            this.msv = msv;
        }
        DateTime lastFrame = DateTime.Now;
        public void Move()
        {
            float deltaT = (float) (DateTime.Now-lastFrame).Milliseconds*0.001f;
            lastFrame = DateTime.Now;
            position = new PointF(
                position.X + vx * deltaT,
                position.Y + vy * deltaT
                );

            msv.DrawMovingStar();
           // System.Threading.Thread.Sleep(500);
        }
        
    }
}
