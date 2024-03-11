using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class RemoveK_Digits
    {
        public string RemoveKdigitsFail(string num, int k)
        {
            if (k >= num.Length)
            {
                return "0";
            }
            var Candidate = new List<int>();
            for (int i = 0; i < num.Length - k + 1; i++)
            {
                var temp = num;
                Candidate.Add(Int32.Parse(temp.Remove(i, k)));
            }
            return Candidate.Min().ToString();
        }
        public string RemoveKdigits(string num, int k)
        {
            if (num.Length == k) return "0";
            //StringBuilder 組字串比較快 
            StringBuilder sb = new StringBuilder();
            //如果最後一個數字大過當前數字，就把它拔掉
            //直到拔到限制的數字為止
            Stack<int> st = new Stack<int>();
            //先進後出
            foreach (var item in num)
            {
                while (st.Count > 0 
                    && st.Peek() > item - '0' 
                    && k > 0)
                {
                    st.Pop();
                    k--;
                    sb.Remove(sb.Length - 1, 1);
                }
                st.Push(item - '0');
                sb.Append(item - '0');
            }
            while (k > 0)
            {
                st.Pop();
                k--;
                sb.Remove(sb.Length - 1, 1);
            }
            //如果開頭有0把它去掉
            string result = sb.ToString().TrimStart('0');
            return result == "" ? "0" : result;
        }
    }
}
