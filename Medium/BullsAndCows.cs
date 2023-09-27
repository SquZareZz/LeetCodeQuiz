using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class BullsAndCows
    {
        public string GetHint(string secret, string guess)
        {
            int A_Count = 0;
            int B_Count = 0;
            int[] LostNumA= new int[10];
            int[] LostNumB= new int[10];
            for (int i = 0; i < guess.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    A_Count++;
                }
                else
                {
                    LostNumA[secret[i] - 48]++;
                    LostNumB[guess[i] - 48]++;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                B_Count += Math.Min(LostNumA[i], LostNumB[i]);
            }

            return A_Count + "A" + B_Count + "B";
        }
    }
}
