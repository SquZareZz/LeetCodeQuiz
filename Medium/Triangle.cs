using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class Triangle
    {
        public int MinimumTotalFail(IList<IList<int>> triangle)
        {
            //沒考慮全部可能
            int Res = triangle.First().First();
            int index = 0;
            foreach (var numList in triangle.Skip(1))
            {
                Res += numList[index] < numList[index + 1] ? numList[index] : numList[index + 1];
                index = numList[index] < numList[index + 1] ? index : index + 1;
            }
            return Res;
        }
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            var Result = new List<int>(triangle[triangle.Count() - 1]);
            //由後往前動態分析
            //最後一層第一數跟第二數比，小的勝出，以此類推掃過全部，總共會有尾項-1組答案
            //以此類推倒數第二層跟上一段落的答案，第一數和第二數比，小的勝出
            //最後只會改變到 Result[0]，即為答案
            for (int j = triangle.Count - 2; j > -1; j--)
            {
                for (int i = 0; i < j + 1; i++)
                {
                    Result[i] = Math.Min(Result[i], Result[i + 1]) + triangle[j][i];

                }
            }
            //如果是由前往後的話，最後必須多一個「最尾項誰最小」
            return Result[0];
        }
        public int MinimumTotal2(IList<IList<int>> triangle)
        {
            for (int i = 1; i < triangle.Count; i++)
            {
                for (int j = 0; j < triangle[i].Count; j++)
                {
                    //不直接修改，就要改成新參數跟進累加
                    //直接修改下一項，使得下次運算可以延續上一輪的運算結果
                    if (j == 0)
                    {
                        triangle[i][j] += triangle[i - 1][j];
                    }
                    else if (j == triangle[i].Count() - 1)
                    {
                        triangle[i][j] += triangle[i - 1][j - 1];
                    }
                    else
                    {
                        triangle[i][j] += Math.Min(triangle[i - 1][j - 1], triangle[i - 1][j]);
                    }
                }
            }
            //判斷點在「最尾項誰最小」
            return triangle.Last().Min();
        }
    }
}
