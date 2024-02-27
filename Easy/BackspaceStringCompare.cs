using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class BackspaceStringCompare
    {
        public bool BackspaceCompare(string s, string t)
        {
            var S_Result = new StringBuilder();
            var T_Result = new StringBuilder();
            int IndexNo = -1;
            foreach (var CharOf_S in s)
            {
                switch (CharOf_S)
                {
                    case '#':
                        if (S_Result.Length > 0)
                        {
                            S_Result.Remove(IndexNo, 1);
                            IndexNo--;
                        }
                        break;
                    default:
                        S_Result.Append(CharOf_S);
                        IndexNo++;
                        break;
                }
            }
            IndexNo = -1;
            foreach (var CharOf_T in t)
            {
                switch (CharOf_T)
                {
                    case '#':
                        if (T_Result.Length > 0)
                        {
                            T_Result.Remove(IndexNo, 1);
                            IndexNo--;
                        }
                        break;
                    default:
                        T_Result.Append(CharOf_T);
                        IndexNo++;
                        break;
                }
            }
            return String.Equals(S_Result.ToString(), T_Result.ToString());
        }
    }
}
