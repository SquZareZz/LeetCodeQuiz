using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class UniqueNumberOfOccurrences
    {
        public bool UniqueOccurrences(int[] arr)
        {
            var DictArr = new Dictionary<int, int>();
            var NoDuplicate = arr.ToHashSet();
            foreach (int i in NoDuplicate)
            {
                var temp = arr.Where(x => x == i).Count();
                if (DictArr.ContainsKey(temp))
                {
                    return false;
                }
                else
                {
                    DictArr.Add(temp, i);
                }
            }
            return true;
        }
    }
}
