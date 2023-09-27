using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class CircularArrayLoop
    {
        public bool CircularArrayLoop1(int[] nums)
        {
            int Len = nums.Length;
            var Visited = new bool[Len];
            for (int Current = 0; Current < Len; Current++)
            {
                if (Visited[Current]) continue;
                Visited[Current] = true;
                var RouteDict = new Dictionary<int, int>();
                while (true)
                {
                    //正號不影響，負號的時候換成正的位置
                    int Next = ((Current + nums[Current]) % Len + Len) % Len;
                    //移動只會遵循一個方向(全往左或全往右)，因此相乘為負不繼續做
                    //前後跳不行，但畫一個圈可以
                    if (Next == Current || nums[Next] * nums[Current] < 0) break;
                    //確認是否進入循環
                    if (RouteDict.ContainsKey(Next)) return true;
                    RouteDict.Add(Current,Next);
                    Current = Next;
                    Visited[Next] = true;
                }
            }
            return false;
        }
    }
}
