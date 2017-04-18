using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordOrder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private  List<Label> labels = new List<Label>();

        private Point MouseCoordinates;
        private Point LableCoordinates;
        private Label RememberedLabel;

        private void Form1_Load(object sender, EventArgs e)
        {
            Model.Task task = Model.MakeTask();
            int left = 20;
            foreach (string word in task.ShuffledSentence)
            {
                Label l = new Label();
                l.Text = word;
                l.AutoSize = true;
                l.Left = left;
                l.Font = new Font("Arial", 24, FontStyle.Regular);
                this.Controls.Add(l);
                left += l.Width;
                l.MouseDown += l_MouseDown;
                l.MouseUp += l_MouseUp;
                l.MouseMove +=l_MouseMove;
                labels.Add(l);
            }
        }


        void l_MouseUp(object sender, MouseEventArgs e)
        {
            if (RememberedLabel != null)
            {
                RememberedLabel = null;

                labels.Sort(labelByLeftComparer);

                string text = "";
                foreach (var l in labels)
                {
                    text += l.Text+' ';
                }
                MessageBox.Show(text);
            }

        }

        private static int labelByLeftComparer(Label a, Label b)
        {
            if (b.Left > a.Left)
            {
                return -1;
            }
            else if (b.Left < a.Left)
            {
                return +1;
            }
            else
            {
                return 0;
            }
        }


        void l_MouseMove(object sender, MouseEventArgs e)
        {
            if (RememberedLabel != null)
            {
                RememberedLabel.Left = RememberedLabel.Left + e.X - MouseCoordinates.X;
                RememberedLabel.Top = RememberedLabel.Top + e.Y - MouseCoordinates.Y;
                this.Update();
            }
        }

        void l_MouseDown(object sender, MouseEventArgs e)
        {
            if (RememberedLabel == null)
            {
                 MouseCoordinates = new Point(e.X, e.Y);
                 RememberedLabel = (Label)sender;
                 LableCoordinates = RememberedLabel.Location;
            }
  
        }
    }
}
