using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class N_thTribonacciNumber
    {
        public int Tribonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else if (n == 2)
            {
                return 1;
            }
            else
            {
                //會有n-1組答案
                var CandidateAnswer = new int[n + 1];
                CandidateAnswer[0] = 0;
                CandidateAnswer[1] = 1;
                CandidateAnswer[2] = 1;
                CandidateAnswer[3] = 2;
                for (int i = 4; i < n + 1; i++)
                {
                    CandidateAnswer[i] = 2 * CandidateAnswer[i - 1] - CandidateAnswer[i - 4];
                }
                return CandidateAnswer[n];
            }
        }
        public int Tribonacci2(int n)
        {
            var DP = new int[n + 1];
            for (int i = 0; i <= n; i++)
            {
                if (i == 0)
                {
                    DP[i] = 0;
                }
                else if (i == 1)
                {
                    DP[i] = 1;
                }
                else if (i == 2)
                {
                    DP[i] = 1;
                }
                else
                {
                    DP[i] = DP[i - 1] + DP[i - 2] + DP[i - 3];
                }
            }
            return DP[n];
        }
    }
}
