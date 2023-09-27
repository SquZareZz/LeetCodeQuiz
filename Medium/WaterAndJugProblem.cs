using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class WaterAndJugProblem
    {
        public bool CanMeasureWater(int jug1Capacity, int jug2Capacity, int targetCapacity)
        {
            if (targetCapacity > jug1Capacity + jug2Capacity)
            {
                return false;
            }
            //如果其中一個桶子是0，相當於少一個桶子
            //所以只看另一個桶子
            //如果沒有要求水，也是回傳true
            if (jug1Capacity == 0 || jug2Capacity == 0)
            {
                return targetCapacity == 0 || jug1Capacity + jug2Capacity == targetCapacity;
            }
            //一般情況下，找最大公因數
            int Target = GCD(jug1Capacity, jug2Capacity);
            //如果水量要求==兩數最大公因數，即為成功
            return targetCapacity % Target == 0;
        }
        private int GCD(int a, int b)
        {
            //如果是它的因數，回傳時為最大
            //如果不是，最小的餘數是1，所以最後勢必會回傳1
            if (a % b == 0)
            {
                return b;
            }
            else
            {
                return GCD(b, a % b);
            }
        }

        public bool CanMeasureWaterFail(int jug1Capacity, int jug2Capacity, int targetCapacity)
        {
            if (targetCapacity > jug1Capacity && targetCapacity > jug2Capacity
                && jug1Capacity + jug2Capacity < targetCapacity)
            {
                return false;
            }
            var Candidate = new List<int> { jug1Capacity, jug2Capacity };
            int lower = jug2Capacity > jug1Capacity ? jug1Capacity : jug2Capacity;
            int higher = jug2Capacity > jug1Capacity ? jug2Capacity : jug1Capacity;
            while (higher > 0)
            {
                int temp = higher - lower;
                if (temp > 0)
                {
                    Candidate.Add(temp);
                }
                else if (temp < 0)
                {
                    Candidate.Add(lower - higher);
                }
                higher = temp;
            }
            foreach (int Possible in Candidate)
            {
                if (targetCapacity % Possible == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
