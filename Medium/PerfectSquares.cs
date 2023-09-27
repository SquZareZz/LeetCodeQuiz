using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class PerfectSquares
    {
        public int NumSquaresFail(int n)
        {
            //Fail原因：可能爆炸、沒有用動態規劃
            var Result = new List<int>();  
            int Possible = (int)Math.Sqrt(n) + 1;
            while (n > 0)
            {
                int Target = (int)Math.Pow(Possible, 2);
                if (Target > n)
                {
                    Possible--;
                }
                else
                {
                    Result.Add(Possible);
                    n -= Target;
                }
            }
            return Result.Count;
        }
        public int NumSquares(int n)
        {
            var Candidate = new int[n+1];
            for(int i = 1; i < n+1; i++)
            {
                Candidate[i] = i;
                //如果該數就是完全平方，那該數會=Candidate[0]+1 ex:1、4、9
                for(int j = 1; i >= j * j; j++)
                {                    
                    Candidate[i] = Math.Min(Candidate[i], Candidate[i - j * j] + 1);
                }
            }
            return Candidate[n];
        }
    }
}
