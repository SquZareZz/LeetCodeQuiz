using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class MaximumNumberOfOperationsWithTheSameScoreI
    {
        public int MaxOperations(int[] nums)
        {
            int count = 0, Len = nums.Length;
            int pointer = 0, temp = 0;
            var Tar = new HashSet<int>();
            for (int i = 0; i < Len; i++)
            {
                if (pointer < 2)
                {
                    temp += nums[i];
                }
                else
                {
                    if (Tar.Count == 0)
                    {
                        Tar.Add(temp);
                        temp = nums[i];
                        pointer = 0;
                        count++;
                    }
                    else
                    {
                        if (!Tar.Contains(temp))
                        {
                            break;
                        }
                        else
                        {
                            temp = nums[i];
                            pointer = 0;
                            count++;
                        }
                    }
                }
                pointer++;
            }
            if (Len % 2 == 0)
            {
                if (Tar.Contains(temp) || Tar.Count == 0)
                {
                    return count + 1;
                }
                else
                {
                    return count;
                }
            }
            else
            {
                return count;
            }
        }
    }
}
