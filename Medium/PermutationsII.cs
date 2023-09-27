using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class PermutationsII
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            var Result = new List<IList<int>>();
            permuteDFS(nums.ToList(), 0, Result);

            return Result;
        }
        void permuteDFSSlowly(List<int> num, int start, List<IList<int>> res)
        {
            if (start >= num.Count() && !res.Any(x => x.SequenceEqual(num)))
            {
                res.Add(num.ToArray());
            }
            for (int i = start; i < num.Count(); i++)
            {
                //邏輯：直到遍歷到最後前，都重新CALL一次交換式
                //如果遍歷到最後時，將當前的Nums加入結果
                //只考慮後一數的交換，所以不會重複，所以最後一數只跟自己交換，第一輪的FOR迴圈不起變化
                //一次換兩個數 2->2;1->2、1->1;0->1、0->2、0->0 => 一次換三個數
                //從交換最多數字做到交換最少數字
                (num[start], num[i]) = (num[i], num[start]);//把數字換過去
                //Console.Write("Before i=" + i + ", " + "Start=" + start + "\n");
                //Console.Write("Start permuteDFS\n");
                permuteDFSSlowly(num, start + 1, res);
                (num[start], num[i]) = (num[i], num[start]);//把數字換回來
                //Console.Write("After i=" + i + ", " + "Start=" + start + "\n");
                //Console.Write("Quit permuteDFS\n");
            }
        }
        void permuteDFS(List<int> num, int start, List<IList<int>> res)
        {
            if (start >= num.Count())
            {
                res.Add(num.ToArray());
            }
            for (int i = start; i < num.Count(); i++)
            {
                //邏輯：直到遍歷到最後前，都重新CALL一次交換式
                //如果遍歷到最後時，將當前的Nums加入結果
                //只考慮後一數的交換，所以不會重複，所以最後一數只跟自己交換，第一輪的FOR迴圈不起變化
                //一次換兩個數 2->2;1->2、1->1;0->1、0->2、0->0 => 一次換三個數
                //從交換最多數字做到交換最少數字
                int j = i - 1;
                //幾種狀況：
                //1.i和Start重疊：繼續跑，不影響，因為沒交換
                //2.i在Start前面，且num[i]!=num[j](因為已經交換過了，所以不等於)，接著往下檢查，如果j的位置在start後面，跳過
                //3.i在Start後面，那j必定不大於start，且在它後兩位，跳過
                while (j >= start && num[j] != num[i])
                {
                    j--;
                }
                if (j != start - 1)
                {
                    continue;
                }
                (num[i], num[start]) = (num[start], num[i]);//把數字換過去
                Console.Write("Before i=" + i + ", " + "Start=" + start + "\n");
                Console.Write("Start permuteDFS\n");
                permuteDFS(num, start + 1, res);
                (num[i], num[start]) = (num[start], num[i]);//把數字換回來
                Console.Write("After i=" + i + ", " + "Start=" + start + "\n");
                Console.Write("Quit permuteDFS\n");
            }
        }
    }
}
