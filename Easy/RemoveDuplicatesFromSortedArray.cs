using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class RemoveDuplicatesFromSortedArray
    {
        public int RemoveDuplicatesFail(int[] nums)
        {
            int TarLength = nums.Length;
            if (TarLength > 1)
            {
                int NonDuplicate = nums[0];
                int MaxInArray = nums[0];
                int DuplicateCount = 0;
                for (int i = 1; i < TarLength; i++)
                {
                    if (nums[i] == nums[i - 1])//
                    {
                        DuplicateCount += 1;
                        if (i == TarLength - 1)
                        {
                            return i + 1 - DuplicateCount;
                        }
                    }
                    else if (MaxInArray == nums.Max())
                    {
                        if (DuplicateCount == 0)
                        {
                            return i;
                        }
                        else if (DuplicateCount + 2 == TarLength)
                        {
                            return 1;
                        }
                    }
                    else
                    {
                        if (nums[i] > MaxInArray)
                        {
                            if (nums[i] == nums.Max() && DuplicateCount == 0)
                            {
                                return i + 1;
                            }
                            MaxInArray = nums[i];
                            nums[i - DuplicateCount] = MaxInArray;
                            i -= DuplicateCount;
                            DuplicateCount = 0;
                        }
                        else
                        {
                            nums[i] = MaxInArray;
                            DuplicateCount += 1;
                        }
                    }
                }
                return 0;
            }
            else if (TarLength == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int RemoveDuplicatesFail2(int[] nums)
        {
            int TarLength = nums.Length;
            //int NonDuplicateFirstVal = nums[0];
            //int DuplicateCount = 0;
            int NonDuplicate = 1;
            int[] numsToken = new int[TarLength];
            numsToken[0] = nums[0];
            bool CheckInput = false;
            if (TarLength > 1)
            {
                for (int i = 1; i < TarLength; i++)
                {
                    for (int j = 1; j < NonDuplicate + 1; j++)
                    {
                        if (nums[i] != numsToken[j - 1])
                        {
                            CheckInput = true;
                        }
                        else
                        {
                            CheckInput = false;
                        }
                    }
                    if (CheckInput == true)
                    {
                        numsToken[i - 1] = nums[i];
                        NonDuplicate++;
                    }
                }
                nums = numsToken;
                return NonDuplicate;
            }
            else if (TarLength == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int RemoveDuplicatesLastTime(int[] nums)
        {
            int NonDuplicateCount = 0;
            if (nums.Length > 0)
            {
                Stack<int> NonDuplicate = new Stack<int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (!NonDuplicate.Contains(nums[i]))
                    {
                        NonDuplicate.Push(nums[i]);
                        NonDuplicateCount++;
                    }
                }
                for (int i = NonDuplicateCount; i > 0; i--)
                {
                    nums[i - 1] = NonDuplicate.Pop();
                }
                return NonDuplicateCount;
            }
            else
            {
                return 0;
            }
        }
        public int RemoveDuplicatesLastMemory(int[] nums)
        {
            int Size = nums.Length;
            int NonDuplicateCount = 0;
            if (Size > 0)
            {
                Stack<int> NonDuplicate = new Stack<int>();
                for (int i = 0; i < Size; i++)
                {
                    if (!NonDuplicate.Contains(nums[i]))
                    {
                        NonDuplicate.Push(nums[i]);
                        NonDuplicateCount++;
                    }
                }
                for (int i = NonDuplicateCount; i > 0; i--)
                {
                    nums[i - 1] = NonDuplicate.Pop();
                }
                return NonDuplicateCount;
            }
            else
            {
                return 0;
            }
        }
    }
}
