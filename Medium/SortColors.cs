using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class SortColors
    {
        public void SortColors1(int[] nums)
        {
            var DictNums=new Dictionary<int,int>();
            int j = 0;
            foreach(int i in nums)
            {
                if (!DictNums.ContainsKey(i))
                {
                    DictNums.Add(i,1);
                }
                else
                {
                    DictNums[i]++;
                }
            }
            for(int i = 0; i < 3; i++)
            {
                if (DictNums.ContainsKey(i))
                {
                    while (DictNums[i] > 0) 
                    {
                        nums[j]=i;
                        j++;
                        DictNums[i]--;
                    }
                }
            }
        }
    }
}
