using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class GasStation
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            var CandidateStation = new List<int>();
            for (int i = 0; i < gas.Length; i++)
            {
                if (gas[i] >= cost[i])
                {
                    CandidateStation.Add(i);
                }
            }
            foreach (int i in CandidateStation)
            {
                if (FullTravel(gas, cost, i)) return i;
            }
            return -1;
        }
        public bool FullTravel(int[] gas, int[] cost, int Location)
        {
            int Counter = 0, Len = gas.Length, tank = gas[Location];
            for (int i = Location; i < Len; )
            {
                Counter++;
                if (Counter == Len)
                {
                    return tank - cost[i] >= 0;
                }
                if (tank - cost[i] <= 0)
                {
                    return false;
                }
                else
                {
                    tank = i == Len - 1 ? tank - cost[i] + gas[0]:
                        tank - cost[i] + gas[i + 1];
                }
                i = i == Len - 1 ? 0 : i + 1;
            }
            return true;
        }
        public int CanCompleteCircuit2(int[] gas, int[] cost)
        {
            //one part
            var CandidateStation = new List<int>();
            for (int i = 0; i < gas.Length; i++)
            {
                if (gas[i] >= cost[i])
                {
                    CandidateStation.Add(i);
                }
            }
            foreach (int i in CandidateStation)
            {
                int Counter = 0, Len = gas.Length, tank = gas[i];
                for (int j = i; j < Len;)
                {
                    Counter++;
                    if (Counter == Len && tank - cost[j] >= 0)
                    {
                        return i;
                    }
                    if (tank - cost[j] <= 0)
                    {
                        break;
                    }
                    else
                    {
                        tank = j == Len - 1 ? tank - cost[j] + gas[0] :
                            tank - cost[j] + gas[j + 1];
                    }
                    j = j == Len - 1 ? 0 : j + 1;
                }
            }
            return -1;
        }
        public int CanCompleteCircuit3(int[] gas, int[] cost)
        {
            int Len = gas.Length;
            for (int i=0;i< Len; i++)
            {
                if (gas[i] >= cost[i])
                {
                    int Counter = 0, tank = gas[i];
                    for (int j = i; j < Len;)
                    {
                        Counter++;
                        if (Counter == Len && tank - cost[j] >= 0)
                        {
                            return i;
                        }
                        if (tank - cost[j] <= 0)
                        {
                            break;
                        }
                        else
                        {
                            tank = j == Len - 1 ? tank - cost[j] + gas[0] :
                                tank - cost[j] + gas[j + 1];
                        }
                        j = j == Len - 1 ? 0 : j + 1;
                    }
                }
            }
            return -1;
        }
        public int CanCompleteCircuit4(int[] gas, int[] cost)
        {
            int total = 0, MaxGas = -1, TargetStartLoc = 0;
            for (int i = gas.Length - 1; i >= 0; --i)
            {
                total += gas[i] - cost[i];
                //因為答案只有一個
                //所以該站加油減掉消耗的最大油量會是唯一解
                //其餘有超過的會成為「可能解」
                //所以不斷刷新起始位置start的數值
                if (total > MaxGas)
                {
                    TargetStartLoc = i;
                    MaxGas = total;
                }
            }
            return (total < 0) ? -1 : TargetStartLoc;
        }
    }
}
