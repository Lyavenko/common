using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private Button[,] fieldButtons;
        private GameModel model;

        private Dictionary<GameModel.Side, Image> symbols = new Dictionary<GameModel.Side, Image>();

        public Form1()
        {
            InitializeComponent();

            model = new GameModel();

            model.UpdateView += model_UpdateView;

            symbols[GameModel.Side.x] = Image.FromFile("..\\..\\x.jpg");
            symbols[GameModel.Side.o] = Image.FromFile("..\\..\\0.jpg");
            symbols[GameModel.Side.none] = Image.FromFile("..\\..\\none.jpg");

            fieldButtons = new Button[3,3];
            for (int i = 0; i < fieldButtons.GetLength(0); i++)
            {
                for (int j = 0; j < fieldButtons.GetLength(1); j++)
                {
                    Button b = new Button();
                    b.Size = new Size(50,50);
                    b.Tag = new Point(i,j);
                    b.Top = j * 55 + 20;
                    b.Left = i * 55 + 20;
                    b.Click += b_Click;
                    b.Image = Image.FromFile("..\\..\\none.jpg");
                    this.Controls.Add(b);
                    fieldButtons[i, j] = b;
                }
            }

        }


        void model_UpdateView(GameModel model)
        {
            for (int i = 0; i < fieldButtons.GetLength(0); i++)
            {
                for (int j = 0; j < fieldButtons.GetLength(1); j++)
                {
                    fieldButtons[i, j].Image = symbols[model.Field[i, j]];
                }
            }
            drawVictoryLine(); // зачеркивает крестики (нолики) победителя
            toolStripStatusLabel1.Text = "Ходят " + symbols[model.CurrentTurn];
        }

        void b_Click(object sender, EventArgs e)
        {
            Button b = (Button) sender;
            Point p = (Point) b.Tag;
            model.MakeMove(p.X,p.Y,model.CurrentTurn);
        }
        public void drawVictoryLine()
        {
            if (model.GameOverResult == 0)
            {
                MessageBox.Show("Ничья!");
            }
            if (model.GameOverResult == 4 || model.GameOverResult == 5 || model.GameOverResult == 6)
            {
                Button b = new Button();
                b.Size = new Size(7, 156);
                b.BackColor = Color.Transparent;
                this.Controls.Add(b);
                b.BringToFront();
                b.Enabled = false;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                if (model.GameOverResult == 4)
                {
                    b.BackColor = Color.Black;
                    b.Top = 22;
                    b.Left = 42;
                }
                if (model.GameOverResult == 5)
                {
                    b.BackColor = Color.Black;
                    b.Top = 22;
                    b.Left = 42 + 55;
                }
                if (model.GameOverResult == 6)
                {
                    b.BackColor = Color.Black;
                    b.Top = 22;
                    b.Left = 42 + 55 + 55;
                }
            }
            if (model.GameOverResult == 1 || model.GameOverResult == 2 || model.GameOverResult == 3)
            {
                Button b = new Button();
                b.Size = new Size(156, 7);
                b.BackColor = Color.Transparent;
                this.Controls.Add(b);
                b.BringToFront();
                b.Enabled = false;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                if (model.GameOverResult == 1)
                {
                    b.BackColor = Color.Black;
                    b.Top = 42;
                    b.Left = 22;
                }
                if (model.GameOverResult == 2)
                {
                    b.BackColor = Color.Black;
                    b.Top = 42 + 55;
                    b.Left = 22;
                }
                if (model.GameOverResult == 3)
                {
                    b.BackColor = Color.Black;
                    b.Top = 42 + 55 + 55;
                    b.Left = 22;
                }
            }
            if (model.GameOverResult == 7 || model.GameOverResult == 8)
            {
                Button b = new Button();
                b.Size = new Size(47, 7);
                b.BackColor = Color.Transparent;
                this.Controls.Add(b);
                b.BringToFront();
                b.Enabled = false;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;

                Button a = new Button();
                a.Size = new Size(47, 7);
                a.BackColor = Color.Transparent;
                this.Controls.Add(a);
                a.BringToFront();
                a.Enabled = false;
                a.FlatStyle = FlatStyle.Flat;
                a.FlatAppearance.BorderSize = 0;

                Button c = new Button();
                c.Size = new Size(47, 7);
                c.BackColor = Color.Transparent;
                this.Controls.Add(c);
                c.BringToFront();
                c.Enabled = false;
                c.FlatStyle = FlatStyle.Flat;
                c.FlatAppearance.BorderSize = 0;
                a.BackColor = Color.Black;
                a.Top = 42 + 55;
                a.Left = 22 + 55;
                if (model.GameOverResult == 7)
                {
                    b.BackColor = Color.Black;
                    c.BackColor = Color.Black;

                    b.Top = 42;
                    b.Left = 22;
                    c.Top = 42 + 55 + 55;
                    c.Left = 22 + 55 + 55;
                }
                if (model.GameOverResult == 8)
                {
                    b.BackColor = Color.Black;
                    c.BackColor = Color.Black;
                    b.Top = 42;
                    b.Left = 22 + 55 + 55;
                    c.Top = 42 + 55 + 55;
                    c.Left = 22;
                }

            }
        }

    }
}
