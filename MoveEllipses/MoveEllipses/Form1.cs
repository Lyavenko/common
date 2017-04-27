﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        public void DrawEllipse(Ellipse el)
        {
            Pen p = new Pen(Color.Black);
            Graphics g = workspace.CreateGraphics();
            g.DrawEllipse(p,
                el.position.X - el.rx,
                el.position.Y - el.ry,
                el.position.X + el.rx,
                el.position.Y + el.ry
                );
        }

        private void workspace_Paint(object sender, PaintEventArgs e)
        {
            foreach (Shape s in m.shapes)
            {
                s.Paint();
            }
        }

        private void workspace_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (Shape s in m.shapes)
            {
                if (s.isInside(e.Location))
                {
                    this.Text = "выбран " + s.ToString();
                }
            }
        }
    }
}