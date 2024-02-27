using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class CountTestedDevicesAfterTestOperations
    {
        public int CountTestedDevices(int[] batteryPercentages)
        {
            var Res = 0;
            for (int i = 0; i < batteryPercentages.Length; i++)
            {
                if (batteryPercentages[i] > 0)
                {
                    Res++;
                    for (int j = i + 1; j < batteryPercentages.Length; j++)
                    {
                        if (batteryPercentages[j] > 0)
                        {
                            batteryPercentages[j]--;
                        }
                    }
                }
            }
            return Res;
        }
    }
}
