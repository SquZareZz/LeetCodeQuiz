using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ToLowerCase
    {
        public string ToLowerCaseJustUseFunc(string s)
        {
            return s.ToLower();
        }
        public string ToLowerCase1(string s)
        {
            string Result = "";
            foreach (char c in s)
            {
                //65~90 是大寫，在ASCII表
                Result += c < 65 || c > 90 ? c : (char)(c + 32);
            }
            return Result;
        }
    }
}
