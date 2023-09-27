using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class CountAndSay
    {
        public string CountAndSay1(int n)
        {
            string Start = "1";
            for (int i = 2; i < n + 1; i++)
            {
                var ListNumberN = new List<int[]>();
                char Now = Start[0];
                int Count = 0;
                foreach (char c in Start)
                {
                    if (Now != c)
                    {
                        ListNumberN.Add(new int[] { Count, Now - '0' });
                        Now = c;
                        Count = 1;
                    }
                    else
                    {
                        Count++;
                    }
                }
                ListNumberN.Add(new int[] { Count, Start[Start.Length - 1] - '0' });
                string temp = "";
                foreach (var Element in ListNumberN)
                {
                    temp += Element[0].ToString() + Element[1].ToString();
                }
                Start = temp;
            }
            return Start;
        }
    }
}
