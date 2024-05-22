using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ExistenceOfASubstringInAStringAndItsReverse
    {
        public bool IsSubstringPresent(string s)
        {
            //用動態規劃來解決，第一個維度放第一個字串、第二個維度放第二個字串
            var RevS = String.Join("", s.Reverse());
            int[,] DP = new int[s.Length + 1, RevS.Length + 1];
            int maxLength = 0;

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= RevS.Length; j++)
                {
                    //如果相等時，計算最大長度
                    if (s[i - 1] == RevS[j - 1])
                    {
                        //DP[字串一座標 , 字串二座標]唯一值更新
                        //其長度會是前一項字母(DP[i-1 , j-1])值 +1
                        //所以 DP 的座標是對應實際的位置，邊緣(i==0, j==0) 都是沒有值的，類似於 KMP 演算法
                        DP[i, j] = DP[i - 1, j - 1] + 1;
                        if (DP[i, j] > maxLength)
                        {
                            maxLength = DP[i, j];
                        }
                    }
                    else
                    {
                        DP[i, j] = 0;
                    }
                }
            }
            return maxLength > 1;
        }
        public bool IsSubstringPresent2(string s)
        {
            //用動態規劃來解決，第一個維度放第一個字串、第二個維度放第二個字串
            var Len = s.Length;
            int[,] DP = new int[Len + 1, Len + 1];
            int maxLength = 0;

            for (int i = 1; i <= Len; i++)
            {
                //如果相等時，計算最大長度
                //第一個字對到最後一個字
                //相反的字串 = 倒著算
                for (int j = 1; j <= Len; j++)
                {
                    if (s[i - 1] == s[Len - j])
                    {
                        //DP[字串一座標 , 字串二座標] 唯一值更新
                        //其長度會是前一項字母(DP[i-1 , j-1])值 +1
                        //所以 DP 的座標是對應實際的位置，邊緣(i==0, j==0) 都是沒有值的，類似於 KMP 演算法
                        DP[i, Len - j] = DP[i - 1, Len - j + 1] + 1;
                        maxLength = Math.Max(maxLength, DP[i, Len - j]);
                    }
                    else
                    {
                        DP[i, Len - j] = 0;
                    }
                }
            }
            return maxLength > 1;
        }
    }
}
