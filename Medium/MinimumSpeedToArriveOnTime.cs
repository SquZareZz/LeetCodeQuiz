using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class MinimumSpeedToArriveOnTime
    {
        public int MinSpeedOnTimeFail(int[] dist, double hour)
        {
            if (dist.Length - 1 > hour)
            {
                return -1;
            }
            Array.Sort(dist);
            int Len = dist.Length;
            int Left = 1, Right = dist.Sum();
            double Speed = (int)((Left + Right) / 2);
            while (Left <= Right)
            {
                Speed = (int)((Left + Right) / 2);
                decimal Result = 0;
                for (int i = 0; i < Len - 1; i++)
                {
                    Result += Math.Ceiling(dist[i] / Speed) > 0 ? (decimal)Math.Ceiling(dist[i] / Speed) : 1;
                }
                Result = dist[Len - 1] / Speed <= 0 ? Result + 1 : Result + (decimal)(dist[Len - 1] / Speed);
                if ((double)Result > Math.Ceiling(hour))
                {
                    Left = (int)Speed + 1;
                }
                else if ((double)Result < Math.Ceiling(hour))
                {
                    Right = (int)Speed - 1;
                }
                else
                {
                    return (int)Speed; // 剛好找到 target
                }
            }
            return (int)Speed;
        }
        public int MinSpeedOnTimeFail2(int[] dist, double hour)
        {
            int Len = dist.Length;
            if (Len - 1 > hour)
            {
                return -1;
            }
            var TokenArray = dist.Distinct().ToArray();
            int Result = Int32.MaxValue;
            decimal Last = dist[Len - 1];
            foreach (decimal Target in TokenArray)
            {
                decimal TempHour = 0;
                foreach (decimal TempDist in dist.Take(Len - 1))
                {
                    TempHour += Math.Max(1, Math.Ceiling(TempDist / Target));
                }
                if (TempHour + (Last / Target) <= (decimal)hour)
                {
                    Result = (int)Math.Min(Result, Target);
                }
            }
            if (Result == Int32.MaxValue)
            {
                int Candidate = (int)Math.Ceiling(Math.Round(dist[Len - 1] / (hour - Len + 1), 2));
                decimal TempHour2 = 0;
                foreach (decimal TempDist in dist)
                {
                    TempHour2 += Math.Max(1, Math.Ceiling(TempDist / Candidate));
                }
                return Candidate;
            }
            else
            {
                return Result;
            }
        }
        public int MinSpeedOnTime(int[] dist, double hour)
        {
            //因為最後一項要重算，所以長度看成總長 -1
            int Len = dist.Length - 1;
            if (hour <= Len)
            {
                return -1;
            }
            //提示答案提到，最大值不超過10^7
            //二分法
            int Left = 1, Limit = (int)1e7;
            while (Left < Limit)
            {
                int Speed = Left + (Limit - Left) / 2;
                double time = 0;
                for (int i = 0; i < Len; i++)
                {
                    time += Math.Ceiling((double)dist[i] / (double)Speed);
                }
                //最後一個答案計算小數
                time += (double)dist[Len] / (double)Speed;
                //如果合格，動右極限，降速
                //不合格改左極限，因為需要更快的速度
                if (time > hour)
                {
                    Left = Speed + 1;
                }
                else
                {
                    Limit = Speed;
                }
            }
            return Left;
        }
    }
}
//while (true)
//{
//    decimal Hours = 0;
//    foreach (decimal OneWay in dist)
//    {
//        Hours = OneWay / Speed <= 0 ? Hours + 1 : Hours + (OneWay / Speed);
//    }
//    if (Hours <= (decimal)hour)
//    {
//        return (int)Speed;
//    }
//    else
//    {
//        Speed++;
//        continue;
//    }
//}
//return (int)Speed;