using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameModel
    {
        /*
         * 2 игроку по очереди делают ходы
         * используют х или о
         * первый ходит х
         * поле поле 9 клеток
         * побеждает 3 фигуры в ряд
         * ничья когда все поля заняты и нет победы
         * нельзя ходить в занятую клетку
         */

        public enum Side
        {
            x,
            o,
            none
        }

        public delegate void UpdateViewDelegate(GameModel model);

        public event UpdateViewDelegate UpdateView;

        public Side CurrentTurn { get; private set; }
        public Side[,] Field { get; private set; }
        public bool GameOver { get; private set; }
        public Side Winner { get; private set; }
        public int TurnCount{ get; private set; }

        public GameModel()
        {
            TurnCount = 0;
            CurrentTurn = Side.x;
            Field = new Side[3,3];
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    Field[i, j] = Side.none;
                }
            }
            if (UpdateView != null)
                UpdateView(this);
        }

        public void MakeMove(int i, int j, Side side)
        {
            if (side != CurrentTurn)
            {
                throw new Exception("Not your move");
            }
            if (Field[i, j] != Side.none)
            {
                throw new Exception("Cell not empty");
            }
            if (i < 0 || i > 2 || j < 0 || j > 2)
            {
                throw new Exception("Field index out of range");
            }
            if (GameOver)
            {
                throw new Exception("Game is over");
            }
            Field[i, j] = side;
            TurnCount++;

            this.CheckGameOver();
            CurrentTurn = (CurrentTurn == Side.x) ? Side.o : Side.x;
            if (UpdateView != null)
                UpdateView(this);
        }

        private void CheckGameOver()
        {
            if (TurnCount < 5)
            {
                return;
            }
            throw new NotImplementedException();
        }
    }
}
