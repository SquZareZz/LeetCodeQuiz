using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class RemoveElement
    {
        public int RemoveElement1(int[] nums, int val)
        {
            int TotalLen = nums.Length;
            int FindValueCount = 0;
            int ValueLeftCount = 0;
            if (TotalLen > 0)
            {
                for (int i = 0; i < TotalLen; i++)
                {
                    if (nums[i] == val)
                    {
                        ValueLeftCount++;
                        FindValueCount++;
                        while (ValueLeftCount + i < TotalLen)
                        {
                            if (nums[i + ValueLeftCount] == val)
                            {
                                ValueLeftCount++;
                                FindValueCount++;
                            }
                            else
                            {
                                for (int j = i; j < TotalLen - ValueLeftCount; j++)
                                {
                                    nums[j] = nums[j + ValueLeftCount];
                                }
                                break;
                            }
                        }
                        if (TotalLen > ValueLeftCount && ValueLeftCount > 0)
                        {
                            for (int j = TotalLen - ValueLeftCount; j < TotalLen; j++)
                            {
                                nums[j] = nums[0];
                            }
                        }
                        else if (ValueLeftCount >= TotalLen)
                        {
                            nums = null;
                            return 0;
                        }
                        ValueLeftCount = 0;
                    }
                }
                if (TotalLen > FindValueCount && FindValueCount > 0)
                {
                    int[] nums2 = new int[TotalLen - FindValueCount];
                    for (int j = 0; j < TotalLen - FindValueCount; j++)
                    {
                        nums2[j] = nums[j];
                    }
                    nums = nums2;
                }
                return TotalLen - FindValueCount;
            }
            return 0;
        }
        public int RemoveElement2(int[] nums, int val)
        {
            int valCount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[valCount++] = nums[i];//在這裡寫++會在處理完後才++
                    //valCount++;
                }
            }
            return valCount;
        }

    }
}
