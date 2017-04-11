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

            symbols[GameModel.Side.x] = Image.FromFile("C:\\Users\\st\\Documents\\Visual Studio 2013\\common\\common\\TicTacToe\\TicTacToe\\x.jpg");
            symbols[GameModel.Side.o] = Image.FromFile("C:\\Users\\st\\Documents\\Visual Studio 2013\\common\\common\\TicTacToe\\TicTacToe\\0.jpg");
            symbols[GameModel.Side.none] = Image.FromFile("C:\\Users\\st\\Documents\\Visual Studio 2013\\common\\common\\TicTacToe\\TicTacToe\\none.jpg");

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
                    b.Image = Image.FromFile("C:\\Users\\st\\Documents\\Visual Studio 2013\\common\\common\\TicTacToe\\TicTacToe\\none.jpg");
                   // b.Image = Image.FromFile("C:\\Users\\st\\Documents\\Visual Studio 2013\\common\\common\\TicTacToe\\TicTacToe\\none.jpg");
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
                   // fieldButtons[i, j].Image = Image.FromFile("C:\\Users\\st\\Documents\\Visual Studio 2013\\common\\common\\TicTacToe\\TicTacToe\\x.jpg");
                }
            }
            toolStripStatusLabel1.Text = "Ходят " + symbols[model.CurrentTurn];
        }

        void b_Click(object sender, EventArgs e)
        {
            Button b = (Button) sender;
            Point p = (Point) b.Tag;
            model.MakeMove(p.X,p.Y,model.CurrentTurn);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }
    }
}
