using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class SortAnArray
    {
        public int[] SortArrayBubblle(int[] nums)
        {
            //超過時間
            for(int i = 0; i < nums.Length; i++)
            {
                for(int j=0; j < nums.Length - 1 - i; j++)
                {
                    if (nums[j] > nums[j+1])
                    {
                        (nums[j], nums[j+1]) = (nums[j+1], nums[j]);
                    }
                }
            }
            return nums;
        }
        public int[] SortArray(int[] nums)
        {
            //因為極限是正負五萬
            //所以用一個100001的數列去紀錄，再遍歷每個值
            //數值+50000=被儲存的位置，看這位置有幾個數，沒大於0的跳過
            
            int Len=nums.Length,Count=0;
            int[] result = new int[Len];
            int[] NumCounter = new int[100001];
            foreach (int num in nums)
            {
                NumCounter[num+50000]++;
            }
            for(int i=0;i<NumCounter.Length;i++)
            {
                if (NumCounter[i] > 0)
                {
                    while (NumCounter[i] > 0)
                    {
                        result[Count] = i - 50000;
                        NumCounter[i]--;
                        Count++;
                    }
                    
                }
                if (Count == Len)
                {
                    break;
                }
            }
            return result;
        }
    }
}
