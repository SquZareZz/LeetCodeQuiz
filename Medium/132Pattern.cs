using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class _132Pattern
    {
        public bool Find132patternFail(int[] nums)
        {
            //BUG
            int Len = nums.Length;
            if (Len < 3)
            {
                return false;
            }
            for (int i = 0; i < Len - 2; i++)
            {
                var ToJudge = new List<int>() { nums[i] };
                if (StepNumFail(ToJudge, i + 1, Len, nums)) return true;
            }
            return false;
        }
        public bool StepNumFail(List<int> _ToJudge, int Start, int Len, int[] nums)
        {
            for (int i = Start; i < Len; i++)
            {
                if (_ToJudge.Count == 3)
                {
                    return _ToJudge[2] > _ToJudge[0] && _ToJudge[1] > _ToJudge[2];
                }
                else
                {
                    var ToJudgeTemp = _ToJudge.ToList();
                    ToJudgeTemp.Add(nums[i]);
                    if (StepNumFail(ToJudgeTemp, i + 1, Len, nums)) return true;
                }
            }
            if (_ToJudge.Count == 3)
            {
                return _ToJudge[2] > _ToJudge[0] && _ToJudge[1] > _ToJudge[2];
            }
            else
            {
                return false;
            }
        }

        public bool Find132patternFail2(int[] nums)
        {
            int Len = nums.Length;
            if (Len < 3)
            {
                return false;
            }
            for (int i = 0; i < Len - 2; i++)
            {
                var ToJudge = new Queue<int>();
                ToJudge.Enqueue(nums[i]);
                if (StepNumFail2(ToJudge, i + 1, Len, nums)) return true;
            }
            return false;
        }
        public bool StepNumFail2(Queue<int> _ToJudge, int Start, int Len, int[] nums)
        {
            for (int i = Start; i < Len; i++)
            {
                if (_ToJudge.Count == 3)
                {
                    int One = _ToJudge.Dequeue(), Two = _ToJudge.Dequeue(), Three = _ToJudge.Dequeue();
                    return Three > One && Two > Three;
                }
                else
                {
                    var ToJudgeTemp = new Queue<int>(_ToJudge.ToArray());
                    ToJudgeTemp.Enqueue(nums[i]);
                    if (StepNumFail2(ToJudgeTemp, i + 1, Len, nums)) return true;
                }
            }
            if (_ToJudge.Count == 3)
            {
                int One = _ToJudge.Dequeue(), Two = _ToJudge.Dequeue(), Three = _ToJudge.Dequeue();
                return Three > One && Two > Three;
            }
            else
            {
                return false;
            }
        }

        public bool Find132patternFail3(int[] nums)
        {
            //最基本的三重迴圈，太慢
            int Len = nums.Length;
            if (Len < 3)
            {
                return false;
            }
            for (int i = 0; i < Len - 2; i++)
            {
                for (int j = i + 2; j < Len; j++)
                {
                    if (nums[j] <= nums[i])
                    {
                        continue;
                    }
                    for (int k = i; k < j; k++)
                    {
                        if (nums[k + 1] > nums[j])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool Find132patternFail4(int[] nums)
        {
            //三重迴圈，太慢
            int Len = nums.Length;
            if (Len < 3)
            {
                return false;
            }
            for (int i = 0; i < Len - 2; i++)
            {
                var Possible = nums.Skip(i + 1).Where(x => x > nums[i]).Distinct().ToArray();
                Array.Sort(Possible);
                for (int k = 0; k < Possible.Length - 1; k++)
                {
                    for (int j = k + 1; j < Possible.Length; j++)
                    {
                        if (Array.LastIndexOf(nums, Possible[k]) > Array.IndexOf(nums, Possible[j]) &&
                            Possible[k] < Possible[j])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool Find132patternFail5(int[] nums)
        {
            //二重還是太慢，它綁定要一重
            int Len = nums.Length;
            if (Len < 3)
            {
                return false;
            }
            int First = Int32.MaxValue;
            for (int i = 0; i < Len; i++)
            {
                First = Math.Min(nums[i], First);
                //如果這個數字是起始最小值，代表當前位置沒找到 Second
                if (nums[i] == First)
                {
                    continue;
                }
                for (int j = Len - 1; j > i; j--)
                {
                    if (nums[j] > First && nums[j] < nums[i])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool Find132pattern(int[] nums)
        {
            int Third = Int32.MinValue;
            var Candidate = new Stack<int>();
            //從最尾端遍歷回去
            for (int i = nums.Length - 1; i > -1; i--)
            {
                if (nums[i] < Third)
                {
                    return true;
                }
                //一開始只有一個數，所以不可能是選項，Candidate還沒被置入
                //第二層也不是選項，如果第二個數比第一個數還大(Third < Second)，
                //那下一輪要判定一次第一個數有沒有比第三個數字大，所以更新 Third 直到滿足 2>3 的條件
                //或是沒有候補項為止
                while (Candidate.Count > 0 && nums[i] > Candidate.Peek())
                {
                    Third = Candidate.Pop();
                }
                Candidate.Push(nums[i]);
            }
            return false;
        }
        public bool Find132pattern2(int[] nums)
        {
            int third = Int32.MinValue;
            var Candidate = new Stack<int>();
            //從最尾端遍歷回去
            foreach(var num in nums.Reverse())
            {
                if (num < third)
                {
                    return true;
                }
                //一開始只有一個數，所以不可能是選項，Candidate還沒被置入
                //第二層也不是選項，如果第二個數比第一個數還大(Third < Second)，
                //那下一輪要判定一次第一個數有沒有比第三個數字大，所以更新 Third 直到滿足 2>3 的條件
                //或是沒有候補項為止
                while (Candidate.Count > 0 && num > Candidate.Peek())
                {
                    third = Candidate.Pop();
                }
                Candidate.Push(num);
            }
            return false;
        }
    }
}
//if (nums[i] < nums[i + 2])
//{
//    int Trird = nums[i + 2];
//    for (int j = i + 2; j < Len; j++)
//    {
//        if (nums[j - 1] > Trird)
//        {
//            return true;
//        }
//    }
//    for (int j = i + 2; j > i; j--)
//    {
//        if (nums[j - 1] > Trird)
//        {
//            return true;
//        }
//    }
//}
//else
//{
//    continue;
//}