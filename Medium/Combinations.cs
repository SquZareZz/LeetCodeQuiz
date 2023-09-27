using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class Combinations
    {
        public IList<IList<int>> CombineFail(int n, int k)
        {
            //一定要用堆疊呼叫，不能用迴圈
            var Result = new List<IList<int>>();
            if (k == 1)
            {
                for (int i = 1; i < n+1; i++) 
                {
                    Result.Add(new List<int> { i });
                }
                return Result;
            }
            for(int i = 1; i < n+1; i++)
            {
                int j = i;
                while (j+k-1<n+1)
                {
                    var temp = new List<int>();
                    temp.Add(i);
                    j++;
                    for (int f=0; f < k-1; f++)
                    {
                        temp.Add(j+f);
                    }
                    Result.Add(temp);
                }
            }
            return Result;
        }
        public IList<IList<int>> Combine(int n, int k)
        {
            //一定要用堆疊呼叫，不能用迴圈
            var Result = new List<IList<int>>();
            CombineLoop(Result,new List<int>(),1,n,k);
            return Result;
        }
        public static void CombineLoop(IList<IList<int>> Result, IList<int>temp,int start,int n,int k)
        {
            if(k==0)
            {
                //要新建物件，不然物件會黏在一起，隨著副函式結束消失
                //當長度<1的時候，代表做完了
                Result.Add(new List<int>(temp));
                return;
            }
            for(int i = start; i <= n; i++)
            {
                temp.Add(i);
                //開始點是當前的下一號，長度也必需少一號，所以k要-1
                CombineLoop(Result, temp, i + 1, n, k - 1);
                //進入下一個迴圈前，把最後一個數字清掉
                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}
