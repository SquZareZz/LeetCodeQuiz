using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class CapacityToShipPackagesWithinDDays
    {
        public int ShipWithinDaysFail(int[] weights, int days)
        {
            //一定要按照順序取
            int PreWeight = Math.Max(weights.Sum() / days, weights.Max()), PackagesCount = 0;
            var PackagesList = new List<IList<int>>();
            while (true)
            {
                var ListTemp = new List<int>();
                while (ListTemp.Sum() <= PreWeight && PackagesCount < weights.Length)
                {
                    ListTemp.Add(weights[PackagesCount]);
                    PackagesCount++;
                }
                if (ListTemp.Sum() > PreWeight)
                {
                    ListTemp.RemoveAt(ListTemp.Count - 1);
                    PackagesCount--;
                }
                PackagesList.Add(ListTemp);
                if (PackagesCount == weights.Length)
                {
                    if (PackagesList.Count <= days)
                    {
                        return PreWeight;
                    }
                    var ListLeast = PackagesList.GetRange(days, PackagesList.Count - days);
                    int sumTemp = 0;
                    foreach (var temp in ListLeast)
                    {
                        sumTemp += temp.Sum();
                    }
                    PackagesList = new List<IList<int>>();
                    PreWeight += sumTemp / days;
                    PackagesCount = 0;
                }
            }
        }
        public int ShipWithinDaysRandomPackage(int[] weights, int days)
        {
            //不能按照順序取
            Array.Sort(weights);
            int PreWeight = weights.Max();
            var PackagesList = new List<IList<int>>();
            while (true)
            {
                var ListTemp = new List<int>();
                List<int> WeightsToken = weights.ToList();
                WeightsToken.Reverse();
                while (WeightsToken.Count > 0)
                {
                    var Candiate = new List<int>();
                    int PreWeightToken = PreWeight;
                    while (PreWeightToken > 0)
                    {
                        if (WeightsToken.Contains(PreWeightToken))
                        {
                            Candiate.Add(PreWeightToken);
                            WeightsToken.Remove(PreWeightToken);
                            PreWeightToken -= PreWeightToken;
                        }
                        else
                        {
                            if (WeightsToken.Count < 1 || PreWeightToken < WeightsToken.Min())
                            {
                                break;
                            }
                            else
                            {
                                foreach (int Weight in WeightsToken)
                                {
                                    if (Weight < PreWeightToken)
                                    {
                                        Candiate.Add(Weight);
                                        WeightsToken.Remove(Weight);
                                        PreWeightToken -= Weight;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    PackagesList.Add(Candiate);
                }
                if (PackagesList.Count == days)
                {
                    return PreWeight;
                }
                PackagesList = new List<IList<int>>();
                PreWeight++;
            }
        }
        public int ShipWithinDaysSlowly(int[] weights, int days)
        {
            //一定要按照順序取
            int PreWeight = Math.Max(weights.Sum() / days, weights.Max()), PackagesCount = 0;
            var PackagesList = 0;
            while (true)
            {
                int SumTemp = 0;
                while (SumTemp <= PreWeight && PackagesCount < weights.Length)
                {
                    SumTemp += weights[PackagesCount];
                    PackagesCount++;
                }
                if (SumTemp > PreWeight)
                {
                    PackagesCount--;
                }
                PackagesList++;
                if (PackagesCount == weights.Length)
                {
                    if (PackagesList <= days)
                    {
                        return PreWeight;
                    }
                    PackagesList = 0;
                    PreWeight++;
                    PackagesCount = 0;
                }
            }
        }
        public int ShipWithinDays2(int[] weights, int days)
        {
            //一定要按照順序取
            int PreDays = Math.Max(weights.Sum() / days, weights.Max()), MaxDays = weights.Sum();//猜測最小天數:實際最多天數
            while (PreDays < MaxDays)
            {
                int mid = PreDays + (MaxDays - PreDays) / 2, NeedDays = 1, CurrentWeights = 0;
                foreach (int w in weights)
                {
                    CurrentWeights += w;
                    if (CurrentWeights > mid)
                    {
                        CurrentWeights = w;
                        NeedDays++;
                    }
                }
                if (NeedDays > days)
                {
                    PreDays = mid + 1;
                }
                else
                {
                    MaxDays = mid;
                }
            }
            return PreDays;
        }
        public int ShipWithinDays(int[] weights, int days)
        {
            //一定要按照順序取
            int PreWeightsMax = weights.Sum(), PreWeightsMin = weights.Max();
            while (PreWeightsMin < PreWeightsMax)
            {
                int PreWeightsMid = (PreWeightsMax + PreWeightsMin) / 2, PackagesOneDay = 0, DeliverDays = 1;

                foreach (int w in weights)
                {
                    PackagesOneDay += w;
                    if (PackagesOneDay > PreWeightsMid)
                    {
                        DeliverDays++;
                        PackagesOneDay = w;
                    }
                }
                if (DeliverDays > days)
                {
                    PreWeightsMin = PreWeightsMid + 1;
                }
                else
                {
                    PreWeightsMax = PreWeightsMid;
                }
            }
            return PreWeightsMin;
        }
    }
}
