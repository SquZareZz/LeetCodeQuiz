using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class SelfDividingNumbers
    {
        public IList<int> SelfDividingNumbers1(int left, int right)
        {
            var Result = new List<int>();
            bool AddCheck = true;
            for (int i = left; i < right + 1; i++)
            {
                foreach (char c in i.ToString())
                {
                    if (c == '0' || i % (c - '0') != 0)//0不能作為因數/CHAR-'0'為數字
                    {
                        AddCheck = false;
                    }
                }
                if (AddCheck)
                {
                    Result.Add(i);
                }
                AddCheck = true;
            }
            return Result;
        }
    }
}
