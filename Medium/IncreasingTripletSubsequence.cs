using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class IncreasingTripletSubsequence
    {
        public bool IncreasingTriplet(int[] nums)
        {
            int[] Target = HashTrans(nums);
            for (int j = 0; j < Target.Length - 2; j++)
            {
                //當這個數已經是最大時，直接跳過後續處理
                if (Target.Skip(j + 1).Max() <= Target[j])
                {
                    continue;
                }
                for (int i = j + 1; i < Target.Length - 1; i++)
                {
                    //避免重複項
                    var CheckList = new bool[Target.Length];
                    if (HigherOrNot(Target, i, i + 1, j, CheckList))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool HigherOrNot(int[] nums, int Left, int Right, int FirstIndex, bool[] CheckList)
        {
            for (int i = Right; i < nums.Length - 1; i++)
            {
                if (CheckList[i])
                {
                    break;
                }
                if (HigherOrNot(nums, Left, i + 1, FirstIndex, CheckList))
                {
                    return true;
                }
            }
            CheckList[Right] = true;
            return nums[FirstIndex] < nums[Left] && nums[Left] < nums[Right];
        }
        public int[] HashTrans(int[] nums)
        {
            //避免重複過多無意義的數字
            if (nums.Length < 3)
            {
                return nums;
            }
            var HashTrans = new List<int>() { nums[0] };
            var HashTrans2 = new List<int>() { nums[0], nums[1] };
            int temp = nums[0];
            int Target = 0;
            foreach (int n in nums.Skip(1))
            {
                if (n == temp)
                {
                    continue;
                }
                else
                {
                    HashTrans.Add(n);
                    temp = n;
                }
            }
            for(int i = 2; i < nums.Length-1; i += 2)
            {
                if (nums[i] == HashTrans2[Target] && nums[i+1]== HashTrans2[Target + 1])
                {
                    continue;
                }
                else
                {
                    HashTrans2.Add(nums[i]);
                    HashTrans2.Add(nums[i+1]);
                    Target += 2;
                }
            }
            if (nums.Length % 2 == 1)
            {
                HashTrans2.Add(nums.Last());
            }
            return HashTrans2.Count < HashTrans.Count ? HashTrans2.ToArray() : HashTrans.ToArray();
        }
    }
}
