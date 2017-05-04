using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveEllipses
{
    public partial class Form1 : Form, IShapesPainter
    {
        Model m;
        public Form1()
        {
            InitializeComponent();
            m = new Model(this);
            m.addEllipse(100, 100, 50, 70);
            m.addEllipse(200, 100, 40, 70);
            m.addEllipse(100, 200, 50, 40);
            m.addRectangle(150, 150, 100, 70);
        }

        Pen p = new Pen(Color.Black);
        Brush b = new SolidBrush(Color.LawnGreen);

        public void DrawEllipse(Ellipse el)
        {
            Graphics g = workspace.CreateGraphics();
            g.FillEllipse(b,
                el.position.X - el.rx,
                el.position.Y - el.ry,
                2 * el.rx,
                2 * el.ry
                );
            g.DrawEllipse(p,
                el.position.X - el.rx,
                el.position.Y - el.ry,
                2 * el.rx,
                2 * el.ry
                );
        }

        public void DrawRectangle(Rectangle r)
        {
            Graphics g = workspace.CreateGraphics();
            g.FillRectangle(b,
                r.position.X,
                r.position.Y,
                r.width,
                r.height
                ); 
            g.DrawRectangle(p,
                r.position.X,
                r.position.Y,
                r.width,
                r.height
                );

        }

        private void workspace_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(SystemColors.Control);
            m.Paint();
        }

        private void workspace_MouseDown(object sender, MouseEventArgs e)
        {
            if (m.SelectShape(e.Location.X, e.Location.Y) != null)
            {
                this.Text = "выбран " + m.SelectedShape.ToString();
                prevMouseCoords = e.Location;
            }
            else
            {
                this.Text = "ничего не выбрано";
            }
        
        }
        PointF prevMouseCoords;
        private void workspace_MouseMove(object sender, MouseEventArgs e)
        {
            if ((m.SelectedShape == null) || (e.Button != MouseButtons.Left))
            {
                return;
            }
            float deltax = e.Location.X - prevMouseCoords.X;
            float deltay = e.Location.Y - prevMouseCoords.Y;
            prevMouseCoords = e.Location;
            m.SelectedShape.MoveBy(deltax, deltay);
            workspace.Invalidate();
            this.Update();
        }
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("en");
        }

        private void русскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("ru-RU");
        }


  
        private void ChangeLanguage(string lang)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            foreach (Control c in panel1.Controls)
            {
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (m.SelectedShape != null)
            {
                m.MoveSelectionToFront();
            }
            workspace.Invalidate();
            this.Update();
        }



  
    }
}
