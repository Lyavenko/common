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

        Button VictoryLine = new Button();
        Button DiagonalVictoryLine1 = new Button(); // a
        Button DiagonalVictoryLine2 = new Button(); //c

        private Dictionary<GameModel.Side, Image> symbols = new Dictionary<GameModel.Side, Image>();
        private Dictionary<GameModel.Side, string> symbols1 = new Dictionary<GameModel.Side, string>();

        public Form1()
        {
            InitializeComponent();

            Button start = new Button();
            start.Text = "Новая игра";
            start.Size = new Size(80, 50);
            start.Top = 20;
            start.Left = 200;
            start.Click += start_Click;
            this.Controls.Add(start);

            model = new GameModel();

            symbols[GameModel.Side.x] = Image.FromFile("..\\..\\x.jpg");
            symbols[GameModel.Side.o] = Image.FromFile("..\\..\\0.jpg");
            symbols[GameModel.Side.none] = Image.FromFile("..\\..\\none.jpg");

            symbols1[GameModel.Side.x] = "x";
            symbols1[GameModel.Side.o] = "o";
            symbols1[GameModel.Side.none] = " ";

            model.UpdateView += model_UpdateView;

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
            toolStripStatusLabel1.Text = "Ходят x";
        }

        void start_Click(object sender, EventArgs e)
        {
            GameModel NewGame = new GameModel();
            model = NewGame;
            model_UpdateView(model);
            model.UpdateView += model_UpdateView;
            this.Controls.Remove(DiagonalVictoryLine1);
            this.Controls.Remove(VictoryLine);
            this.Controls.Remove(DiagonalVictoryLine2);

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
            toolStripStatusLabel1.Text = "Ходят " + symbols1[model.CurrentTurn];
        }

        void b_Click(object sender, EventArgs e)
        {
            Button b = (Button) sender;
            Point p = (Point) b.Tag;
            model.MakeMove(p.X,p.Y,model.CurrentTurn);
        }
        public void drawVictoryLine()
        {
            if (model.TurnCount == 9 && model.GameOverResult == 0)
            {
                MessageBox.Show("Ничья!");
            }
            if (model.GameOverResult == 1 || model.GameOverResult == 2 || model.GameOverResult == 3)
            {
                VictoryLine.Size = new Size(7, 156);
                VictoryLine.BackColor = Color.Transparent;
                this.Controls.Add(VictoryLine);
                VictoryLine.BringToFront();
                VictoryLine.Enabled = false;
                VictoryLine.FlatStyle = FlatStyle.Flat;
                VictoryLine.FlatAppearance.BorderSize = 0;
                if (model.GameOverResult == 1)
                {
                    VictoryLine.BackColor = Color.Black;
                    VictoryLine.Top = 22;
                    VictoryLine.Left = 42;
                }
                if (model.GameOverResult == 2)
                {
                    VictoryLine.BackColor = Color.Black;
                    VictoryLine.Top = 22;
                    VictoryLine.Left = 42 + 55;
                }
                if (model.GameOverResult == 3)
                {
                    VictoryLine.BackColor = Color.Black;
                    VictoryLine.Top = 22;
                    VictoryLine.Left = 42 + 55 + 55;
                }
            }
            if (model.GameOverResult == 4 || model.GameOverResult == 5 || model.GameOverResult == 6)
            {
                VictoryLine.Size = new Size(156, 7);
                VictoryLine.BackColor = Color.Transparent;
                this.Controls.Add(VictoryLine);
                VictoryLine.BringToFront();
                VictoryLine.Enabled = false;
                VictoryLine.FlatStyle = FlatStyle.Flat;
                VictoryLine.FlatAppearance.BorderSize = 0;
                if (model.GameOverResult == 4)
                {
                    VictoryLine.BackColor = Color.Black;
                    VictoryLine.Top = 42;
                    VictoryLine.Left = 22;
                }
                if (model.GameOverResult == 5)
                {
                    VictoryLine.BackColor = Color.Black;
                    VictoryLine.Top = 42 + 55;
                    VictoryLine.Left = 22;
                }
                if (model.GameOverResult == 6)
                {
                    VictoryLine.BackColor = Color.Black;
                    VictoryLine.Top = 42 + 55 + 55;
                    VictoryLine.Left = 22;
                }
            }
            if (model.GameOverResult == 7 || model.GameOverResult == 8)
            {
                VictoryLine.Size = new Size(47, 7);
                VictoryLine.BackColor = Color.Transparent;
                this.Controls.Add(VictoryLine);
                VictoryLine.BringToFront();
                VictoryLine.Enabled = false;
                VictoryLine.FlatStyle = FlatStyle.Flat;
                VictoryLine.FlatAppearance.BorderSize = 0;

                DiagonalVictoryLine1.Size = new Size(47, 7);
                DiagonalVictoryLine1.BackColor = Color.Transparent;
                this.Controls.Add(DiagonalVictoryLine1);
                DiagonalVictoryLine1.BringToFront();
                DiagonalVictoryLine1.Enabled = false;
                DiagonalVictoryLine1.FlatStyle = FlatStyle.Flat;
                DiagonalVictoryLine1.FlatAppearance.BorderSize = 0;


                DiagonalVictoryLine2.Size = new Size(47, 7);
                DiagonalVictoryLine2.BackColor = Color.Transparent;
                this.Controls.Add(DiagonalVictoryLine2);
                DiagonalVictoryLine2.BringToFront();
                DiagonalVictoryLine2.Enabled = false;
                DiagonalVictoryLine2.FlatStyle = FlatStyle.Flat;
                DiagonalVictoryLine2.FlatAppearance.BorderSize = 0;
                DiagonalVictoryLine1.BackColor = Color.Black;
                DiagonalVictoryLine1.Top = 42 + 55;
                DiagonalVictoryLine1.Left = 22 + 55;
                if (model.GameOverResult == 7)
                {
                    VictoryLine.BackColor = Color.Black;
                    DiagonalVictoryLine2.BackColor = Color.Black;

                    VictoryLine.Top = 42;
                    VictoryLine.Left = 22;
                    DiagonalVictoryLine2.Top = 42 + 55 + 55;
                    DiagonalVictoryLine2.Left = 22 + 55 + 55;
                }
                if (model.GameOverResult == 8)
                {
                    VictoryLine.BackColor = Color.Black;
                    DiagonalVictoryLine2.BackColor = Color.Black;
                    VictoryLine.Top = 42;
                    VictoryLine.Left = 22 + 55 + 55;
                    DiagonalVictoryLine2.Top = 42 + 55 + 55;
                    DiagonalVictoryLine2.Left = 22;
                }

            }
        }

    }
}
