using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class NumberOfRecentCalls
    {
        public class RecentCounter
        {
            private readonly Queue<int> q = new Queue<int>();
            //先進先出，所以每次Ping都從數字最小開始檢查
            public int Ping(int t)
            {
                while (q.Any() && q.Peek() + 3000 < t)
                {
                    q.Dequeue();
                }
                q.Enqueue(t);
                return q.Count;
            }
        }
    }
}
