using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class LatestTimeYouCanObtainAfterReplacingCharacters
    {
        public string FindLatestTime(string s)
        {
            var Res = new StringBuilder();
            if (s[0] == '?' && s[1] == '?')
            {
                Res.Append('1');
                Res.Append('1');
            }
            else if (s[0] == '?' && s[1] != '?')
            {
                if (s[1] - '0' < 2)
                {
                    Res.Append("1");
                    Res.Append(s[1]);
                }
                else
                {
                    Res.Append("0");
                    Res.Append(s[1]);
                }
            }
            else if(s[0] != '?' && s[1] == '?')
            {
                Res.Append(s[0]);
                if (s[0] == '0')
                {
                    Res.Append('9');
                }
                else
                {
                    Res.Append('1');
                }
            }
            else
            {
                Res.Append(s[0]);
                Res.Append(s[1]);
            }
            //
            Res.Append(s[2]);
            //
            if (s[3] =='?')
            {
                Res.Append('5');
            }
            else
            {
                Res.Append(s[3]);
            }
            if (s[4] == '?')
            {
                Res.Append('9');
            }
            else
            {
                Res.Append(s[4]);
            }
            return Res.ToString();
        }
    }
}
