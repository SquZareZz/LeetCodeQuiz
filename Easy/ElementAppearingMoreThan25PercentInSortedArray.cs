using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ElementAppearingMoreThan25PercentInSortedArray
    {
        public int FindSpecialInteger(int[] arr)
        {
            var Target = arr.Length / 4;
            int Last = arr[0];
            int temp = 1;
            for(int i = 1; i < arr.Length; i++)
            {
                if (temp > Target)
                {
                    return Last;
                }
                if (arr[i] != Last)
                {
                    Last = arr[i];
                    temp = 1;
                }
                else 
                {
                    temp++;
                }
            }
            return Last;
        }
    }
}
