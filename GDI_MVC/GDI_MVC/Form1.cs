using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDI_MVC
{
    public partial class Form1 : Form,IMovingStarView
    {
        Model m;
        public Form1()
        {
            InitializeComponent();

            m = new Model(this);
        }

        Pen p = new Pen(Color.LightPink, 5);

        float rotation = 0f;


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
       

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m.Move();
            
            rotation += 0.01f;
        }

        public void DrawMovingStar()
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.Beige);
            List<PointF> starPoints = new List<PointF>();
            for (int i = 0; i < 23; i++)
            {
                float r = 100;
                float step = (float)(Math.PI * 8 / 23) * 2; // 144 deg
                float alpha = i * step;
                starPoints.Add(new PointF(
                    r * (float)Math.Cos(alpha + rotation) 
                    + m.position.X,
                    r * (float)Math.Sin(alpha + rotation) 
                    + m.position.Y
                    )
                    
                    );

            }
            g.DrawPolygon(p,
                starPoints.ToArray());
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (m.vy == 0)
            {
                if (e.KeyCode == Keys.Up)
                {
                    m.vy = -10;
                }
                if (e.KeyCode == Keys.Down)
                {
                    m.vy = 10;
                }
            }

            if (m.vx == 0)
            {
                if (e.KeyCode == Keys.Left)
                {
                    m.vx = -10;
                }
                if (e.KeyCode == Keys.Right)
                {
                    m.vx = 10;
                }
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
            {
                m.vy = 0;
            }
            if ((e.KeyCode == Keys.Left) || (e.KeyCode == Keys.Right))
            {
                m.vx = 0;
            }

        }
    }
}
