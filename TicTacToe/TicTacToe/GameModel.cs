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
            x = 0,
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
        // добавила поле, которое будет принимать значение от 1 до 8, если произошел GameOver и есть победитель, 
        // т.е. будет определять одну из 8 возможных комбинаций выигрыша
        // переменная изначально инициализируется 0 и это значение остается, если произошла ничья
        //0 - изначальная инициализация и ничья
        //1 - совпадение верхнего ряда
        //2 - соврадение среднего ряда
        //3 - совпадение нижнего ряда
        //4 - совпадение левого столбца
        //5 - совпадение среднего столбца
        //6 - совпадение правого столбца
        //7 - совпадение диагонали левый верх - правый низ
        //8 - совпадение диагонали правый верх - левый  низ

        public int GameOverResult { get; private set; }

        public int GameOverResult = 0;

        public GameModel()
        {
            GameOverResult = 0;
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

        public void CheckGameOver()
        {
            if (TurnCount < 5)
            {
                return;
            }
            // 1
            if (Field[0, 0] == Field[0, 1] && Field[0, 0] == Field[0, 2] && Field[0, 0] != Side.none)
            {
                GameOver = true;
                Winner = CurrentTurn;
                GameOverResult = 1;
            }
            // 2
            else if (Field[1, 0] == Field[1, 1] && Field[1, 0] == Field[1, 2] && Field[1, 0] != Side.none)
            {
                GameOver = true;
                Winner = CurrentTurn;
                GameOverResult = 2;
            }
            // 3
            else if (Field[2, 0] == Field[2, 1] && Field[2, 0] == Field[2, 2] && Field[2, 0] != Side.none)
            {
                GameOver = true;
                Winner = CurrentTurn;
                GameOverResult = 3;
            }
            //4
            else if (Field[0, 0] == Field[1, 0] && Field[0, 0] == Field[2, 0] && Field[0, 0] != Side.none)
            {
                GameOver = true;
                Winner = CurrentTurn;
                GameOverResult = 4;
            }
            // 5
            else if (Field[0, 1] == Field[1, 1] && Field[0, 1] == Field[2, 1] && Field[0, 1] != Side.none)
            {
                GameOver = true;
                Winner = CurrentTurn;
                GameOverResult = 5;
            }
            // 6
            else if (Field[0, 2] == Field[1, 2] && Field[0, 2] == Field[2, 2] && Field[0, 2] != Side.none)
            {
                GameOver = true;
                Winner = CurrentTurn;
                GameOverResult = 6;
            }
            // 7
            else if (Field[0, 0] == Field[1, 1] && Field[0, 0] == Field[2, 2] && Field[0, 0] != Side.none)
            {
                GameOver = true;
                Winner = CurrentTurn;
                GameOverResult = 7;
            }
            // 8
            else if (Field[0, 2] == Field[1, 1] && Field[0, 2] == Field[2, 0] && Field[0, 2] != Side.none)
            {
                GameOver = true;
                Winner = CurrentTurn;
                GameOverResult = 8;
            }
            // ничья
            if (TurnCount == 9 && GameOverResult == 0)
            {
                GameOver = true;
                Winner = Side.none;
            }
        }

        
    }
}
