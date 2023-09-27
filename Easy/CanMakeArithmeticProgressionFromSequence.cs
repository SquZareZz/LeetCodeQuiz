using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class CanMakeArithmeticProgressionFromSequence
    {
        public bool CanMakeArithmeticProgression(int[] arr)
        {
            int Len = arr.Length;
            if(Len == 2) return true;
            Array.Sort(arr);
            int Gap = arr[1] - arr[0];
            int Start = arr[1];
            foreach(int i in arr.Skip(2)) 
            {
                if (i - Gap != Start)
                {
                    return false;
                }
                else
                {
                    Start = i;
                }
            }
            return true;
        }
    }
}
