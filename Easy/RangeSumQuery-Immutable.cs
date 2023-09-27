using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class NumArray
    {
        private int[] _nums;
        private int[] _cachesum;

        public NumArray(int[] nums)
        {
            _nums = nums;
            _cachesum = new int[nums.Length];
            int s = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                s += nums[i];
                _cachesum[i] = s;
            }
        }

        public int SumRangeFastest(int left, int right)
        {
            if (_nums == null || _nums.Length == 0)
            {
                return 0;
            }
            if (left < 0 || right > _nums.Length - 1)
            {
                return 0;
            }
            return _cachesum[right] - _cachesum[left] + _nums[left];
        }


        public int SumRangeLessMemory(int left, int right)
        {
            int ReturnValue = 0;
            if (_nums == null || _nums.Length == 0)
            {
                return 0;
            }
            if (left < 0 || right > _nums.Length - 1)
            {
                return 0;
            }
            for (int i = left; i < right + 1; i++)
            {
                ReturnValue += _nums[i];
            }
            return ReturnValue;
        }
    }
}
