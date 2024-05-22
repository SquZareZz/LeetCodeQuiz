using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class OpenTheLock
    {
        public int OpenLock(string[] deadends, string target)
        {
            //初始必定是 0000，每一動會往前或往後 (e.g. 1000、9000)
            //每一轉都會延伸出繼續變的可能，直到死鎖
            //(e.g. 0000 => 9000、1000、0900、0100、0090、0010、0009、0001)
            //如果要做這一筆的後續可能就必須先取出 => 用 queue，先進先出，避免加進新數值造成無限循環
            //只到比對到以前一直找，需要走新一步再加 1
            //一開始進迴圈就必須先加一，以防過程中已找到

            //如果目標就是初始，直接回傳
            if (target == "0000") return 0;
            //如果初始就是死鎖，絕對是失敗
            if (deadends.Contains("0000")) return -1;
            //篩選重複的死鎖
            HashSet<string> deadlock = new HashSet<string>(deadends);
            HashSet<string> visited = new HashSet<string>() { "0000" };
            Queue<string> PossibleNums = new Queue<string>();
            int res = 0;
            PossibleNums.Enqueue("0000");
            //只要死鎖沒有限制住可能，就會一直找到不能找為止
            //相當於迷宮走到死路，那就會放棄這條路線
            while (PossibleNums.Any())
            {
                ++res;
                //上一個步長有幾種可能
                int PossibleCounts = PossibleNums.Count;
                for (int k = 0; k < PossibleCounts; ++k)
                {
                    //現在在處理哪個位置
                    string NowStep = PossibleNums.Dequeue();
                    for (int i = 0; i < NowStep.Length; ++i)
                    {
                        //正轉和倒轉兩項，因此 0 時要跳過
                        for (int j = -1; j <= 1; ++j)
                        {
                            if (j == 0) continue;
                            char[] chars = NowStep.ToCharArray();
                            chars[i] = (char)(((NowStep[i] - '0') + 10 + j) % 10 + '0');
                            string str = String.Join("", chars);
                            if (str == target)
                            {
                                return res;
                            }
                            //如果走到死鎖或者已經遍歷過，不要再把數字放進佇列
                            if (!visited.Contains(str) && !deadlock.Contains(str))
                            {
                                PossibleNums.Enqueue(str);
                                visited.Add(str);
                            }
                        }
                    }
                }
            }
            return -1;
        }
    }
}