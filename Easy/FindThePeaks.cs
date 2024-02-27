using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class FindThePeaks
    {
        public IList<int> FindPeaks(int[] mountain)
        {
            var Res = new List<int>();
            for (int i = 1; i < mountain.Length - 1; i++)
            {
                if (mountain[i] > mountain[i - 1] && mountain[i] > mountain[i + 1])
                {
                    Res.Add(i);
                }
            }
            return Res;
        }
    }
}
