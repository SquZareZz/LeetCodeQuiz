using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class DailyTemperatures
    {
        public int[] DailyTemperaturesFail(int[] temperatures)
        {
            //太久
            for (int i = 0; i < temperatures.Length; i++)
            {
                temperatures[i] = temperatures.Select((value, index) => new { Value = value, Index = index })
                                              .Skip(i + 1)
                                              .FirstOrDefault(item => item.Value > temperatures[i])?.Index - i ?? 0;
            }
            return temperatures;
        }
        public int[] DailyTemperatures1(int[] temperatures)
        {
            //會過，但是很慢
            for (int i = 0; i < temperatures.Length; i++)
            {
                int index = 0;
                for (int j = i + 1; j < temperatures.Length; j++)
                {
                    if (temperatures[j] > temperatures[i])
                    {
                        index = j - i;
                        break;
                    }
                }
                temperatures[i] = index;
            }
            return temperatures;
        }
        public int[] DailyTemperatures2(int[] temperatures)
        {
            int[] res = new int[temperatures.Length];
            Stack<int> st = new Stack<int>();

            for (int i = 0; i < temperatures.Length; ++i)
            {
                //當暫存沒有數值時，置入項
                //當暫存有數值代表有數值需要被比較
                //如果現在最上層的數值比當前溫度小，代表最上層的極限找到了
                //持續做到最上層比當前溫度大為止
                //因此最高溫會被沉在最下層
                while (st.Count > 0 && temperatures[i] > temperatures[st.Peek()])
                {
                    int t = st.Pop();
                    res[t] = i - t;
                }
                st.Push(i);
            }

            return res;
        }
    }
}
