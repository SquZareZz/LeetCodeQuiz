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
    }
}
