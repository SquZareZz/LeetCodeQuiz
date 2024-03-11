using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class Heaters
    {
        public int FindRadiusFail(int[] houses, int[] heaters)
        {
            int HouseLen = houses.Length;
            int HeatersLen = heaters.Length;
            if (HeatersLen == 1)
            {
                return Math.Max(Math.Abs(heaters[0] - houses[0]), houses[HouseLen - 1] - heaters[0]);
            }
            List<int> ResultCandidate = new List<int>();
            Array.Sort(houses); Array.Sort(heaters);
            //1.如果加溫器起始 > 房子起始
            if (houses[0] < heaters[0])
            {
                ResultCandidate.Add(heaters[0] - houses[0]);
            }
            //2.計算加溫器之間距離
            for (int i = 0; i < HeatersLen - 1; i++)
            {
                int HeaterGap = (heaters[i + 1] - heaters[i] - 1) / 2;
                //確認兩個加溫器拉到最遠距離後，房子是否剛好落在最遠距離的點
                //如果沒有房子，加溫器可以取更近
                int Candidate = ScanHouse(houses, heaters[i]);
                if (Candidate > heaters[i] && Candidate < heaters[i + 1])
                {
                    int ShortWay = Math.Min(Math.Abs(Candidate - heaters[i + 1]), Math.Abs(Candidate - heaters[i]));
                    if (HeaterGap > ShortWay)
                    {
                        HeaterGap = ShortWay;
                    }
                }
                ResultCandidate.Add(HeaterGap);
            }
            //3.如果加溫器最後 < 房子最後
            if (houses[HouseLen - 1] > heaters[HeatersLen - 1])
            {
                ResultCandidate.Add(houses[HouseLen - 1] - heaters[HeatersLen - 1]);
            }
            return ResultCandidate.Max();
        }
        public int ScanHouse(int[] houses, int HeaterGap)
        {
            int low = 0;
            int high = houses.Length - 1;
            int closest = houses[0];
            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (houses[mid] == HeaterGap)
                {
                    break;
                }

                if (Math.Abs(houses[mid] - HeaterGap) < Math.Abs(closest - HeaterGap))
                {
                    closest = houses[mid];
                }

                if (houses[mid] < HeaterGap)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return closest;
        }

        public int FindRadius(int[] houses, int[] heaters)
        {
            //重點是每間房子都要被暖到，所以應該看房子跟加溫器間的距離
            int Len = heaters.Length, HeaterCurrent = 0, Result = 0;
            Array.Sort(houses);
            Array.Sort(heaters);
            //掃過每間房子，確認每間房子跟加溫器間的距離，取最大值
            for (int i = 0; i < houses.Length; ++i)
            {
                int Current = houses[i];
                // 1.加溫器還沒被掃光 2.右加溫器距離小於等於左加溫器距離 => 看下一台
                while (HeaterCurrent < Len - 1 && Math.Abs(heaters[HeaterCurrent + 1] - Current) <= Math.Abs(heaters[HeaterCurrent] - Current))
                {
                    HeaterCurrent++;
                }
                Result = Math.Max(Result, Math.Abs(heaters[HeaterCurrent] - Current));
            }
            return Result;
        }
        public int FindRadius2(int[] houses, int[] heaters)
        {
            //重點是每間房子都要被暖到，所以應該看房子跟加溫器間的距離
            int Len = heaters.Length, HeaterCurrent = 0, Result = 0;
            Array.Sort(houses);
            Array.Sort(heaters);
            //掃過每間房子，確認每間房子跟加溫器間的距離，取最大值
            foreach(int House in houses)
            {                
                while (HeaterCurrent < Len - 1 && Math.Abs(heaters[HeaterCurrent + 1] - House) <= Math.Abs(heaters[HeaterCurrent] - House))
                {
                    HeaterCurrent++;
                }
                Result = Math.Max(Result, Math.Abs(heaters[HeaterCurrent] - House));
            }
            return Result;
        }
        public int FindRadius3(int[] houses, int[] heaters)
        {
            //重點是每間房子都要被暖到，所以應該看房子跟加溫器間的距離
            int Len = heaters.Length, HeaterCurrent = 0, Result = 0;
            Array.Sort(houses);
            Array.Sort(heaters);
            //掃過每間房子，確認每間房子跟加溫器間的距離，取最大值
            foreach (int House in houses)
            {
                for(int i=HeaterCurrent;i< Len - 1; i++)
                {
                    if(Math.Abs(heaters[HeaterCurrent + 1] - House) <= Math.Abs(heaters[HeaterCurrent] - House))
                    {
                        HeaterCurrent++;
                    }
                    else
                    {
                        break;
                    }
                }
                Result = Math.Max(Result, Math.Abs(heaters[HeaterCurrent] - House));
            }
            return Result;
        }
    }
}
