using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ValidPerfectSquare
    {
        public bool IsPerfectSquare(int num)
        {
            var ToDepend = Math.Sqrt(num);
            return int.TryParse(ToDepend.ToString(), out int a);
        }
        public bool IsPerfectSquareSlower(int num)
        {
            var ToDepend = Math.Sqrt(num);
            return ToDepend - Convert.ToInt32(ToDepend) == 0;
        }
    }
}
