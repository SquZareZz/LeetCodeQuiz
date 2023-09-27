using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class MaxConsecutiveOnes
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int MaxCount = 0;
            int temp = 0;
            foreach (var num in nums)
            {
                switch (num)
                {
                    case 1:
                        temp++;
                        break;
                    case 0:
                        if (MaxCount < temp)
                        {
                            MaxCount = temp;
                        }
                        temp = 0;
                        break;
                }
            }
            return MaxCount < temp ? temp : MaxCount;
        }
    }
}
