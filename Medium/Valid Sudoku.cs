using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class Valid_Sudoku
    {
        //三段式檢查=>九宮格、橫邊、直邊
        //用字典檢查重複，能重複的只有空格
        public bool IsValidSudoku(char[][] board)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (!IsValidGrid(board, i * 3, j * 3))
                    {
                        return false;
                    }
                }
            }
            //if ( !IsValidRow(board) || !IsValidCol(board))
            //{
            //    return false;
            //}
            if (!IsValidRowEnumerableWay(board) || !IsValidCol(board))
            {
                return false;
            }
            return true;
        }
        public bool IsValidGrid(char[][] board, int k, int h)
        {
            var DictBoard = new Dictionary<char, int>();
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (!DictBoard.ContainsKey(board[k + j][h + i]))
                    {
                        DictBoard.Add(board[k + j][h + i], 1);
                    }
                    else
                    {
                        if (board[k + j][h + i] != '.')
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        public bool IsValidRow(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                var DictBoard = new Dictionary<char, int>();
                foreach (char c in board[i])
                {
                    if (!DictBoard.ContainsKey(c))
                    {
                        DictBoard.Add(c, 1);
                    }
                    else
                    {
                        if (c != '.')
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        public bool IsValidRowEnumerableWay(char[][] board)
        {
            foreach (var board2 in board)
            {
                if (board2.Length != board2.Distinct().Count() + board2.Where(x => x == '.').Count() - 1)
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsValidCol(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                var DictBoard = new Dictionary<char, int>();
                for (int j = 0; j < 9; j++)
                {
                    if (!DictBoard.ContainsKey(board[j][i]))
                    {
                        DictBoard.Add(board[j][i], 1);
                    }
                    else
                    {
                        if (board[j][i] != '.')
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
